using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace GraphQl.Client.CodeGenerator.Processor.GeneratorStores
{
    public sealed class FromDirGeneratorStore : FromAssembliesGeneratorStore
    {
        public FromDirGeneratorStore(string dirPath)
            : base(GetAssemblies(dirPath))
        {
        }


        private static IEnumerable<Assembly> GetAssemblies(string dirPath)
        {
            return Directory
                .GetFiles(dirPath, "generator.*.dll")
                .Select(Assembly.LoadFrom);
        }
    }
}