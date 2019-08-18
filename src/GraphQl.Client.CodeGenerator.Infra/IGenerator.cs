using System.Threading.Tasks;
using GraphQl.Client.CodeGenerator.Infra.Models;

namespace GraphQl.Client.CodeGenerator.Infra
{
    public interface IGenerator
    {
        Task GenerateAsync(GraphQlSchema schema, IGeneratorWriterFactory writerFactory, GeneratorContext context);
    }
}