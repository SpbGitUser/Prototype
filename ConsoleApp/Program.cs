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
                //TypesConvertion();
                //TypesConvertion2();
                //TypesConvertion3();
                //TypesConvertion4();
                //TypesConvertion5();
                //TypesConvertion6();
                //TypesConvertion7();
                //EqualsTest();
                //EqualsTest1();
                //GenricsTest();
                //TryCatchTest();
                //TryCatchTest1();
                TryCatchTest2();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                //throw;
            }


            Console.ReadKey();
        }

        //----------------_T_E_S_T_I_N_G_-------------------
        //Console.WriteLine("------------------");

        private static void TryCatchTest2()
        {
            try
            {
                ExceptionTestClass.Method1();
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Catch в Main : {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Блок finally в Main");
            }
            Console.WriteLine("Конец метода Main");
            Console.Read();
        }

        private static void TryCatchTest1()
        {
            try
            {
                int x;
                if (!int.TryParse(Console.ReadLine(), out x))
                {
                    throw new MyException("This is not INT");
                }
            }
            catch (MyException ex)
            {
                Console.WriteLine($"Hey!!! {ex.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private static void TryCatchTest()
        {
            int x = 5;

            try
            {
                //x *= x;
                //Console.WriteLine(x);
                x = Int32.Parse(Console.ReadLine() ?? "3"); ;
                int y = x / 0;
                Console.WriteLine($"Результат: {x}");
            }
            //catch (DivideByZeroException e) when (x > 5)
            //{
            //    Console.WriteLine("When exception");
            //}
            //catch (DivideByZeroException e) 
            //{
            //    Console.WriteLine("Simple ex");
            //}
            finally
            {
                Console.WriteLine("Блок finally");
            }
        }
        
        private static void GenricsTest()
        {
            var acc1 = new Account<int>(100)
            {
                Sum = 100
            };
            //var acc2 = new Account<string>(200)
            //{
            //    Sum = 500
            //};
            

            var ma = new MyAccount("7896-1425-1231-4565");
            Console.WriteLine(ma.Id.GetType());
            Account<string> acc = new MyAccount("sdfs-sdfs-sfdd-sdfsd");
        }

        private static void EqualsTest1()
        {
            Person person1 = new Person {Name = "Tom"};
            Person person2 = new Person {Name = "Bob"};
            Person person3 = new Person {Name = "Tom"};
            bool p1Ep2 = person1.Equals(person2); // false
            Console.WriteLine(p1Ep2);
            bool p1Ep3 = person1.Equals(person3); // true
            Console.WriteLine(p1Ep3);
        }

        private static void EqualsTest()
        {
            var str = "11";
            var str1 = "11";
            var c = 11;
            var d = 11;
            if (str.Equals(str1))
            {
                Console.WriteLine("Strings equals");
            }
            if (d.Equals(c))
            {
                Console.WriteLine("Integer equals");
            }
        }

        private static void TypesConvertion7()
        {
            Human m = new Man("Jack");
            Human m1 = new Man("Jack");
            Human w = new Women("Ann");
            Human bb = new BigBoy("Billy");
            Human bb1 = new BigBoy("Billy");
            Human bbb = bb;
            m.SayType();
            w.SayType();
            bb.SayType();
            Console.WriteLine("------------------");
            object obj = m;
            Console.WriteLine(obj.GetType());
            
        }

        private static void TypesConvertion6()
        {
            Boy boy = new BigBoy("Sam");
            boy.Say();
            boy.SayMore();
        }

        private static void TypesConvertion5()
        {
            Man boy = new BigBoy("Sam");
            if (boy is Man)
            {
                Console.WriteLine("is man");
            }
            if (boy is BigBoy)
            {
                Console.WriteLine("is Big boy");
            }
            if (boy is object)
            {
                Console.WriteLine("is object");
            }
        }

        private static void TypesConvertion4()
        {
            Man boy = new BigBoy("Sam");
            Boy bb = (Boy) boy;
            bb.Say();
        }

        private static void TypesConvertion3()
        {
            var str = "Jane";
            Women wma = str;
            wma.SayMore();
            wma.Say();
        }

        private static void TypesConvertion2()
        {
            var boy2 = new Women("Tom");
            Boy boy = (Boy) boy2;
            Boy boy1 = boy2;
            boy.SayMore();
            boy1.SayMore();
            Console.WriteLine("------------------");
            var str = "Jane";
            Women wma = str;
            wma.SayMore();
            wma.Say();
        }


        private static void TypesConvertion()
        {
            var boy = new Boy("BoyName");
            //var men = boy as Man;
            //men.Name = "ManName";
            //boy.SayMore();
            Man man2 = boy;
            man2.Say();
            Console.WriteLine("------------------");
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

            Console.WriteLine("------------------");

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
