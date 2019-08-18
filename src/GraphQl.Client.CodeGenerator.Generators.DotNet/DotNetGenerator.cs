using System.Threading.Tasks;
using GraphQl.Client.CodeGenerator.Generators.DotNet.Infra;
using GraphQl.Client.CodeGenerator.Infra;
using GraphQl.Client.CodeGenerator.Infra.Models;

namespace GraphQl.Client.CodeGenerator.Generators.DotNet
{
    [Generator("dotnet")]
    public class DotNetGenerator : IGenerator
    {
        public async Task GenerateAsync(GraphQlSchema schema, IGeneratorWriterFactory writerFactory, GeneratorContext context)
        {
            using (var writer = await writerFactory.CreateAsync(context.WriterName))
            {
                var generatorWriter = new GeneratorWriter(
                    new HandlebarsResourcesTemplateReader(),
                    new HandlebarsTemplateBuilder(context),
                    writer);

                await generatorWriter.GenerateAsync(schema, context);
            }
        }
    }
}