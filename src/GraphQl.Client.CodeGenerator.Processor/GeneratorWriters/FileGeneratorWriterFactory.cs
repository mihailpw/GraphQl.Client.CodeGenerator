using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using GraphQl.Client.CodeGenerator.Infra;
using GraphQl.Client.CodeGenerator.Infra.Utils;

namespace GraphQl.Client.CodeGenerator.Processor.GeneratorWriters
{
    public class FileGeneratorWriterFactory : IGeneratorWriterFactory
    {
        private sealed class FileGeneratorWriter : IGeneratorWriter
        {
            private readonly TextWriter _textWriter;
            private readonly Action _onDisposedAction;


            public FileGeneratorWriter(TextWriter textWriter, Action onDisposedAction)
            {
                _textWriter = textWriter;
                _onDisposedAction = onDisposedAction;
            }


            public async Task WriteAsync(string code)
            {
                await _textWriter.WriteLineAsync(code);
            }

            public void Dispose()
            {
                _onDisposedAction();
            }
        }



        private readonly string _folder;
        private readonly Dictionary<string, TextWriter> _textWriters = new Dictionary<string, TextWriter>();


        public FileGeneratorWriterFactory(string folder)
        {
            _folder = folder.VerifyNotNull(nameof(folder));
        }


        public async Task<IGeneratorWriter> CreateAsync(string name)
        {
            await Task.CompletedTask;

            CreateFolderIfNotExists();

            void OnDispose()
            {
                if (_textWriters.ContainsKey(name))
                {
                    _textWriters[name].Dispose();
                    _textWriters.Remove(name);
                }
            }

            if (!_textWriters.ContainsKey(name))
            {
                var path = Path.Combine(_folder, name);
                var fileInfo = new FileInfo(path);
                _textWriters.Add(name, fileInfo.CreateText());
            }

            return new FileGeneratorWriter(_textWriters[name], OnDispose);
        }


        private void CreateFolderIfNotExists()
        {
            if (!Directory.Exists(_folder))
            {
                Directory.CreateDirectory(_folder);
            }
        }
    }
}