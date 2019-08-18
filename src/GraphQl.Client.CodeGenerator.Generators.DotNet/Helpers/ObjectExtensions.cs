using System.Linq;
using GraphQl.Client.CodeGenerator.Infra.Exceptions;

namespace GraphQl.Client.CodeGenerator.Generators.DotNet.Helpers
{
    public static class ObjectExtensions
    {
        public static T ResolveArgument<T>(this object[] arguments)
        {
            if (arguments.Length != 1)
            {
                throw new GeneratorInvalidOperationException("Should be 1 argument.");
            }
            if (!(arguments[0] is T value))
            {
                throw new GeneratorInvalidOperationException($"Should be {typeof(T).Name} object.");
            }

            return value;
        }

        public static (TFirst first, TSecond second) ResolveArguments<TFirst, TSecond>(this object[] arguments)
        {
            var first = arguments.ElementAtOrDefault(0);
            var second = arguments.ElementAtOrDefault(1);

            if (!(first is TFirst firstValue))
            {
                if (first != null)
                {
                    throw new GeneratorInvalidOperationException($"First parameter should be {typeof(TFirst).Name} object.");
                }

                firstValue = default(TFirst);
            }

            if (!(second is TSecond secondValue))
            {
                if (second != null)
                {
                    throw new GeneratorInvalidOperationException($"Second parameter should be {typeof(TSecond).Name} object.");
                }

                secondValue = default(TSecond);
            }

            return (firstValue, secondValue);
        }

        public static (TFirst first, TSecond[] second) ResolveArgumentsInfinity<TFirst, TSecond>(this object[] arguments)
        {
            if (arguments.Length < 1)
            {
                throw new GeneratorInvalidOperationException("Should be at list 1 arguments.");
            }
            if (!(arguments[0] is TFirst firstValue))
            {
                throw new GeneratorInvalidOperationException($"First parameter should be {typeof(TFirst).Name} object.");
            }

            var array = arguments.Skip(1).Cast<TSecond>().ToArray();
            return (firstValue, array);
        }
    }
}