using Microsoft.Extensions.Configuration;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Diagnostics;
using MQTTnet.Implementations;
using MQTTnet.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQTT_ClientProvider
{
    public class MqttClientProvider
    {
        private readonly IMqttClient _mqttClient;
        private readonly MqttClientOptions _options;
        public MqttClientProvider(MqttClientSettings mqttClientSettings)
        {
            var factory = new MqttFactory();
            _mqttClient = factory.CreateMqttClient();
            _options = CreateClient(mqttClientSettings);
        }

        private MqttClientOptions CreateClient(MqttClientSettings mqttClientSettings)
        {
            return new MqttClientOptionsBuilder()
                .WithClientId(mqttClientSettings.ClientId)
                .WithTcpServer(mqttClientSettings.BrokerUrl, mqttClientSettings.Port)
                .WithCredentials(mqttClientSettings.Username, mqttClientSettings.Password)
                .Build();
        }
    }
}
