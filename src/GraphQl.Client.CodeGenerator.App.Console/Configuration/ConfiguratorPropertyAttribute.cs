using System;
using GraphQl.Client.CodeGenerator.App.Console.Configuration.Configurators;

namespace GraphQl.Client.CodeGenerator.App.Console.Configuration
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ConfiguratorPropertyAttribute : Attribute
    {
        public string SetupQuestion { get; }

        public object[] SupportedValues { get; }

        public Type ConfiguratorType { get; set; } = typeof(DefaultConfigurator);


        public ConfiguratorPropertyAttribute(
            string setupQuestion,
            params object[] supportedValues)
        {
            SetupQuestion = setupQuestion;
            SupportedValues = supportedValues;
        }
    }
}