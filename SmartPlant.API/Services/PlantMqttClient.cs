using System.Text;
using SmartPlant.API.Entities;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace SmartPlant.API.Services;

public class PlantMqttClient
{
    private readonly MqttClient _client;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public PlantMqttClient(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory ?? throw new ArgumentNullException(nameof(serviceScopeFactory));
        _client = new MqttClient("192.168.1.78");
        _client.Subscribe(new[] { "home/plant/#" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
        _client.MqttMsgPublishReceived += messageHandler;
    }

    public void Connect()
    {
        _client.Connect(new Guid().ToString());
    }
    
    private async void messageHandler(object sender, MqttMsgPublishEventArgs e)
    {
        Console.WriteLine("Received = " + Encoding.UTF8.GetString(e.Message) + " on topic " + e.Topic);
        String message = Encoding.UTF8.GetString(e.Message);
        String topic = e.Topic;

        String[] subTopics = topic.Split("/");

        int plantId = int.Parse(subTopics[2]);
        string subTopic = subTopics[3];

        var scope = _serviceScopeFactory.CreateScope();
        
            var mqttRepositoryService = scope.ServiceProvider.GetService<MqttRepositoryService>();
            Plant plant;
            if (!await mqttRepositoryService.PlantExists(plantId))
            {
                plant = new Plant()
                {
                    PlantId = plantId,
                    MinMoistureLevel = 200,
                    MaxMoistureLevel = 800,
                    MinWaterLevel = 200,
                    MaxWaterLevel = 800,
                    Name = $"Plant {plantId}"
                };

                await mqttRepositoryService.AddPlant(plant);
            }

            plant = await mqttRepositoryService.GetPlantAsync(plantId);

            switch (subTopic)
            {
                case "soilMoisture": plant.MoistureLevels.Add(new Moisture(){DateTime = DateTime.Now, Percentage = int.Parse(message)});
                    break;
                case "waterLevel": plant.WaterLevels.Add(new WaterLevel(){DateTime = DateTime.Now, Percentage = int.Parse(message)});
                    break;
            }

            await mqttRepositoryService.SaveChangesAsync();
        
    }
    
    public void GiveWater(int plantId)
    {
        string msg = "1,5";
        _client.Publish($"home/plant/{plantId.ToString()}/in", Encoding.UTF8.GetBytes(msg), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
    }

    public void SetMinWaterLevelValue(int plantId, int value)
    {
        string msg = $"4,{value}";
        _client.Publish($"home/plant/{plantId.ToString()}/in", Encoding.UTF8.GetBytes(msg), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
    }

    public void SetMaxWaterLevelValue(int plantId, int value)
    {
        string msg = $"5,{value}";
        _client.Publish($"home/plant/{plantId.ToString()}/in", Encoding.UTF8.GetBytes(msg), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
    }

    public void SetMinMoistureValue(int plantId, int value)
    {
        string msg = $"6,{value}";
        _client.Publish($"home/plant/{plantId.ToString()}/in", Encoding.UTF8.GetBytes(msg), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
    }

    public void SetMaxMoistureValue(int plantId, int value)
    {
        string msg = $"7,{value}";
        _client.Publish($"home/plant/{plantId.ToString()}/in", Encoding.UTF8.GetBytes(msg), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
    }
}