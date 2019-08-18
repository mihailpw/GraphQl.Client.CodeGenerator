namespace GraphQl.Client.CodeGenerator.Infra.Models.Types
{
    public class GraphQlNonNullType : GraphQlTypeBase
    {
        public override GraphQlKind Kind => GraphQlKind.NonNull;

        public GraphQlTypeBase OfType { get; set; }
    }
}