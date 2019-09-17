using System;
using static ConsoleApp.Classes;
using static ConsoleApp.Enums;

namespace ConsoleApp
{
    public class Program
    {


        static void Main(string[] args)
        {
            try
            {
                //EmptyString();
                //StringNullTest1();
                //ArreyTest1();
                //StaticMember();
                //OperatorOverridingTest();
                //Indexator();
                //Inheritance();
                TypesConvertion();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                //throw;
            }


            Console.ReadKey();
        }

        //----------------_T_E_S_T_I_N_G_-------------------


        private static void TypesConvertion()
        {
            var boy = new Boy("BoyName");
            //var men = boy as Man;
            //men.Name = "ManName";
            //boy.SayMore();
            Man man2 = boy;
            man2.Say();
            Console.WriteLine("----------------------------");
            var man1 = new Man("ManName");
            if (man1 is Boy)
            {
                Boy boy2 = (Boy)man1;
                boy2?.SayMore();
            }
            else
            {
                Console.WriteLine("Man is not a boy :)");
            }
        }


        private static void Inheritance()
        {
            //var men = new Man("Ilya");
            var boy = new Boy("Nikola");
            //var boy2 = men as Boy;
            //var men2 = boy as Man;
            //men2?.Say();
            //boy2?.Say();
            //boy?.SayMore();
        }

        private static void Indexator()
        {
            var people = new People
            {
                [0] = new Person() {Name = "Anton"},
                [1] = new Person() {Name = "Max"},
                [2] = new Person() {Name = "Ivan"},
                [3] = new Person() {Name = "Dexter"},
                [4] = new Person() {Name = "Slava"}
            };

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(people[i].Name);
            }

            Console.WriteLine("----------------------------");

            Console.WriteLine(people["456"] ?? "this is NULL");
            Console.WriteLine(people["1"]);
        }

        private static void OperatorOverridingTest()
        {
            var a = new Counter() {Value = 2};
            var b = new Counter() {Value = 5};
            var c = a + b;

            Console.WriteLine(c.Value);
        }

        private static void StaticMember()
        {
            var a = new WithStaticMemeber();
            a.Name = "One";
            WithStaticMemeber.Age = 25;
             var b = new WithStaticMemeber();
            b.Name = "Two";

            Console.WriteLine(WithStaticMemeber.Age);
        }

        private static void ArreyTest1()
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

        private static void StringNullTest1()
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
