using System;
using System.Collections.Generic;
using CommandLine;

namespace GraphQl.Client.CodeGenerator.App.Console
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            System.Console.Title = "GraphQL Client Code Generator";

            var parser = new Parser(o =>
            {
                o.AutoHelp = true;
                o.AutoVersion = false;
                o.IgnoreUnknownArguments = true;
                o.HelpWriter = System.Console.Out;
            });

            parser.ParseArguments<ConsoleOptions>(args)
                .WithParsed(GenerateClient)
                .WithNotParsed(HandleErrors);
        }


        private static void GenerateClient(ConsoleOptions options)
        {
            try
            {
                ClientGeneration.GenerateClientAsync(options).Wait();
            }
            catch (Exception e)
            {
                var exception = e.InnerException ?? e;

                System.Console.WriteLine(
#if DEBUG
                    exception
#else
                   $"Error: {exception.Message}"
#endif
                );

                Environment.ExitCode = -1;
            }
        }

        private static void HandleErrors(IEnumerable<Error> errors)
        {
            System.Console.WriteLine("Arguments parsing errors.");
            Environment.ExitCode = -1;
        }
    }
}
