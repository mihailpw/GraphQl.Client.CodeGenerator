using System.Collections.Generic;
using GraphQl.Client.CodeGenerator.Infra.Models.Objects;

namespace GraphQl.Client.CodeGenerator.Infra.Models.Types
{
    public class GraphQlEnumType : GraphQlTypeBase
    {
        public override GraphQlKind Kind => GraphQlKind.Enum;

        public IList<GraphQlEnumValue> EnumValues { get; set; }
    }
}