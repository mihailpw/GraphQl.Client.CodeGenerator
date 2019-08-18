using System.Collections.Generic;
using GraphQl.Client.CodeGenerator.Infra.Models.Objects;

namespace GraphQl.Client.CodeGenerator.Infra.Models.Types
{
    public interface IGraphQlTypesHolder
    {
        IList<GraphQlTypeBase> PossibleTypes { get; set; }

        IList<GraphQlField> PossibleFields { get; set; }
    }
}