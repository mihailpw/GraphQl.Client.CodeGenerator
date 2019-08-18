using System;
using System.Threading.Tasks;

namespace GraphQl.Client.CodeGenerator.Infra
{
    public interface IGeneratorWriter : IDisposable
    {
        Task WriteAsync(string code);
    }
}