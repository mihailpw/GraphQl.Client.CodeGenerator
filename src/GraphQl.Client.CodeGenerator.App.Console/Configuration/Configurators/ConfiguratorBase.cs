using System.Reflection;
using GraphQl.Client.CodeGenerator.App.Console.Utils;

namespace GraphQl.Client.CodeGenerator.App.Console.Configuration.Configurators
{
    public abstract class ConfiguratorBase
    {
        public void Configure(object target, PropertyInfo property, ConfiguratorPropertyAttribute configuratorProperty)
        {
            var shouldConfigure = true;

            if (configuratorProperty is OptionalConfiguratorPropertyAttribute optionalConfiguratorProperty)
            {
                shouldConfigure = ConsoleUtils.ReadYesNoKey(optionalConfiguratorProperty.OptionalQuestion);
                System.Console.WriteLine();
            }

            if (shouldConfigure)
            {
                ConfigureInternal(target, property, configuratorProperty);
            }
        }


        protected abstract void ConfigureInternal(
            object target,
            PropertyInfo property,
            ConfiguratorPropertyAttribute configuratorPropertyAttr);
    }
}