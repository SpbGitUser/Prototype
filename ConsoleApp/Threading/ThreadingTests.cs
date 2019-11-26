using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp.Threading
{
    internal class ThreadingTests
    {
        internal static void RunThreading()
        {
            //Test1();
            //Test2();
            Test3();
            Test4();
            Test5();
            Test6();
            Test7();
            Test8();
            Test9();
            //Test();
            //Test();
            //Test();
            //Test();
            //Test();
            //Test();
            //Test();
            //Test();
            //Test();
            //Test();
            //Test();
            //Test();
            //Test();
            //Test();
            //Test();
            //Test();
            //Test();
            //Test();
            //Test();
            //Test();
            //Test();
            //Test();
            //Test();
            //Test();
            //Test();
            //Test();
            //Test();
            //Test();
            //Test();
            //Test();
        }

        // ОБРАТИ ВНИМАНИЕ!!!! === ОБРАТИ ВНИМАНИЕ!!!! === ОБРАТИ ВНИМАНИЕ!!!!
        //W("------------------------------------");
        //private static void Test() {}

        static bool done;    // Статическое поле, разделяемое потоками
        private static void Test1()
        {
            new Thread(Go).Start();
            Go();

        }
        static void Go()
        {
            if (!done) { done = true; Console.WriteLine("Done"); }
        }
        
        private static void Test2()
        {
            string text = "Before";
            Thread t = new Thread(delegate () { WriteText(text); });
            text = "After";
            t.Start();
        }
        static void WriteText(string text) { Console.WriteLine(text); }

        private static void Test3() {
            string text = "Before";
            Thread t = new Thread(WriteText1);
            text = "After";
            t.Start(text);
        }
        static void WriteText1(object text) { Console.WriteLine(text); }

        private static void Test4() { }
        private static void Test5() { }
        private static void Test6() { }
        private static void Test7() { }
        private static void Test8() { }
        private static void Test9() { }
        //private static void Test0() { }
        //private static void Test1() { }
        //private static void Test2() { }
        //private static void Test3() { }
        //private static void Test4() { }
        //private static void Test6() { }
        //private static void Test7() { }
        //private static void Test8() { }
        //private static void Test9() { }
        //private static void Test0() { }
        //private static void Test1() { }
        //private static void Test2() { }
        //private static void Test3() { }
        //private static void Test4() { }
        //private static void Test6() { }
        //private static void Test7() { }
        //private static void Test8() { }
        //private static void Test9() { }
        //private static void Test0() { }
        //private static void Test1() { }
        //private static void Test2() { }
        //private static void Test3() { }
        //private static void Test4() { }
        //private static void Test6() { }
        //private static void Test7() { }
        //private static void Test8() { }
        //private static void Test9() { }
        //private static void Test0() { }
        //private static void Test1() { }
        //private static void Test2() { }
        //private static void Test3() { }
        //private static void Test4() { }
        //private static void Test6() { }
        //private static void Test7() { }
        //private static void Test8() { }
        //private static void Test9() { }
        //private static void Test0() { }
        //private static void Test1() { }
        //private static void Test2() { }
        //private static void Test3() { }
        //private static void Test4() { }
        //private static void Test6() { }
        //private static void Test7() { }
        //private static void Test8() { }
        //private static void Test9() { }
        //private static void Test0() { }
        //private static void Test1() { }
        //private static void Test2() { }
        //private static void Test3() { }
        //private static void Test4() { }
        //private static void Test6() { }
        //private static void Test7() { }
        //private static void Test8() { }
        //private static void Test9() { }
        //private static void Test0() { }
        //private static void Test1() { }
        //private static void Test2() { }
        //private static void Test3() { }
        //private static void Test4() { }
        //private static void Test6() { }
        //private static void Test7() { }
        //private static void Test8() { }
        //private static void Test9() { }
        //private static void Test0() { }
        //private static void Test1() { }
        //private static void Test2() { }
        //private static void Test3() { }
        //private static void Test4() { }
        //private static void Test6() { }
        //private static void Test7() { }
        //private static void Test8() { }
        //private static void Test9() { }
        //private static void Test0() { }
    }
}
