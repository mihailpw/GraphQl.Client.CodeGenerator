using System.Collections.Generic;
using GraphQl.Client.CodeGenerator.Infra.Exceptions;

namespace GraphQl.Client.CodeGenerator.Processor.GeneratorStores
{
    public class GeneratorNotFoundException : GeneratorExceptionBase
    {
        public GeneratorNotFoundException(string generatorName, IEnumerable<string> availableGenerators)
            : base($"Generator '{generatorName}' not found. Available generators: {string.Join(", ", availableGenerators)}")
        {
        }
    }
}