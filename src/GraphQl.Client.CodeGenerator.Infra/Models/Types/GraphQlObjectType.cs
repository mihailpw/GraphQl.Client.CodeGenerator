using System.Collections.Generic;
using GraphQl.Client.CodeGenerator.Infra.Models.Objects;

namespace GraphQl.Client.CodeGenerator.Infra.Models.Types
{
    public class GraphQlObjectType : GraphQlTypeBase, IGraphQlFieldsHolder, IGraphQlTypesHolder
    {
        public override GraphQlKind Kind => GraphQlKind.Object;

        public IList<GraphQlField> Fields { get; set; }

        public IList<GraphQlTypeBase> PossibleTypes { get; set; }

        public IList<GraphQlField> PossibleFields { get; set; }
    }
}