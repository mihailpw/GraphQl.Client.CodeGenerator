using System;
using System.Collections.Generic;
using System.Reflection;
using GraphQl.Client.CodeGenerator.App.Console.Utils;
using GraphQl.Client.CodeGenerator.Infra.Utils;

namespace GraphQl.Client.CodeGenerator.App.Console.Configuration.Configurators
{
    public class TypeNamingConfigurator : ConfiguratorBase
    {
        private static readonly Dictionary<string, Action<TypeNamingModel, TypeNamingModel.NameEntry>> SetupActions = new Dictionary<string, Action<TypeNamingModel, TypeNamingModel.NameEntry>>
        {
            ["enum dto"] = (tnm, ne) => tnm.DtoEnum = ne,
            ["input object dto"] = (tnm, ne) => tnm.DtoInputObject = ne,
            ["interface dto"] = (tnm, ne) => tnm.DtoInterface = ne,
            ["object dto"] = (tnm, ne) => tnm.DtoObject = ne,
            ["union dto"] = (tnm, ne) => tnm.DtoUnion = ne,
            ["interface builder"] = (tnm, ne) => tnm.BuilderInterface = ne,
            ["object builder"] = (tnm, ne) => tnm.BuilderObject = ne,
            ["union builder"] = (tnm, ne) => tnm.BuilderUnion = ne,
            ["on-type construction"] = (tnm, ne) => tnm.ConstructionOnType = ne,
        };


        protected override void ConfigureInternal(object target, PropertyInfo property, ConfiguratorPropertyAttribute configuratorPropertyAttr)
        {
            var typeNamingModel = new TypeNamingModel();

            foreach (var setupAction in SetupActions)
            {
                if (TryReadEntry(setupAction.Key, out var entry))
                {
                    setupAction.Value(typeNamingModel, entry);
                }
            }

            property.SetValue(target, typeNamingModel);
        }


        private static bool TryReadEntry(string name, out TypeNamingModel.NameEntry entry)
        {
            var requiredRead = ConsoleUtils.ReadYesNoKey($"Do you want to setup {name} name?");
            System.Console.WriteLine();

            if (requiredRead)
            {
                var createdEntry = new TypeNamingModel.NameEntry();
                System.Console.Write("Setup remove regex: ");
                createdEntry.RemoveRegex = ConsoleUtils.ReadObject<string>("Please enter regex again.");
                System.Console.Write("Setup build format: ");
                createdEntry.BuildFormat = ConsoleUtils.ReadObject<string>("Please enter format again.");

                entry = createdEntry;
                return true;
            }
            else
            {
                entry = null;
                return false;
            }
        }
    }
}