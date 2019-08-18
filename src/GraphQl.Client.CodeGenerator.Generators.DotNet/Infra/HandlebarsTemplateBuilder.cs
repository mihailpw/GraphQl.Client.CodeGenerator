using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GraphQl.Client.CodeGenerator.Generators.DotNet.Helpers;
using GraphQl.Client.CodeGenerator.Infra;
using GraphQl.Client.CodeGenerator.Infra.Exceptions;
using GraphQl.Client.CodeGenerator.Infra.Models.Types;
using HandlebarsDotNet;

namespace GraphQl.Client.CodeGenerator.Generators.DotNet.Infra
{
    public class HandlebarsTemplateBuilder : ITemplateBuilder
    {
        public HandlebarsTemplateBuilder(GeneratorContext context)
        {
            var typeHelper = new DotNetTypeHelper(context.TypeNaming);

            foreach (var methodInfo in typeof(DotNetTypeHelper)
                .GetMethods()
                .Where(m => m
                    .CustomAttributes
                    .Any(a => a.AttributeType == typeof(DotNetTypeHelper.AutoWire))))
            {
                if (methodInfo.ReturnType == typeof(string))
                {
                    Handlebars.RegisterHelper(
                        methodInfo.Name,
                        (output, _, args) => output.Write((string)methodInfo.Invoke(typeHelper, args)));
                }
                else if (methodInfo.ReturnType == typeof(bool))
                {
                    Handlebars.RegisterHelper(
                        methodInfo.Name,
                        (output, opt, ctx, args) =>
                        {
                            if ((bool) methodInfo.Invoke(typeHelper, args))
                            {
                                opt.Template(output, ctx);
                            }
                            else
                            {
                                opt.Inverse(output, ctx);
                            }
                        });
                }
                else
                {
                    throw new GeneratorNotSupportedException($"Auto wire method with return type '{methodInfo.ReturnType.Name}' is not supported.");
                }
            }

            Handlebars.RegisterHelper(
                "resolveDtoName",
                (output, _, args) =>
                {
                    var (first, second) = args.ResolveArguments<GraphQlTypeBase, string>();
                    output.Write(typeHelper.ResolveDtoName(first, second == "true"));
                });

            Handlebars.RegisterHelper(
                "ifKind",
                (output, opt, ctx, args) =>
                {
                    var (first, second) = args.ResolveArgumentsInfinity<GraphQlTypeBase, string>();
                    if (typeHelper.IfKind(first, second))
                    {
                        opt.Template(output, ctx);
                    }
                    else
                    {
                        opt.Inverse(output, ctx);
                    }
                });

            Handlebars.RegisterHelper(
                "withDocs",
                (output, opt, ctx, args) =>
                {
                    if (context.GenerateDocs)
                    {
                        opt.Template(output, ctx);
                    }
                    else
                    {
                        opt.Inverse(output, ctx);
                    }
                });

            Handlebars.RegisterHelper(
                "toPascal",
                (output, _, args) => output.Write(args.ResolveArgument<string>().ToPascal()));

#if DEBUG
            Handlebars.RegisterHelper(
                "debug",
                (output, _, args) => Debugger.Break());
#endif
        }


        public Task<string> BuildAsync(string template, object data, IDictionary<string, string> partials = null)
        {
            if (partials != null)
            {
                foreach (var partial in partials)
                {
                    Handlebars.RegisterTemplate(partial.Key, partial.Value);
                }
            }

            var builder = Handlebars.Compile(template);
            var result = builder(data);

            return Task.FromResult(result);
        }
    }
}