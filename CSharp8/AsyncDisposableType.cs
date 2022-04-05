using System;
using System.Threading.Tasks;

namespace CSharp8
{
    public sealed class AsyncDisposableType : IAsyncDisposable, IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("Running dispose method...");
        }

        public ValueTask DisposeAsync()
        {
            Console.WriteLine("Running dispose async method...");
            return ValueTask.CompletedTask;
        }
    }
}