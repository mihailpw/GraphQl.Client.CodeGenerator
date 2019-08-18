using System.Collections.Generic;
using GraphQl.Client.CodeGenerator.Infra.Models.Types;

namespace GraphQl.Client.CodeGenerator.Infra.Models
{
    public class GraphQlSchema
    {
        public GraphQlObjectType QueryType { get; set; }

        public GraphQlObjectType MutationType { get; set; }

        public GraphQlObjectType SubscriptionType { get; set; }

        public IReadOnlyList<GraphQlTypeBase> Types { get; set; }


        public GraphQlSchema(
            GraphQlObjectType queryType,
            GraphQlObjectType mutationType,
            GraphQlObjectType subscriptionType,
            IReadOnlyList<GraphQlTypeBase> types)
        {
            QueryType = queryType;
            MutationType = mutationType;
            SubscriptionType = subscriptionType;
            Types = types;
        }
    }
}