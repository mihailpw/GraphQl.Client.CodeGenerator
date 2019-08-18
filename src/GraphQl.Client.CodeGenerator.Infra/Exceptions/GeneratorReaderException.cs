using System;

namespace GraphQl.Client.CodeGenerator.Infra.Exceptions
{
    public class GeneratorReaderException : GeneratorExceptionBase
    {
        public GeneratorReaderException(string message)
            : base(message)
        {
        }

        public GeneratorReaderException(string message, Exception exception)
            : base(message, exception)
        {
        }
    }
}