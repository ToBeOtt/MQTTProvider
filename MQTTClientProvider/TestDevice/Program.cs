using Microsoft.Extensions.Configuration;
using MQTT_ClientProvider;

namespace TestDevice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Sends configuration to class library. Return configuration-values.
            MqttClientSettings mqttClientSettings =
                MqttClientSettings.GetMqttClientSettings(configuration);

            // Create a new MQTT-client with custom values.
            MqttClientProvider mqttClientProvider = new MqttClientProvider(mqttClientSettings);

        }
    }
}