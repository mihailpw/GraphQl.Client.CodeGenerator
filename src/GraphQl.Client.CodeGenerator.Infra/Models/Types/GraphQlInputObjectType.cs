using System.Collections.Generic;
using GraphQl.Client.CodeGenerator.Infra.Models.Objects;

namespace GraphQl.Client.CodeGenerator.Infra.Models.Types
{
    public class GraphQlInputObjectType : GraphQlTypeBase
    {
        public override GraphQlKind Kind => GraphQlKind.InputObject;

        public IList<GraphQlInputValue> InputFields { get; set; }
    }
}