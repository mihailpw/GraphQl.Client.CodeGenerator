using System.Reflection;
using GraphQl.Client.CodeGenerator.App.Console.Utils;

namespace GraphQl.Client.CodeGenerator.App.Console.Configuration.Configurators
{
    public class DefaultConfigurator : ConfiguratorBase
    {
        protected override void ConfigureInternal(object target, PropertyInfo property, ConfiguratorPropertyAttribute configuratorPropertyAttr)
        {
            var defaultValue = property.GetValue(target);

            System.Console.WriteLine(configuratorPropertyAttr.SetupQuestion);
            if (defaultValue != null)
            {
                System.Console.WriteLine($"(default={defaultValue}).");
            }

            var convertedValue = ConsoleUtils.ReadObject($"Can not be presented as {property.PropertyType.Name}. Please enter value again.", property.PropertyType);

            property.SetValue(target, convertedValue);
        }
    }
}