using System;

namespace GraphQl.Client.CodeGenerator.Infra
{
    [AttributeUsage(AttributeTargets.Class)]
    public class GeneratorAttribute : Attribute
    {
        public string Name { get; }


        public GeneratorAttribute(string name)
        {
            Name = name;
        }
    }
}