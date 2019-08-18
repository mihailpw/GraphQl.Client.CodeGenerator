using System;

namespace GraphQl.Client.CodeGenerator.Infra.Exceptions
{
    public abstract class GeneratorExceptionBase : Exception
    {
        protected GeneratorExceptionBase(string message)
            : base(CreateMessage(message))
        {
        }

        protected GeneratorExceptionBase(string message, Exception exception)
            : base(CreateMessage(message), exception)
        {
        }


        private static string CreateMessage(string innerMessage)
        {
            var lines = new[]
            {
                innerMessage,
                "Please ask https://github.com/mihailpw/GraphQlClientCodeGenerator/issues",
            };

            return string.Join(Environment.NewLine, lines);
        }
    }
}