using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GraphQl.Client.CodeGenerator.App.Console.Configuration.Configurators;
using GraphQl.Client.CodeGenerator.Infra;
using GraphQl.Client.CodeGenerator.Infra.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace GraphQl.Client.CodeGenerator.App.Console.Configuration
{
    internal class Config
    {
        [ConfiguratorProperty(
            setupQuestion: "Set schema uri: ")]
        public string SchemaUri { get; set; }

        [ConfiguratorProperty(
            setupQuestion: "Set generator name: ", "dotnetcore")]
        public string Generator { get; set; }

        [OptionalConfiguratorProperty(
            optionalQuestion: "Do you want to set inner level of type?",
            setupQuestion: "Set inner level of type: ",
            "dotnetcore")]
        public int InnerLevelOfType { get; set; } = 4;

        [OptionalConfiguratorProperty(
            optionalQuestion: "Do you want to set output name?",
            setupQuestion: "Set output name: ")]
        public string Name { get; set; } = "Generated.cs";

        [ConfiguratorProperty(
            setupQuestion: "Do you want write generation to file?",
            ConfiguratorType = typeof(BooleanConfigurator))]
        public bool OutputToFolder { get; set; } = true;

        [OptionalConfiguratorProperty(
            optionalQuestion: "Do you want to set output folder path?",
            setupQuestion: "Set output folder path: ")]
        public string OutputFolderPath { get; set; } = "./";

        [ConfiguratorProperty(
            setupQuestion: "Do you want save generation to console?",
            ConfiguratorType = typeof(BooleanConfigurator))]
        public bool OutputToConsole { get; set; }

        [OptionalConfiguratorProperty(
            optionalQuestion: "Do you want to set namespace?",
            setupQuestion: "Set namespace: ")]
        public string Namespace { get; set; } = "GraphQlClient";

        [OptionalConfiguratorProperty(
            optionalQuestion: "Do you want to set main client factory class name?",
            setupQuestion: "Set main client factory class name: ")]
        public string MainClientFactoryClassName { get; set; } = "AppClientFactory";

        [OptionalConfiguratorProperty(
            optionalQuestion: "Do you want to set additional client using?",
            setupQuestion: "Set additional client using (use comma to separate): ",
            ConfiguratorType = typeof(ArrayConfigurator))]
        public string[] AdditionalClientUsing { get; set; } = null;

        [ConfiguratorProperty(
            setupQuestion: "Do you want to generate docs?",
            ConfiguratorType = typeof(BooleanConfigurator))]
        public bool GenerateDocs { get; set; } = false;

        [ConfiguratorProperty(
            setupQuestion: "Do you want to generate input object constructor?",
            ConfiguratorType = typeof(BooleanConfigurator))]
        public bool GenerateInputObjectConstructor { get; set; } = false;

        [OptionalConfiguratorProperty(
            optionalQuestion: "Do you want to set type naming?",
            setupQuestion: "Set type naming: ",
            ConfiguratorType = typeof(TypeNamingConfigurator))]
        public TypeNamingModel TypeNaming { get; set; } = new TypeNamingModel();


        public static async Task<Config> ReadFromAsync(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException();
            }

            using (var stream = File.OpenRead(path))
            using (var streamReader = new StreamReader(stream))
            {
                var data = await streamReader.ReadToEndAsync();
                return JsonConvert.DeserializeObject<Config>(data, new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                });
            }
        }


        public bool Validate(out IReadOnlyList<string> errors)
        {
            IEnumerable<string> GetErrors()
            {
                if (string.IsNullOrEmpty(SchemaUri))
                {
                    yield return "Schema url not provided.";
                }
                else if (!Uri.TryCreate(SchemaUri, UriKind.Absolute, out _))
                {
                    yield return "Schema url is not valid.";
                }

                if (string.IsNullOrEmpty(Generator))
                {
                    yield return "Generator not specified.";
                }

                if (string.IsNullOrEmpty(Name))
                {
                    yield return "Name not specified.";
                }

                if (OutputToFolder)
                {
                    if (OutputFolderPath == null)
                    {
                        yield return "Output file path is not provided.";
                    }
                    else if (!Uri.TryCreate(OutputFolderPath, UriKind.RelativeOrAbsolute, out _))
                    {
                        yield return "Output file path is not valid.";
                    }
                }

                if (string.IsNullOrEmpty(Namespace))
                {
                    yield return "Namespace not provided.";
                }

                if (string.IsNullOrEmpty(MainClientFactoryClassName))
                {
                    yield return "Main client factory class name not provided.";
                }

                if (TypeNaming == null)
                {
                    yield return "Type naming not provided.";
                }
            }

            errors = GetErrors().ToList();
            return errors.Count == 0;
        }

        public GeneratorContext CreateGeneratorContext()
        {
            return new GeneratorContext
            {
                WriterName = Name,
                Namespace = Namespace,
                MainClientFactoryClassName = MainClientFactoryClassName,
                AdditionalClientUsing = AdditionalClientUsing?.ToList() ?? new List<string>(0),
                GenerateDocs = GenerateDocs,
                GenerateInputObjectConstructor = GenerateInputObjectConstructor,
                TypeNaming = TypeNaming,
            };
        }
    }
}
