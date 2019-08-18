namespace GraphQl.Client.CodeGenerator.Infra.Exceptions
{
    public class GeneratorArgumentNullException : GeneratorExceptionBase
    {
        public GeneratorArgumentNullException(string parameterName)
            : base($"Parameter '{parameterName}' is null.")
        {
        }
    }
}