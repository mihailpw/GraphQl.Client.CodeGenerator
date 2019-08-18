using System.Collections.Generic;
using GraphQl.Client.CodeGenerator.Infra.Models.Objects;

namespace GraphQl.Client.CodeGenerator.Infra.Models.Types
{
    public class GraphQlUnionType : GraphQlTypeBase, IGraphQlTypesHolder
    {
        public override GraphQlKind Kind => GraphQlKind.Union;

        public IList<GraphQlTypeBase> PossibleTypes { get; set; }

        public IList<GraphQlField> PossibleFields { get; set; }
    }
}