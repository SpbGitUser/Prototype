using System;
using System.Collections.Generic;

using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Program
    {

        private enum En
        {
            First = 15,
            Second,
            Third = 54
        }

        static void Main(string[] args)
        {
            EmptyString();
            //Test1();
            //test2();


            Console.ReadLine();
            
        }

        private static void test2()
        {
            var array = new int[] { 1, 2 };
            try
            {
                Console.Write(array[5]);
            }
            catch (ApplicationException e)
            {
                Console.Write(1);
            }
            catch (SystemException e)
            {
                Console.Write(array[5]);
            }
            catch (Exception e)
            {
                Console.Write(3);
            }
        }

        private static void Test1()
        {
            Console.WriteLine((int)En.Second);
        }

        private static void EmptyString()
        {
            string a = null;
            var b = a.Replace("\r\n", string.Empty);
            Console.WriteLine(b);
        }
    }
}
