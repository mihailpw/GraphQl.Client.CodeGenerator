@echo off 

set buildoutdir=out
set nugetoutdir=nuget-out

rmdir %buildoutdir% /Q /S nonemptydir
rmdir %nugetoutdir% /Q /S nonemptydir

dotnet publish "../src/GraphQl.Client.CodeGenerator.App.Console/GraphQl.Client.CodeGenerator.App.Console.csproj" -o "%buildoutdir%/build" -c Release
del "%buildoutdir%\*.pdb" /s /f /q
del "%buildoutdir%\graphql-config.json" /s /f /q

mkdir %nugetoutdir%

nuget pack GraphQl.Client.CodeGenerator.MSBuild.nuspec -OutputDirectory %nugetoutdir%