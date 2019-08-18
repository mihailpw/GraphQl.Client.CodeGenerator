using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GraphQl.Client.CodeGenerator.App.Console.Configuration;
using GraphQl.Client.CodeGenerator.Generators.DotNet;
using GraphQl.Client.CodeGenerator.Infra;
using GraphQl.Client.CodeGenerator.Infra.Exceptions;
using GraphQl.Client.CodeGenerator.Processor;
using GraphQl.Client.CodeGenerator.Processor.GeneratorStores;
using GraphQl.Client.CodeGenerator.Processor.GeneratorWriters;
using GraphQl.Client.CodeGenerator.Processor.SchemaReaders;

namespace GraphQl.Client.CodeGenerator.App.Console
{
    internal static class ClientGeneration
    {
        public static async Task GenerateClientAsync(ConsoleOptions options)
        {
            options.WorkingDir ??= Directory.GetCurrentDirectory();
            options.Config = Path.Combine(options.WorkingDir, options.Config);

            var config = !options.ConfigCreate
                ? await Config.ReadFromAsync(options.Config)
                : await AutoConfigurator.CreateAndWriteConfig(options.Config);

            if (!config.Validate(out var configErrors))
            {
                var resultMessage = string.Join(
                    Environment.NewLine,
                    new[] { "wrong config file provided.", "Config file errors:" }.Concat(configErrors));
                throw new GeneratorInvalidOperationException(resultMessage);
            }

            var storage = new FromAssembliesGeneratorStore(new []
            {
                typeof(DotNetGenerator).Assembly,
            });
            var schemaLoader = new FromUrlSchemaReader(config.SchemaUri, config.InnerLevelOfType);
            var writer = CreateWriterFactory(config);

            var processor = new GenerationProcessor(storage, schemaLoader, writer);
            await processor.ProcessAsync(config.Generator, config.CreateGeneratorContext());
        }


        private static IGeneratorWriterFactory CreateWriterFactory(Config config)
        {
            var factories = new List<IGeneratorWriterFactory>();

            if (config.OutputToFolder)
            {
                factories.Add(new FileGeneratorWriterFactory(config.OutputFolderPath));
            }

            if (config.OutputToConsole)
            {
                factories.Add(new TextGeneratorWriterFactory(System.Console.Out));
            }

            switch (factories.Count)
            {
                case 0:
                    throw new GeneratorInvalidOperationException("Output target not provided.");
                case 1:
                    return factories.First();
                default:
                    return new CompositeGeneratorWriterFactory(factories);
            }
        }
    }
}