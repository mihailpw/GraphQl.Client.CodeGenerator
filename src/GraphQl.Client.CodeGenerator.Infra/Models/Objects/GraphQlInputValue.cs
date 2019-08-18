using GraphQl.Client.CodeGenerator.Infra.Models.Types;

namespace GraphQl.Client.CodeGenerator.Infra.Models.Objects
{
    public class GraphQlInputValue : GraphQlObjectBase
    {
        public GraphQlTypeBase Type { get; set; }

        public string DefaultValue { get; set; }
    }
}