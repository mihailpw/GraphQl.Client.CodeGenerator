using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using GraphQl.Client.CodeGenerator.App.Console.Configuration.Configurators;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace GraphQl.Client.CodeGenerator.App.Console.Configuration
{
    internal static class AutoConfigurator
    {
        public static async Task<Config> CreateAndWriteConfig(string path)
        {
            var config = CreateConfig();

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            var json = JsonConvert.SerializeObject(config, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented,
            });
            using (var stream = File.OpenWrite(path))
            using (var streamWriter = new StreamWriter(stream))
            {
                await streamWriter.WriteAsync(json);
            }

            return config;
        }


        private static Config CreateConfig()
        {
            var config = new Config();

            foreach (var property in config.GetType().GetProperties())
            {
                var configuratorProperty = property.GetCustomAttribute<ConfiguratorPropertyAttribute>();
                if (configuratorProperty == null)
                {
                    continue;
                }

                var configurator = (ConfiguratorBase) Activator.CreateInstance(configuratorProperty.ConfiguratorType);
                configurator.Configure(config, property, configuratorProperty);
            }

            return config;
        }
    }
}