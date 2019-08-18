namespace GraphQl.Client.CodeGenerator.Infra.Exceptions
{
    public class GeneratorInvalidOperationException : GeneratorExceptionBase
    {
        public GeneratorInvalidOperationException(string message)
            : base(message)
        {
        }
    }
}