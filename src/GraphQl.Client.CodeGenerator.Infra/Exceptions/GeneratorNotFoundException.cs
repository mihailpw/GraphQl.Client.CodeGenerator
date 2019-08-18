using System.Collections.Generic;

namespace GraphQl.Client.CodeGenerator.Infra.Exceptions
{
    public class GeneratorNotFoundException : GeneratorExceptionBase
    {
        public GeneratorNotFoundException(string generatorName, IEnumerable<string> availableGenerators)
            : base($"Generator '{generatorName}' not found. Available generators: {string.Join(", ", availableGenerators)}")
        {
        }
    }
}