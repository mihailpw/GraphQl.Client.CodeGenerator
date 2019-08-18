## GraphQL Client Code Generator

[< back](./index)

### DotNetCore sample

Create separate project for API calling. I'll name it `GQLS.ApiClient`.

Install GraphQL Client Code Generator using nuget package ([docs](./installation)). Add build event to project for autogenerating in case of rebuild:

``` xml
<Target Name="PreBuild" BeforeTargets="PreBuildEvent">
  <Exec Command="$(GqlccgExe_x64) run /variables:Configuration=$(Configuration)" />
</Target>
```

Make sure you set exe file name correctly.

Next step is to create config file. Please, read [docs](./config-docs) and use [config creator](./config-create). Also you can create initial config json file if run generator with `--config-create` command line argument.

If your config file doesn't located the same folder with generator and/or named different from `config.json` - you have to specify config path for generator with `--config "file_path/file_name.json"` command line argument.

Current generator depends on [`GraphQL.Client`](https://github.com/graphql-dotnet/graphql-client) library. You can install this library run in Package Manager Console following command:

```
Install-Package GraphQL.Client -Version 2.0.0-alpha.3
```

Please, make sure you install GraphQL.Client version 2+.

After that you can build your project.

Now you can use it!

Sample code available on [GitHub](https://github.com/mihailpw/GraphQlClientCodeGenerator/tree/master/sample/dotnetcore).

