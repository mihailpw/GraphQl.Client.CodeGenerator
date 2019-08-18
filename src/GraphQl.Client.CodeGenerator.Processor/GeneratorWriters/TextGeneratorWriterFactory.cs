using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using GraphQl.Client.CodeGenerator.Infra;

namespace GraphQl.Client.CodeGenerator.Processor.GeneratorWriters
{
    public sealed class TextGeneratorWriterFactory : IGeneratorWriterFactory
    {
        private sealed class TextGeneratorWriter : IGeneratorWriter
        {
            private readonly TextWriter _textWriter;
            private readonly string _name;
            private readonly Action _onDisposedAction;


            public TextGeneratorWriter(TextWriter textWriter, string name, Action onDisposedAction)
            {
                _textWriter = textWriter;
                _name = name;
                _onDisposedAction = onDisposedAction;
            }


            public async Task InitializeAsync()
            {
                await _textWriter.WriteLineAsync($"------ start {GetNameText()}------");
            }

            public async Task WriteAsync(string code)
            {
                await _textWriter.WriteLineAsync(code);
            }

            public async void Dispose()
            {
                await _textWriter.WriteLineAsync($"------  end {GetNameText()} ------");
                _onDisposedAction();
            }


            private string GetNameText()
            {
                return string.IsNullOrEmpty(_name)
                    ? string.Empty
                    : $"'{_name}' ";
            }
        }



        private readonly Func<string, TextGeneratorWriter> _writerFactory;
        private readonly SemaphoreSlim _semaphore;


        public TextGeneratorWriterFactory(TextWriter textWriter)
        {
            _writerFactory = t => new TextGeneratorWriter(textWriter, t, () => _semaphore.Release());
            _semaphore = new SemaphoreSlim(1);
        }


        public async Task<IGeneratorWriter> CreateAsync(string name)
        {
            await _semaphore.WaitAsync();
            var writer = _writerFactory(name);
            await writer.InitializeAsync();

            return writer;
        }
    }
}