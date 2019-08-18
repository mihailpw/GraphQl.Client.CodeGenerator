using GraphQl.Client.CodeGenerator.Infra.Exceptions;

namespace GraphQl.Client.CodeGenerator.Infra.Utils
{
    public static class Extensions
    {
        public static T VerifyNotNull<T>(this T source, string paramName) where T : class
        {
            return source ?? throw new GeneratorArgumentNullException(paramName);
        }
    }
}