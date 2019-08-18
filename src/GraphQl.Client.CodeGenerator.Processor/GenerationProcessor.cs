using System.Threading.Tasks;
using GraphQl.Client.CodeGenerator.Infra;
using GraphQl.Client.CodeGenerator.Infra.Utils;
using GraphQl.Client.CodeGenerator.Processor.GeneratorStores;
using GraphQl.Client.CodeGenerator.Processor.SchemaReaders;

namespace GraphQl.Client.CodeGenerator.Processor
{
    public class GenerationProcessor
    {
        private readonly IGeneratorStore _generatorStore;
        private readonly ISchemaReader _schemaReader;
        private readonly IGeneratorWriterFactory _generatorWriterFactory;


        public GenerationProcessor(
            IGeneratorStore generatorStore,
            ISchemaReader schemaReader,
            IGeneratorWriterFactory generatorWriterFactory)
        {
            _generatorStore = generatorStore.VerifyNotNull(nameof(generatorStore));
            _schemaReader = schemaReader.VerifyNotNull(nameof(schemaReader));
            _generatorWriterFactory = generatorWriterFactory.VerifyNotNull(nameof(generatorWriterFactory));
        }


        public async Task ProcessAsync(string generatorName, GeneratorContext context)
        {
            var generator = _generatorStore.GetGenerator(generatorName);
            var schema = await _schemaReader.LoadSchemaDataAsync();
            await generator.GenerateAsync(schema, _generatorWriterFactory, context);
        }
    }
}