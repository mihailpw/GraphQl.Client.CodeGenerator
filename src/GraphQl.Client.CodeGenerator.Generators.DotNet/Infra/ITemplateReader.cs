using System.Threading.Tasks;

namespace GraphQl.Client.CodeGenerator.Generators.DotNet.Infra
{
    public interface ITemplateReader
    {
        Task<string> ReadAsync(string name);
    }
}