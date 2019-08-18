using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GraphQl.Client.CodeGenerator.Infra;

namespace GraphQl.Client.CodeGenerator.Processor.GeneratorStores
{
    public class FromAssembliesGeneratorStore : IGeneratorStore
    {
        private readonly Dictionary<string, IGenerator> _generators;


        public FromAssembliesGeneratorStore(IEnumerable<Assembly> assemblies)
        {
            _generators = FindAllGenerators(assemblies);
        }


        public IGenerator GetGenerator(string name)
        {
            if (!_generators.ContainsKey(name))
            {
                throw new GeneratorNotFoundException(name, _generators.Keys);
            }

            return _generators[name];
        }


        private static Dictionary<string, IGenerator> FindAllGenerators(IEnumerable<Assembly> assemblies)
        {
            return assemblies
                .SelectMany(a => a.DefinedTypes)
                .Where(t =>
                    t.CustomAttributes.Count(a => a.AttributeType == typeof(GeneratorAttribute)) == 1
                    && t.ImplementedInterfaces.Contains(typeof(IGenerator)))
                .ToDictionary(
                    t => t.GetCustomAttribute<GeneratorAttribute>().Name,
                    t => (IGenerator) Activator.CreateInstance(t));
        }
    }
}