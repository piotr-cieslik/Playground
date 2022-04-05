using System;
using System.Threading.Tasks;

namespace CSharp8
{
    public static class Program
    {
        // C# 8 playground
        // https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8
        public static async Task Main()
        {
            Console.WriteLine("Switch expression");
            Console.WriteLine(PatternMatching.SwitchExpression(Color.Red));
            Console.WriteLine();

            Console.WriteLine("Property patterns");
            Console.WriteLine(PatternMatching.PropertyPatterns(new Point(1, 1)));
            Console.WriteLine(PatternMatching.PropertyPatterns(new Point(10, 1)));
            Console.WriteLine();

            Console.WriteLine("Tuple patterns");
            Console.WriteLine(PatternMatching.TuplePatterns(new Point(1, 1), Color.Green));
            Console.WriteLine(PatternMatching.TuplePatterns(new Point(10, 1), Color.Red));
            Console.WriteLine();

            string @string = null;
            Console.WriteLine(@string);

            using (var disposable = new AsyncDisposableType())
            {
                Console.WriteLine("Disposable block.");
            }

            await using (var disposable = new AsyncDisposableType())
            {
                Console.WriteLine("Disposable async block.");
            }
        }
    }
}