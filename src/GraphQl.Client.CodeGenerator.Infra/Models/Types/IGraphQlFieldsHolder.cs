using System.Collections.Generic;
using GraphQl.Client.CodeGenerator.Infra.Models.Objects;

namespace GraphQl.Client.CodeGenerator.Infra.Models.Types
{
    public interface IGraphQlFieldsHolder
    {
        IList<GraphQlField> Fields { get; set; }
    }
}