using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MQTT_ClientProvider;
using TestItem.Data;

namespace TestItem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();

            IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            MqttClientSettings mqttClientSettings =
                MqttClientSettings.GetMqttClientSettings(configuration);

            MqttClientProvider mqttClientProvider = 
                new MqttClientProvider(mqttClientSettings);

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

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}