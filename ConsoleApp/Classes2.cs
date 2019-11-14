using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Classes2
    {
        internal class A
        {
            public virtual void Foo()
            {
                Console.Write("Class A");
            }
        }
        internal class B : A
        {
            public override void Foo()
            {
                Console.Write("Class B");
            }
        }

        public struct S : IDisposable
        {
            private bool dispose;
            public void Dispose()
            {
                dispose = true;
            }
            public bool GetDispose()
            {
                return dispose;
            }
        }
        
        public class A7
        {
            public A7()
            {
                V = "<a ";
            }
            public virtual void PrintV()
            {
                Console.Write(V);
            }
            public string V;

            public virtual void Print1()
            {
                Console.Write("A");
            }
            public void Print2()
            {
                Console.Write("A");
            }
        }
        public class B7 : A7
        {
            public B7()
            {
                V = "<b ";
            }

            public override void Print1()
            {
                Console.Write("B");
            }
        }
        public class C7 : B7
        {
            public C7()
            {
                V = "<c ";
            }

            public override void Print1()
            {
                Console.Write("C");
            }

            public new void Print2()
            {
                Console.Write("C");
            }
        }

        public class Wrap
        {
            private static int init = 0;
            public int Value
            {
                get
                {
                    return ++init;
                }
            }
        }

        public class MyCustomException : DivideByZeroException
        {

        }

        public class A33
        {
            public void OnDoWork()
            {
                DoWork?.Invoke(this, EventArgs.Empty);
            }

            public event EventHandler DoWork;
        }

    }
}
