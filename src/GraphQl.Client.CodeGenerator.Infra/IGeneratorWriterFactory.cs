using System.Threading.Tasks;

namespace GraphQl.Client.CodeGenerator.Infra
{
    public interface IGeneratorWriterFactory
    {
        Task<IGeneratorWriter> CreateAsync(string name);
    }
}