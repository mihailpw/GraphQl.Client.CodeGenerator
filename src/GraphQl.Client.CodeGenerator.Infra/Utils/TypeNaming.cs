using System.Text.RegularExpressions;
using GraphQl.Client.CodeGenerator.Infra.Exceptions;
using GraphQl.Client.CodeGenerator.Infra.Models.Types;

namespace GraphQl.Client.CodeGenerator.Infra.Utils
{
    public class TypeNamingModel
    {
        public NameEntry DtoEnum { get; set; } = new NameEntry { RemoveRegex = "Type", BuildFormat = "{0}Enum" };
        public NameEntry DtoInputObject { get; set; } = new NameEntry { RemoveRegex = "Type", BuildFormat = "{0}Dto" };
        public NameEntry DtoInterface { get; set; } = new NameEntry { RemoveRegex = "Type", BuildFormat = "{0}Dto" };
        public NameEntry DtoObject { get; set; } = new NameEntry { RemoveRegex = "Type", BuildFormat = "{0}Dto" };
        public NameEntry DtoUnion { get; set; } = new NameEntry { RemoveRegex = "Type", BuildFormat = "{0}Dto" };

        public NameEntry BuilderInterface { get; set; } = new NameEntry { RemoveRegex = "Type", BuildFormat = "{0}Builder" };
        public NameEntry BuilderObject { get; set; } = new NameEntry { RemoveRegex = "Type", BuildFormat = "{0}Builder" };
        public NameEntry BuilderUnion { get; set; } = new NameEntry { RemoveRegex = "Type", BuildFormat = "{0}Builder" };

        public NameEntry ConstructionOnType { get; set; } = new NameEntry { RemoveRegex = "Type", BuildFormat = "On{0}" };



        public class NameEntry
        {
            public string RemoveRegex { get; set; }
            public string BuildFormat { get; set; }
        }
    }

    public abstract class TypeNamingHelper
    {
        private readonly TypeNamingModel _typeNamingModel;


        protected TypeNamingHelper(TypeNamingModel typeNamingModel)
        {
            _typeNamingModel = typeNamingModel;
        }


        public virtual string ResolveDtoName(GraphQlTypeBase type, bool withNullable)
        {
            TypeNamingModel.NameEntry entry;

            switch (type)
            {
                case GraphQlEnumType _:
                    entry = _typeNamingModel.DtoEnum;
                    break;
                case GraphQlInputObjectType _:
                    entry = _typeNamingModel.DtoInputObject;
                    break;
                case GraphQlInterfaceType _:
                    entry = _typeNamingModel.DtoInterface;
                    break;
                case GraphQlObjectType _:
                    entry = _typeNamingModel.DtoObject;
                    break;
                case GraphQlUnionType _:
                    entry = _typeNamingModel.DtoUnion;
                    break;
                default:
                    throw new GeneratorNotSupportedException($"Type {type.Kind:G} can not be dto.");
            }

            return ProcessName(type, entry, withNullable);
        }

        public virtual string ResolveGraphQlTypeName(GraphQlTypeBase type)
        {
            switch (type)
            {
                case GraphQlListType listType:
                    return $"[{ResolveGraphQlTypeName(listType.OfType)}]";
                case GraphQlNonNullType nonNullType:
                    return $"{ResolveGraphQlTypeName(nonNullType.OfType)}!";
                default:
                    return type.Name;
            }
        }

        public virtual string ResolveBuilderName(GraphQlTypeBase type)
        {
            type = type.GetRealType();

            TypeNamingModel.NameEntry entry;

            switch (type)
            {
                case GraphQlInterfaceType _:
                    entry = _typeNamingModel.BuilderInterface;
                    break;
                case GraphQlObjectType _:
                    entry = _typeNamingModel.BuilderObject;
                    break;
                case GraphQlUnionType _:
                    entry = _typeNamingModel.BuilderUnion;
                    break;
                default:
                    throw new GeneratorInvalidOperationException($"Type {type.Kind:G} can not be a builder.");
            }

            return ProcessName(type, entry);
        }

        public virtual string ResolveOnTypeMethodName(GraphQlTypeBase type)
        {
            return ProcessName(type.GetRealType(), _typeNamingModel.ConstructionOnType);
        }


        protected abstract string MakeNullable(string generatedName, GraphQlTypeBase type);


        private string ProcessName(GraphQlTypeBase type, TypeNamingModel.NameEntry entry, bool isNullable = false)
        {
            var result = type.Name;

            if (entry != null)
            {
                if (!string.IsNullOrEmpty(entry.RemoveRegex))
                {
                    result = Regex.Replace(result, entry.RemoveRegex, string.Empty);
                }

                if (entry.BuildFormat.Contains("{0}"))
                {
                    result = string.Format(entry.BuildFormat, result);
                }

                if (isNullable)
                {
                    result = MakeNullable(result, type);
                }
            }

            return result;
        }
    }
}