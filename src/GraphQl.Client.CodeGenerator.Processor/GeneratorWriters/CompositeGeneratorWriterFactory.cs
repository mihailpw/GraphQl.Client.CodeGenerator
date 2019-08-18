using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQl.Client.CodeGenerator.Infra;

namespace GraphQl.Client.CodeGenerator.Processor.GeneratorWriters
{
    public class CompositeGeneratorWriterFactory : IGeneratorWriterFactory
    {
        private sealed class CompositeGeneratorWriter : IGeneratorWriter
        {
            private readonly IEnumerable<IGeneratorWriter> _generatorWriters;


            public CompositeGeneratorWriter(IEnumerable<IGeneratorWriter> generatorWriters)
            {
                _generatorWriters = generatorWriters;
            }


            public async Task WriteAsync(string code)
            {
                await Task.WhenAll(_generatorWriters.Select(w => w.WriteAsync(code)));
            }

            public void Dispose()
            {
                foreach (var generatorWriter in _generatorWriters)
                {
                    generatorWriter.Dispose();
                }
            }
        }



        private readonly IEnumerable<IGeneratorWriterFactory> _generatorWriterFactories;


        public CompositeGeneratorWriterFactory(IEnumerable<IGeneratorWriterFactory> generatorWriterFactories)
        {
            _generatorWriterFactories = generatorWriterFactories;
        }


        public async Task<IGeneratorWriter> CreateAsync(string name)
        {
            var createWriterTasks = _generatorWriterFactories
                .Select(f => f.CreateAsync(name))
                .ToList();
            await Task.WhenAll(createWriterTasks);

            return new CompositeGeneratorWriter(createWriterTasks.Select(wt => wt.Result));
        }
    }
}