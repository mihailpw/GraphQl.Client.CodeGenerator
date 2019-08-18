using System.Threading.Tasks;
using GraphQl.Client.CodeGenerator.Infra.Models;

namespace GraphQl.Client.CodeGenerator.Processor.SchemaReaders
{
    public interface ISchemaReader
    {
        Task<GraphQlSchema> LoadSchemaDataAsync();
    }
}