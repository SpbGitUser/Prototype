﻿using System;
using static ConsoleApp.Classes;
using static ConsoleApp.Enums;

namespace ConsoleApp
{
    public class Program
    {


        static void Main(string[] args)
        {
            //EmptyString();
            //Test1();
            //test2();
            StaticMember();

            Console.ReadLine();
            
        }

        //----------------_T_E_S_T_I_N_G_-------------------


        private static void StaticMember()
        {
            var a = new WithStaticMemeber();
            a.Name = "One";
            WithStaticMemeber.Age = 25;
             var b = new WithStaticMemeber();
            b.Name = "Two";

            Console.WriteLine(WithStaticMemeber.Age);
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
