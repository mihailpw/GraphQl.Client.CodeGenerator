using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQl.Client.CodeGenerator.Generators.DotNet.Infra
{
    public interface ITemplateBuilder
    {
        Task<string> BuildAsync(string template, object data, IDictionary<string, string> partials = null);
    }
}