using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace GraphQl.Client.CodeGenerator.Processor.SchemaReaders
{
    internal class GraphQlJsonDto
    {
        public static string RetrieveSchemaQuery(int innerLevelOfType)
        {
            string WrapTypeRefRequest()
            {
                const string ofTypeRequest =
@"ofType {{
  kind
  name
  {0}
}}";
                var result = string.Empty;

                for (var i = 0; i < innerLevelOfType - 1; i++)
                {
                    result = string.Format(ofTypeRequest, result);
                }

                return result;
            }

            var shortType = WrapTypeRefRequest();

            var request =
@"query IntrospectionQuery {
  __schema {
    queryType {
      name
    }
    mutationType {
      name
    }
    subscriptionType {
      name
    }
    types {
      ...Type
    }
  }
}

fragment TypeRef on __Type {
  kind
  name
  " + shortType + @"
}

fragment Type on __Type {
  kind
  name
  description
  ofType {
    ...TypeRef
  }
  fields(includeDeprecated: true) {
    ...Field
  }
  inputFields {
    ...InputValue
  }
  interfaces {
    ...TypeRef
  }
  enumValues(includeDeprecated: true) {
    ...EnumValue
  }
  possibleTypes {
    ...TypeRef
  }
}

fragment Field on __Field {
  name
  description
  args {
    ...InputValue
  }
  type {
    ...TypeRef
  }
  isDeprecated
  deprecationReason
}

fragment InputValue on __InputValue {
  name
  description
  type {
    ...TypeRef
  }
  defaultValue
}

fragment EnumValue on __EnumValue {
  name
  description
  isDeprecated
  deprecationReason
}";

            return Regex.Replace(request, "[\r\n ]+", " ");
        }



        public class Schema
        {
            public TypeRef QueryType { get; set; }
            public TypeRef MutationType { get; set; }
            public TypeRef SubscriptionType { get; set; }
            public List<Type> Types { get; set; }
        }

        public class TypeRef
        {
            public string Kind { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public TypeRef OfType { get; set; }
        }

        public class Type
        {
            public string Kind { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public List<Field> Fields { get; set; }
            public List<InputValue> InputFields { get; set; }
            public List<TypeRef> Interfaces { get; set; }
            public List<EnumValue> EnumValues { get; set; }
            public List<TypeRef> PossibleTypes { get; set; }
        }

        public class Field
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public List<InputValue> Args { get; set; }
            public TypeRef Type { get; set; }
            public bool IsDeprecated { get; set; }
            public string DeprecationReason { get; set; }
        }

        public class InputValue
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public TypeRef Type { get; set; }
            public string DefaultValue { get; set; }
        }

        public class EnumValue
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public bool IsDeprecated { get; set; }
            public string DeprecationReason { get; set; }
        }
    }
}