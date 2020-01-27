namespace Activator
{
    public class Program
    {
        static void Main()
        {
            var a1 = new A1();
            var b1 = new B1();
            var b2 = new B2();

            // works
            var a =
                System.Activator.CreateInstance(
                    type: typeof(A),
                    args: new object[] { a1 });

            // works
            var b =
                System.Activator.CreateInstance(
                    type: typeof(B),
                    args: new object[] { b1, b2 });

            // does not work
            var aa =
                System.Activator.CreateInstance(
                    type: typeof(A),
                    args: new object[] { a1, b1, b2 });
        }
    }

    public class A
    {
        public A(A1 a1)
        {
        }
    }

    public class A1
    {
    }

    public class B
    {
        public B(B1 b1, B2 b2)
        {
        }
    }

    public class B1
    {
    }

    public class B2
    {
    }
}
