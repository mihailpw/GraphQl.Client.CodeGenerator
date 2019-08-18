using GraphQl.Client.CodeGenerator.Infra;

namespace GraphQl.Client.CodeGenerator.Processor.GeneratorStores
{
    public interface IGeneratorStore
    {
        IGenerator GetGenerator(string name);
    }
}