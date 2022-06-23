using System.Text;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace SmartPlant.API.Services;

public class PlantMqttClient
{
    private readonly MqttClient _client;

    public PlantMqttClient()
    {
        _client = new MqttClient("192.168.1.78");
        _client.Subscribe(new[] { "home/plant/#" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
        _client.MqttMsgPublishReceived += messageHandler;
    }

    public void Connect()
    {
        _client.Connect(new Guid().ToString());
    }
    
    private void messageHandler(object sender, MqttMsgPublishEventArgs e)
    {
        Console.WriteLine("Received = " + Encoding.UTF8.GetString(e.Message) + " on topic " + e.Topic);
    }
    
    public void publishMessage(String msg, int plantId)
    {
        _client.Publish($"home/plant/{plantId.ToString()}", Encoding.UTF8.GetBytes(msg), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
    }
}