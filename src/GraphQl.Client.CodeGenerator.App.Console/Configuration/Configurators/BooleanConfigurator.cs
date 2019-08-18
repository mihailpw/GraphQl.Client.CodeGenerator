using System.Reflection;
using GraphQl.Client.CodeGenerator.App.Console.Utils;

namespace GraphQl.Client.CodeGenerator.App.Console.Configuration.Configurators
{
    public class BooleanConfigurator : ConfiguratorBase
    {
        protected override void ConfigureInternal(object target, PropertyInfo property, ConfiguratorPropertyAttribute configuratorPropertyAttr)
        {
            System.Console.WriteLine($"{configuratorPropertyAttr.SetupQuestion} (y/n)");
            System.Console.Write($"(default={property.GetValue(target)}): ");
            property.SetValue(target, ConsoleUtils.ReadYesNoKey());
            System.Console.WriteLine();
        }
    }
}