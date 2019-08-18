using System.Collections.Generic;
using GraphQl.Client.CodeGenerator.Infra.Models.Types;

namespace GraphQl.Client.CodeGenerator.Infra.Models.Objects
{
    public class GraphQlField : GraphQlDeprecatableObjectBase
    {
        public GraphQlTypeBase Type { get; set; }

        public IList<GraphQlInputValue> Args { get; set; }
    }
}