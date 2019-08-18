using System;
using GraphQl.Client.CodeGenerator.Infra.Exceptions;
using GraphQl.Client.CodeGenerator.Infra.Models.Objects;
using GraphQl.Client.CodeGenerator.Infra.Models.Types;
using GraphQl.Client.CodeGenerator.Infra.Utils;

namespace GraphQl.Client.CodeGenerator.Generators.DotNet.Helpers
{
    public class DotNetTypeHelper : TypeNamingHelper
    {
        public DotNetTypeHelper(TypeNamingModel typeNamingModel)
            : base(typeNamingModel)
        {
        }


        public override string ResolveDtoName(GraphQlTypeBase type, bool withNullable)
        {
            var nullableSign = withNullable ? "?" : string.Empty;

            switch (type)
            {
                case GraphQlListType listType:
                    return $"List<{ResolveDtoName(listType.OfType, withNullable)}>";
                case GraphQlNonNullType nonNullType:
                    return ResolveDtoName(nonNullType.OfType, true);
                case GraphQlScalarType scalarType:
                    switch (scalarType.Type)
                    {
                        case ScalarTypes.String:
                            return "string";
                        case ScalarTypes.Boolean:
                            return $"{nullableSign}";
                        case ScalarTypes.Float:
                            return $"float{nullableSign}";
                        case ScalarTypes.Int:
                            return $"int{nullableSign}";
                        case ScalarTypes.Id:
                            return "string";
                        case ScalarTypes.Date:
                            return $"DateTime{nullableSign}";
                        case ScalarTypes.DateTime:
                            return $"DateTime{nullableSign}";
                        case ScalarTypes.DateTimeOffset:
                            return $"DateTimeOffset{nullableSign}";
                        case ScalarTypes.Seconds:
                            return $"long{nullableSign}";
                        case ScalarTypes.Milliseconds:
                            return $"long{nullableSign}";
                        case ScalarTypes.Decimal:
                            return $"decimal{nullableSign}";
                        case ScalarTypes.Uri:
                            return "Uri";
                        case ScalarTypes.Guid:
                            return $"Guid{nullableSign}";
                        case ScalarTypes.Short:
                            return $"short{nullableSign}";
                        case ScalarTypes.UShort:
                            return $"ushort{nullableSign}";
                        case ScalarTypes.UInt:
                            return $"uint{nullableSign}";
                        case ScalarTypes.ULong:
                            return $"ulong{nullableSign}";
                        case ScalarTypes.Byte:
                            return $"byte{nullableSign}";
                        case ScalarTypes.SByte:
                            return $"sbyte{nullableSign}";
                        default:
                            throw new GeneratorNotSupportedException($"Scalar type '{scalarType.Type}' is not supported.");
                    }
                default:
                    return base.ResolveDtoName(type, withNullable);
            }
        }

        [AutoWire]
        public override string ResolveGraphQlTypeName(GraphQlTypeBase type)
        {
            return base.ResolveGraphQlTypeName(type);
        }

        [AutoWire]
        public override string ResolveOnTypeMethodName(GraphQlTypeBase type)
        {
            return base.ResolveOnTypeMethodName(type);
        }

        [AutoWire]
        public override string ResolveBuilderName(GraphQlTypeBase type)
        {
            return base.ResolveBuilderName(type);
        }

        [AutoWire]
        public string ResolveDefaultValue(GraphQlInputValue inputValue, string format)
        {
            return inputValue.Type is GraphQlNonNullType
                ? string.Empty
                : string.Format(format, inputValue.DefaultValue ?? "null");
        }

        public bool IfKind(GraphQlTypeBase type, string[] kindValues)
        {
            type = type.GetRealType();

            foreach (var kindValue in kindValues)
            {
                if (!Enum.TryParse<GraphQlKind>(kindValue, true, out var kind))
                {
                    throw new GeneratorNotSupportedException($"Kind '{kindValue}' is not supported.");
                }

                if (type.Kind == kind)
                {
                    return true;
                }
            }

            return false;
        }


        protected override string MakeNullable(string generatedName, GraphQlTypeBase type)
        {
            switch (type.Kind)
            {
                case GraphQlKind.Enum:
                case GraphQlKind.Scalar:
                    return $"{generatedName}?";
                case GraphQlKind.List:
                case GraphQlKind.InputObject:
                case GraphQlKind.Interface:
                case GraphQlKind.Object:
                case GraphQlKind.Union:
                    return generatedName;
                case GraphQlKind.NonNull:
                    throw new GeneratorInvalidOperationException("Non null can not be processed.");
                default:
                    throw new GeneratorNotSupportedException($"Kind '{type.Kind:G}' is not supported.");
            }
        }



        [AttributeUsage(AttributeTargets.Method)]
        public class AutoWire : Attribute { }
    }
}