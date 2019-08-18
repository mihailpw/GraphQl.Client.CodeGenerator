using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using GraphQl.Client.CodeGenerator.Infra.Exceptions;

namespace GraphQl.Client.CodeGenerator.Generators.DotNet.Infra
{
    public class HandlebarsResourcesTemplateReader : ITemplateReader
    {
        private const string TemplatesPathFormat = "GraphQl.Client.CodeGenerator.Generators.DotNet.Templates.{0}.handlebars";

        private readonly Assembly _assembly;


        public HandlebarsResourcesTemplateReader()
        {
            _assembly = Assembly.GetAssembly(typeof(DotNetGenerator));
        }


        public async Task<string> ReadAsync(string name)
        {
            var path = string.Format(TemplatesPathFormat, name);

            using (var stream = _assembly.GetManifestResourceStream(path))
            {
                if (stream == null)
                {
                    throw new GeneratorInvalidOperationException(
                        $"Resource '{path}' not found in assembly {_assembly.FullName}");
                }

                using (var reader = new StreamReader(stream))
                {
                    return await reader.ReadToEndAsync();
                }
            }
        }
    }
}