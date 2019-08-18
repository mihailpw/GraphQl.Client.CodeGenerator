using System;

namespace GraphQl.Client.CodeGenerator.Infra.Exceptions
{
    public class GeneratorNotSupportedException : GeneratorExceptionBase
    {
        public GeneratorNotSupportedException(string message)
            : base(message)
        {
        }

        public GeneratorNotSupportedException(string message, Exception exception)
            : base(message, exception)
        {
        }
    }
}