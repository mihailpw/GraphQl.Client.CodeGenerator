using GraphQl.Client.CodeGenerator.Infra.Models.Types;

namespace GraphQl.Client.CodeGenerator.Infra.Models.Objects
{
    public abstract class GraphQlObjectBase : GraphQlEntityBase
    {
        public GraphQlTypeBase OwnerType { get; set; }
    }
}