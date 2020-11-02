using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeforeAndAfter
{
    public class Program
    {
        static Program() => Console.WriteLine("Before");

        public class MyCl
        {
            public bool Is { get; set; }

            public int Cnt { get; set; }
        }

        static void Main(string[] args)
        {
            //AppDomain.CurrentDomain.ProcessExit += new EventHandler(CurrentDomain_ProcessExit);
            Console.WriteLine("A");

            //MyCl my = new MyCl();
            //my = null;
            //if (my?.Cnt > 0)
            //{
            //    Console.WriteLine("A2");
            //}

            List<int> listInt = null;
            if (listInt.Any())
            {

            }



        }

        ~Program()
        {
            Console.WriteLine("After");
            Console.ReadKey();
        }

        //static void CurrentDomain_ProcessExit(object sender, EventArgs e)
        //{
        //     Console.WriteLine("exit");
        //    Console.ReadKey();
        //}

        //protected override void Finalize()
        //{
        //    try
        //    {
        //        Console.WriteLine("exit");
        //        Console.ReadKey();
        //    }
        //    finally
        //    {
        //        //base.Finalize();
        //    }
        //}

        //public static U Round<T, U>(T param, int to)
        //       where T : struct
        //        where U : struct
        //{
        //    U res = 0;


        //    return res;
        //}
    }
}
