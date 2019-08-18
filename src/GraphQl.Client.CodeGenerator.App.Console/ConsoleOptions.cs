using CommandLine;

namespace GraphQl.Client.CodeGenerator.App.Console
{
    internal sealed class ConsoleOptions
    {
        [Option("working-dir", Required = false, HelpText = "Working directory path.", Default = null)]
        public string WorkingDir { get; set; }

        [Option('c', "config", Required = false, HelpText = "Config file path.", Default = "graphql-config.json")]
        public string Config { get; set; }

        [Option("config-create", Required = false, HelpText = "Setup config file.", Default = false)]
        public bool ConfigCreate { get; set; }
    }
}