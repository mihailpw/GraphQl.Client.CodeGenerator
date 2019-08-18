using System.Collections.Generic;
using GraphQl.Client.CodeGenerator.Infra.Utils;

namespace GraphQl.Client.CodeGenerator.Infra
{
    public class GeneratorContext
    {
        public string WriterName { get; set; }

        public string Namespace { get; set; } = "GraphQlClient";

        public string MainClientFactoryClassName { get; set; } = "AppClientFactory";

        public IList<string> AdditionalClientUsing { get; set; } = new List<string>();

        public bool GenerateDocs { get; set; } = false;

        public bool GenerateInputObjectConstructor { get; set; } = false;

        public TypeNamingModel TypeNaming { get; set; } = new TypeNamingModel();
    }
}