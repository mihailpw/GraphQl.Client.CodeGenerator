namespace GraphQl.Client.CodeGenerator.Infra.Models.Types
{
    public abstract class GraphQlTypeBase : GraphQlEntityBase
    {
        public abstract GraphQlKind Kind { get; }
    }
}