using System;
using System.Collections.Generic;
using System.Linq;
using GraphQl.Client.CodeGenerator.Infra.Exceptions;
using GraphQl.Client.CodeGenerator.Infra.Models;
using GraphQl.Client.CodeGenerator.Infra.Models.Objects;
using GraphQl.Client.CodeGenerator.Infra.Models.Types;
using GraphQl.Client.CodeGenerator.Processor.Core;

namespace GraphQl.Client.CodeGenerator.Processor.SchemaReaders
{
    internal class ConvertGraphQlJsonDtoToModelCommand
    {
        public GraphQlSchema Execute(GraphQlJsonDto.Schema dto)
        {
            var types = ConvertToTypesWithRefs(dto.Types).ToList();
            PopulateTypesWithRefs(types);
            PostProcessTypes(types);

            var queryType = SelectObjectType(dto.QueryType, types);
            var mutationType = SelectObjectType(dto.MutationType, types);
            var subscriptionType = SelectObjectType(dto.SubscriptionType, types);

            var objects = types
                .Where(t => t.GetType() != typeof(GraphQlScalarType)
                    && t.Name != queryType?.Name
                    && t.Name != mutationType?.Name
                    && t.Name != subscriptionType?.Name)
                .ToList();

            return new GraphQlSchema(queryType, mutationType, subscriptionType, objects);
        }


        private static IEnumerable<GraphQlTypeBase> ConvertToTypesWithRefs(IEnumerable<GraphQlJsonDto.Type> types)
        {
            GraphQlTypeBase ConvertToTypeRef(GraphQlJsonDto.TypeRef shortType)
            {
                switch (shortType.Kind)
                {
                    case "LIST":
                        return new GraphQlListType
                        {
                            Name = shortType.Name,
                            Description = shortType.Description,
                            OfType = ConvertToTypeRef(shortType.OfType),
                        };
                    case "NON_NULL":
                        return new GraphQlNonNullType
                        {
                            Name = shortType.Name,
                            Description = shortType.Description,
                            OfType = ConvertToTypeRef(shortType.OfType),
                        };
                    default:
                        return new TypeRef(shortType.Name);
                }

            }
            IList<GraphQlTypeBase> ConvertToTypeRefs(IEnumerable<GraphQlJsonDto.TypeRef> shortTypes)
            {
                if (shortTypes == null)
                {
                    return Array.Empty<GraphQlTypeBase>();
                }

                return shortTypes
                    .Select(ConvertToTypeRef)
                    .ToList();
            }
            IList<GraphQlInputValue> ConvertToInputValues(IEnumerable<GraphQlJsonDto.InputValue> inputValues)
            {
                if (inputValues == null)
                {
                    return Array.Empty<GraphQlInputValue>();
                }

                return inputValues
                    .Select(f => new GraphQlInputValue
                    {
                        Name = f.Name,
                        Description = f.Description,
                        Type = ConvertToTypeRef(f.Type),
                        DefaultValue = f.DefaultValue,
                    })
                    .ToList();
            }
            IList<GraphQlField> ConvertToFields(IEnumerable<GraphQlJsonDto.Field> fields)
            {
                if (fields == null)
                {
                    return Array.Empty<GraphQlField>();
                }

                return fields
                    .Select(f => new GraphQlField
                    {
                        Name = f.Name,
                        Description = f.Description,
                        IsDeprecated = f.IsDeprecated,
                        DeprecationReason = f.DeprecationReason,
                        Type = ConvertToTypeRef(f.Type),
                        Args = ConvertToInputValues(f.Args),
                    })
                    .ToList();
            }
            IList<GraphQlEnumValue> ConvertToEnumValues(IEnumerable<GraphQlJsonDto.EnumValue> fields)
            {
                if (fields == null)
                {
                    return Array.Empty<GraphQlEnumValue>();
                }

                return fields
                    .Select(f => new GraphQlEnumValue
                    {
                        Name = f.Name,
                        Description = f.Description,
                        IsDeprecated = f.IsDeprecated,
                        DeprecationReason = f.DeprecationReason,
                    })
                    .ToList();
            }

            foreach (var type in types)
            {
                if (CheckIfSystemType(type))
                {
                    continue;
                }

                switch (type.Kind)
                {
                    case "SCALAR":
                        if (Enum.TryParse<ScalarTypes>(type.Name, true, out var scalarType))
                        {
                            yield return new GraphQlScalarType
                            {
                                Name = type.Name,
                                Description = type.Description,
                                Type = scalarType,
                            };
                        }
                        else
                        {
                            throw new GeneratorNotSupportedException($"Scalar type '{type.Name}' is not supported.");
                        }
                        break;
                    case "OBJECT":
                        yield return new GraphQlObjectType
                        {
                            Name = type.Name,
                            Description = type.Description,
                            Fields = ConvertToFields(type.Fields),
                            PossibleTypes = ConvertToTypeRefs(type.PossibleTypes),
                        };
                        break;
                    case "INTERFACE":
                        yield return new GraphQlInterfaceType
                        {
                            Name = type.Name,
                            Description = type.Description,
                            Fields = ConvertToFields(type.Fields),
                            PossibleTypes = ConvertToTypeRefs(type.PossibleTypes),
                        };
                        break;
                    case "UNION":
                        yield return new GraphQlUnionType
                        {
                            Name = type.Name,
                            Description = type.Description,
                            PossibleTypes = ConvertToTypeRefs(type.PossibleTypes),
                        };
                        break;
                    case "ENUM":
                        yield return new GraphQlEnumType
                        {
                            Name = type.Name,
                            Description = type.Description,
                            EnumValues = ConvertToEnumValues(type.EnumValues),
                        };
                        break;
                    case "INPUT_OBJECT":
                        yield return new GraphQlInputObjectType
                        {
                            Name = type.Name,
                            Description = type.Description,
                            InputFields = ConvertToInputValues(type.InputFields),
                        };
                        break;
                    case "LIST":
                    case "NON_NULL":
                        throw new GeneratorInvalidOperationException($"Kind '{type.Kind}' is not allowed here.");
                    default:
                        throw new GeneratorNotSupportedException($"Kind '{type.Kind}' is not supported.");
                }
            }
        }

        private static void PopulateTypesWithRefs(IReadOnlyCollection<GraphQlTypeBase> types)
        {
            IList<GraphQlTypeBase> LockupList(IEnumerable<GraphQlTypeBase> typeBases)
            {
                return typeBases.Select(Lockup).ToList();
            }
            GraphQlTypeBase Lockup(GraphQlTypeBase typeBase)
            {
                switch (typeBase)
                {
                    case GraphQlListType listType:
                        listType.OfType = Lockup(listType.OfType);
                        return listType;
                    case GraphQlNonNullType nonNullType:
                        nonNullType.OfType = Lockup(nonNullType.OfType);
                        return nonNullType;
                    case TypeRef typeRef:
                        var lockupType = types.SingleOrDefault(t => t.Name == typeRef.Name);
                        switch (lockupType)
                        {
                            case null:
                                throw new GeneratorInvalidOperationException($"Ref '{typeRef.Name}' not found.");
                            case TypeRef _:
                                throw new GeneratorInvalidOperationException($"Something gone wrong. {nameof(TypeRef)} could not be here.");
                            default:
                                return lockupType;
                        }
                    default:
                        return typeBase;
                }
            }

            void PopulateInputValues(IEnumerable<GraphQlInputValue> inputValues)
            {
                foreach (var inputValue in inputValues)
                {
                    inputValue.Type = Lockup(inputValue.Type);
                }
            }
            void PopulateFields(IEnumerable<GraphQlField> fields)
            {
                foreach (var field in fields)
                {
                    field.Type = Lockup(field.Type);
                    PopulateInputValues(field.Args);
                }
            }

            foreach (var type in types)
            {
                switch (type)
                {
                    case GraphQlInputObjectType inputObjectType:
                        PopulateInputValues(inputObjectType.InputFields);
                        break;
                    case GraphQlInterfaceType interfaceType:
                        PopulateFields(interfaceType.Fields);
                        interfaceType.PossibleTypes = LockupList(interfaceType.PossibleTypes);
                        break;
                    case GraphQlObjectType objectType:
                        PopulateFields(objectType.Fields);
                        objectType.PossibleTypes = LockupList(objectType.PossibleTypes);
                        break;
                    case GraphQlUnionType unionType:
                        unionType.PossibleTypes = LockupList(unionType.PossibleTypes);
                        break;
                    case GraphQlListType _:
                    case GraphQlNonNullType _:
                        throw new GeneratorNotSupportedException($"Type '{type.GetType().Name}' is not allowed here.");
                }
            }
        }

        private static void PostProcessTypes(IEnumerable<GraphQlTypeBase> types)
        {
            void SetOwnerToInputValues(GraphQlTypeBase ownerType, IEnumerable<GraphQlInputValue> inputValues)
            {
                foreach (var inputValue in inputValues)
                {
                    inputValue.OwnerType = ownerType;
                }
            }
            void SetOwnerToFields(GraphQlTypeBase ownerType, IEnumerable<GraphQlField> fields)
            {
                foreach (var field in fields)
                {
                    field.OwnerType = ownerType;
                    SetOwnerToInputValues(ownerType, field.Args);
                }
            }
            void SetOwnerToEnumValues(GraphQlTypeBase ownerType, IEnumerable<GraphQlEnumValue> enumValues)
            {
                foreach (var enumValue in enumValues)
                {
                    enumValue.OwnerType = ownerType;
                }
            }
            void TrySetupPossibleTypes(GraphQlTypeBase type)
            {
                if (!(type is IGraphQlTypesHolder typesHolder))
                {
                    return;
                }

                var possibleFields = typesHolder.PossibleTypes
                    .OfType<IGraphQlFieldsHolder>()
                    .SelectMany(t => t.Fields)
                    .DistinctBy(t => t.Name);

                if (type is IGraphQlFieldsHolder fieldsHolder)
                {
                    possibleFields = possibleFields
                        .Where(pf => fieldsHolder.Fields
                            .All(f => f.Name != pf.Name));
                }

                typesHolder.PossibleFields = possibleFields.ToList();
            }
            IList<GraphQlInputValue> SortNonNullFirst(IEnumerable<GraphQlInputValue> values)
            {
                return values.OrderBy(v => !(v.Type is GraphQlNonNullType)).ToList();
            }
            void SortNonNullFirstInFields(IEnumerable<GraphQlField> fields)
            {
                foreach (var field in fields)
                {
                    field.Args = SortNonNullFirst(field.Args);
                }
            }

            foreach (var type in types)
            {
                TrySetupPossibleTypes(type);

                switch (type)
                {
                    case GraphQlEnumType enumType:
                        SetOwnerToEnumValues(enumType, enumType.EnumValues);
                        break;
                    case GraphQlInputObjectType inputObjectType:
                        SetOwnerToInputValues(inputObjectType, inputObjectType.InputFields);
                        inputObjectType.InputFields = SortNonNullFirst(inputObjectType.InputFields);
                        break;
                    case GraphQlInterfaceType interfaceType:
                        SetOwnerToFields(interfaceType, interfaceType.Fields);
                        SortNonNullFirstInFields(interfaceType.Fields);
                        break;
                    case GraphQlObjectType objectType:
                        SetOwnerToFields(objectType, objectType.Fields);
                        SortNonNullFirstInFields(objectType.Fields);
                        break;
                }
            }
        }


        private static GraphQlObjectType SelectObjectType(GraphQlJsonDto.TypeRef typeRef, IEnumerable<GraphQlTypeBase> types)
        {
            if (typeRef == null)
            {
                return null;
            }

            return (GraphQlObjectType) types.Single(t => t.Name == typeRef.Name);
        }

        private static bool CheckIfSystemType(GraphQlJsonDto.Type type)
        {
            return type.Name.StartsWith("__");
        }



        private class TypeRef : GraphQlTypeBase
        {
            public override GraphQlKind Kind => 0;


            public TypeRef(string name)
            {
                Name = name;
            }
        }
    }
}