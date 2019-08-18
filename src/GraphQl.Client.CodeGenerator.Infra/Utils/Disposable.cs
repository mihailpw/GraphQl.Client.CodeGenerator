using System;

namespace GraphQl.Client.CodeGenerator.Infra.Utils
{
    public sealed class Disposable : IDisposable
    {
        private readonly Action _disposeAction;


        public Disposable(Action disposeAction)
        {
            _disposeAction = disposeAction.VerifyNotNull(nameof(disposeAction));
        }


        public void Dispose()
        {
            _disposeAction();
        }
    }
}