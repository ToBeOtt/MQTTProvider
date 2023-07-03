using Microsoft.Extensions.DependencyInjection;
using MQTT_ClientProvider;
using MQTTnet.Client;
using System.Configuration;

namespace ClientReceiverSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddRazorPages();

            // Sets a configuration-object with appsettings.json-data
            IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            // Sends configuration to class library. Return configuration-values.
            MqttClientSettings mqttClientSettings =
                MqttClientSettings.GetMqttClientSettings(configuration);

            // Create a new MQTT-client with custom values.
            MqttClientProvider mqttClientProvider = new MqttClientProvider(mqttClientSettings);

            // Make a single reusable instance of the above created MQTT-client.
            builder.Services.AddSingleton<MqttClientProvider>(mqttClientProvider);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}