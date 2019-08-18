using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GraphQl.Client.CodeGenerator.Generators.DotNet.Infra;
using GraphQl.Client.CodeGenerator.Infra;
using GraphQl.Client.CodeGenerator.Infra.Models;

namespace GraphQl.Client.CodeGenerator.Generators.DotNet
{
    internal class GeneratorWriter
    {
        private readonly ITemplateReader _templateReader;
        private readonly ITemplateBuilder _templateBuilder;
        private readonly IGeneratorWriter _writer;


        public GeneratorWriter(ITemplateReader templateReader, ITemplateBuilder templateBuilder, IGeneratorWriter writer)
        {
            _templateReader = templateReader;
            _templateBuilder = templateBuilder;
            _writer = writer;
        }


        public async Task GenerateAsync(GraphQlSchema schema, GeneratorContext context)
        {
            var infraTemplate = await _templateReader.ReadAsync("infra");
            var infraView = await _templateBuilder.BuildAsync(
                infraTemplate,
                new { context.Namespace });

            var partials = await ResolveTemplatesAsync("dto", "builder", "builder-method-args", "builder-method-object", "builder-method-scalar");
            var clientTemplate = await _templateReader.ReadAsync("client");
            var clientView = await _templateBuilder.BuildAsync(
                clientTemplate,
                new
                {
                    context.Namespace,
                    context.MainClientFactoryClassName,
                    context.AdditionalClientUsing,
                    context.GenerateDocs,
                    context.GenerateInputObjectConstructor,
                    schema,
                },
                partials);

            var result = string.Join(Environment.NewLine, clientView, infraView);
            await _writer.WriteAsync(result);
        }


        private async Task<IDictionary<string, string>> ResolveTemplatesAsync(params string[] templateNames)
        {
            var dict = new Dictionary<string, string>();

            foreach (var templateName in templateNames)
            {
                var template = await _templateReader.ReadAsync(templateName);
                dict.Add(templateName, template);
            }

            return dict;
        }
    }
}