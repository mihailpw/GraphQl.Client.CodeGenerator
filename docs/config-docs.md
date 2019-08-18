## GraphQL Client Code Generator

[< back](./index)

### Config docs

`schemaUri` (`string`) - uri of GraphQL schema.

`generator` (`string`) - generator name. Currently supported: `dotnetcore`.

`name` (`string`) - name of generation. In case if `outputToFolder=true` file will be saved with current name. Default value `Generated.cs`.

`innerLevelOfType` (`int`) - inner level of-type construction. Default value `4`.

`outputToFolder` (`bool`) - specify should generated text save to file. Default value `true`.

`outputFolderPath` (`string`) - path of folder to save file. Default value `./`.

`outputToConsole` (`bool`) - specify should generated text shown to console. Default value `false`.

`namespace` (`string`) - specify namespace of generated classes. Default value `GraphQlClient`.

`mainClientFactoryClassName` (`string`) - specify class name of client factory. Default value `AppClientFactory`.

`generateDocs` (`bool`) - specify should docs generated in classes. Default value `false`.

`generateInputObjectConstructor` (`bool`) - specify should constructor generated in input type DTOs. Default value `true`.

`typeNaming`(`object`) - specify type names modification during generation. All entries (will call `Entry`) have `removeRegex` (specifies regex pattern to remove text of type's name) and `buildFormat` (specifies format of new type's name) fields. `typeNaming` includes:

- `dtoEnum` (`Entry`) - update names rule for DTO of GraphQL enum type.
- `dtoInputObject` (`Entry`) - update names rule for DTO of GraphQL input object type.
- `dtoInterface` (`Entry`) - update names rule for DTO of GraphQL interface type.
- `dtoObject` (`Entry`) - update names rule for DTO of GraphQL object type.
- `dtoUnion` (`Entry`) - update names rule for DTO of GraphQL union type.
- `builderInterface` (`Entry`) - update names rule for builder of GraphQL interface type.
- `builderObject` (`Entry`) - update names rule for builder of GraphQL object type.
- `builderUnion` (`Entry`) - update names rule for builder of GraphQL union type.
- `constructionOnType` (`Entry`) - update names rule for on-type construction in generation of interfaces' methods.