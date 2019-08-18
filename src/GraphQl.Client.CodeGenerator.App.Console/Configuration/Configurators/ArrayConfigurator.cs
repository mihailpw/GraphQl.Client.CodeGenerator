using System;
using System.Linq;
using System.Reflection;
using GraphQl.Client.CodeGenerator.Infra.Exceptions;

namespace GraphQl.Client.CodeGenerator.App.Console.Configuration.Configurators
{
    public class ArrayConfigurator : ConfiguratorBase
    {
        protected override void ConfigureInternal(object target, PropertyInfo property, ConfiguratorPropertyAttribute configuratorPropertyAttr)
        {
            if (!property.PropertyType.IsArray)
            {
                throw new GeneratorInvalidOperationException($"Property {property.Name} (type={property.PropertyType.Name}) is not array.");
            }

            var defaultValue = property.GetValue(target);

            System.Console.WriteLine(configuratorPropertyAttr.SetupQuestion);
            if (defaultValue != null)
            {
                System.Console.WriteLine($"(default={defaultValue}).");
            }

            var values = System.Console.ReadLine()?.Split(",") ?? Enumerable.Empty<string>();
            var itemType = property.PropertyType.GetElementType();
            var convertedValues = values.Select(v => Convert.ChangeType(v, itemType)).ToArray();

            var convertedArray = Array.CreateInstance(itemType, convertedValues.Length);
            Array.Copy(convertedValues, convertedArray, convertedValues.Length);

            property.SetValue(target, convertedArray);
        }
    }
}