using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using static ConsoleApp.Classes;
using static ConsoleApp.Enums;
using static ConsoleApp.Interfaces;
using static System.Console;

namespace ConsoleApp
{
    public class Program
    {
        private static void w(object s) => WriteLine(s.ToString());

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
                //-----------------------------------
                //TypesConvertion();
                //TypesConvertion2();
                //TypesConvertion3();
                //TypesConvertion4();
                //TypesConvertion5();
                //TypesConvertion6();
                //TypesConvertion7();
                //-----------------------------------
                //EqualsTest();
                //EqualsTest1();
                //GenricsTest();
                //TryCatchTest();
                //TryCatchTest1();
                //TryCatchTest2();
                //InterfacesTest();
                //InterfacesTest1();
                //InterfacesTest2();
                //InterfacesTest3();
                //InterfacesTest4();
                //StringSpecificTest();
                //InternirovanieStrok();
                //KovariantnostTest();
                //KontrvariantnostTest();
                //DelegateTest();
                //EventTest();
                //LambdaTEst();
                //-----------------------------------
                //KovariantnostDelegata();
                //KontrvariantnostDelegata();
                //KovariantnostGenericDelegata();
                //KontrvariantnostGenericDelegata();
                //DelegateVariants();
                //-----------------------------------
                //ExtensionsTest();
                //PartialTest();
                //AnonimusType();
                //PatternMatching();
                //IntTest();
                //-----------------------------------
                //OperatorsTest();
                //-----------------------------------
                //EnumerableTest();
                //ArreyListTest();
                //GenericListTest();
                //LinkedListTest();
                //QuueTest();
                //StackTest();
                //DictionaryTest();
                //ObservableCollectionTest();
                YieldTest();
            }
            catch (Exception e)
            {
                WriteLine(e);
                //throw;
            }
            ReadKey();
        }

        //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        //XXXXXXXXXXXXXXXX_T_E_S_T_I_N_G_XXXXXXXXXXXXXXXXXXX
        //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

        //WriteLine("------------------");
        //private static void Test() {}
        
        private static void YieldTest()
        {
            Numbers numbers = new Numbers();
            foreach (int n in numbers)
            {
                w(n);
            }
            WriteLine("------------------");
            var l = new Libra();
            foreach (Book one in l)
            {
                w(one.Name);
            }
            WriteLine("------------------");
            //foreach (Book one in l.GetMyEnumerator())
            //{
            //    w(one.Name);
            //}
        }

        private static void ObservableCollectionTest()
        {
            var o = new ObservableCollection<int>();
            o.CollectionChanged += ObColChanged;

            o.Add(1);
            o.Add(2);
            o[1] = 77;
            foreach (var item in o)
            {
                w(item.ToString());
            }
            //o.RemoveAt(1);
            foreach (var item in o)
            {
                w(item.ToString());
            }
            WriteLine("------------------");
            var lst = new List<int> { 5, 6, 7, 8, 9 };
            for (int i = 0; i < lst.Count; i++)
                Console.WriteLine("lst[{0}] = {1}", i, lst[i]);
            Console.WriteLine();
            lst.RemoveAt(3);

            for (int i = 0; i < lst.Count; i++)
                Console.WriteLine("lst[{0}] = {1}", i, lst[i]);
        }

        private static void ObColChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            var act = string.Empty;
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add: // если добавление
                    act = "ADDED";
                    break;
                case NotifyCollectionChangedAction.Remove: // если удаление
                    act = "REMOVED";
                    break;
                case NotifyCollectionChangedAction.Replace: // если замена
                    act = "REPLACED";
                    break;
            }

            w(act + " >> " + e.NewItems[0].ToString());
        }

        private static void DictionaryTest()
        {
            var a = new Dictionary<string, string>()
            {
                {"a", "123"},
                {"b", "254435"}
            };
            if (a.ContainsKey("a"))
            {
                if (a.ContainsValue("123"))
                {
                    w(a.Last().Value);
                }
            }

            //начиная с C# 6.0 (Visual Studio 2015) доступен также еще один способ инициализации:
            Dictionary<string, string> countries = new Dictionary<string, string>
            {
                ["Франция"] = "Париж",
                ["Германия"] = "Берлин",
                ["Великобритания"] = "Лондон"
            };
            foreach (var item in countries)
            {
                w(item.Value + " - " + item.Key);
            }
        }

        private static void StackTest()
        {
            var a = new Stack<int>();
            a.Push(1);
            a.Push(2);
            a.Push(3);
            w(a.Pop().ToString());
            w(a.Peek().ToString());
        }

        private static void QuueTest()
        {
            var a = new Queue<string>();
            a.Enqueue("a");
            a.Enqueue("b");
            a.Enqueue("c");

            var d = a.Dequeue();
            w(d);

            var e = a.Peek();
            w(e);
        }

        private static void LinkedListTest()
        {
            var ll = new LinkedList<int>();
            ll.AddLast(1);
            ll.AddLast(2);

            ll.AddAfter(ll.First, 7);

            foreach (var item in ll)
            {
                WriteLine(item);
            }
            WriteLine("------------------");
            WriteLine(ll.First.Previous);
        }

        private static void GenericListTest()
        {
            var a = new List<int>();
            a.Add(1);
            a.AddRange(new List<int> {1,3,5});
            a.Insert(0, 77);
            a.Sort((x,y) => x > y ? 1 : -1);    //ЛЯМБДА ДЛЯ СРАВНЕНИЯ
            foreach (var item in a)
            {
                WriteLine(item);
            }
        }

        private static void ArreyListTest()
        {
            var a  = new ArrayList();
            a.Add(1);
            a.Add("sd");
            a.AddRange(new string[] { "ura", "poka"});
            foreach (var item in a)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("------------------");
            a.RemoveAt(2);
            a.Reverse();
            for (int i = 0; i < a.Count; i++)
            {
                WriteLine(a[i]);
            }
        }

        private static void EnumerableTest()
        {
            ArrayList objectList = new ArrayList() { 1, 2, "string", 'c', 2.0f };

            object obj = 45.8;

            objectList.Add(obj);
            objectList.Add("string2");
            objectList.RemoveAt(0); // удаление первого элемента
            foreach (var o in objectList)
            {
                Console.WriteLine(o);
            }
            Console.WriteLine("------------------");
            //обобщенные
            List<string> countries = new List<string>() { "Россия", "США", "Великобритания", "Китай" };
            countries.Add("Франция");
            countries.RemoveAt(1); // удаление второго элемента
            foreach (string s in countries)
            {
                Console.WriteLine(s);
            }
        }

        private static void OperatorsTest()
        {
            var a = true;
            var a2 = false;
            var c = a ^ a2;
            Console.WriteLine(c);
            Console.WriteLine("------------------");
            int a3 = int.MinValue;
            Console.WriteLine($"Before: {Convert.ToString(a3, toBase: 2)}");
            int b = a3 >> 3;
            Console.WriteLine($"After:  {Convert.ToString(b, toBase: 2)}");
        }

        // > C# 8.0 позволяет сократить конструкцию switch, которая возвращает значение:
        //static int Select3(int op, int a, int b) => op switch
        //{
        //    1 => a + b,
        //    2 => a - b,
        //    3 => a* b,
        //        _ => throw new ArgumentException("Недопустимый код операции")
        //};


        //. В версии C# 7.0 (Visual Studio 2017) 
        //private static void RefTest()
        //{
        //    int x = 5;
        //    ref int xRef = ref x;
        //    Console.WriteLine(x); // 5
        //    xRef = 125;
        //    Console.WriteLine(x); // 125
        //    x = 625;
        //    Console.WriteLine(xRef); // 625
        //}

        private static void IntTest()
        {
            var a = uint.MaxValue;
            var b = int.MaxValue;
            Console.WriteLine(a);
            Console.WriteLine(b);
            b = 0;
            Console.WriteLine(b);
            b = (int)a;
            Console.WriteLine(b);
        }

         private static void PatternMatching()
        {
            var emp = new Employee3();
            //var emp = new Manager3();
            UseEmployee1(emp);
            UseEmployee2(emp);
            UseEmployee3(emp);
        }

        private static void UseEmployee1(Employee3 emp)
        {
            Manager3 manager = emp as Manager3;
            if (manager != null && manager.IsOnVacation == false)
            {
                manager.Work();
            }
            else
            {
                Console.WriteLine("Преобразование прошло неудачно");
            }
        }
        private static void UseEmployee2(Employee3 emp)
        {
            try
            {
                Manager3 manager = (Manager3)emp;
                if (!manager.IsOnVacation)
                    manager.Work();
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static void UseEmployee3(Employee3 emp)
        {
            if (emp is Manager3)
            {
                Manager3 manager = (Manager3)emp;
                if (!manager.IsOnVacation)
                    manager.Work();
            }
            else
            {
                Console.WriteLine("Преобразование не допустимо");
            }
        }
        //pattern matching
        //static void UseEmployee(Employee3 emp)
        //{
        //    if (emp is Manager3 manager && manager.IsOnVacation == false)
        //    {
        //        manager.Work();
        //    }
        //    else
        //    {
        //        Console.WriteLine("Преобразование не допустимо");
        //    }
        //}
        //static void UseEmployee(Employee3 emp)
        //{
        //    switch (emp)
        //    {
        //        case Manager3 manager:
        //            manager.Work();
        //            break;
        //        case null:
        //            Console.WriteLine("Объект не задан");
        //            break;
        //        default:
        //            Console.WriteLine("Объект не менеджер");
        //            break;
        //    }
        //}

        //Локальные функции доступны начиная с версии C# 7.0 
        private static void LocalFuncs()
        {
            //int limit = 0;

                // локальная функция
                //bool IsMoreThan(int number)
                //{
                //    return number > limit;
                //}

            //int result = 0;
            //for (int i = 0; i < numbers.Length; i++)
            //{
            //    if (IsMoreThan(numbers[i]))
            //    {
            //        result += numbers[i];
            //    }
            //}
        }

        private static void AnonimusType()
        {
            var user = new { Name = "Tom", Age = 34 };
            var student = new { Name = "Alice", Age = 21 };
            var manager = new { Name = "Bob", Age = 26, Company = "Microsoft" };

            //диентификаторы, имена которых будут использоваться как названия свойств
            var name1 = "Ted";
            var manager1 = new { Name = "Bob", Age = 26, name1 };
            
            // свойства анонимных типов доступны только для чтения
            Console.WriteLine(user.GetType().Name); // <>f__AnonymousType0'2
            Console.WriteLine(student.GetType().Name); // <>f__AnonymousType0'2
            Console.WriteLine(manager.GetType().Name); // <>f__AnonymousType1'3
            Console.WriteLine(manager1.name1); // <>f__AnonymousType1'3

            //[+++]
            //Программа скомпилируется, и на консоль будет выведена строка "Ford"
            //var student = new { tom.Auto.Name, age };
            //Console.WriteLine(student.Name);
        }

        private static void PartialTest()
        {
            var n = new PartialTest("Tom");
            n.SayName();
            n.HI2();
        }

        private static void ExtensionsTest()
        {
            var str = "Hi!";
            str.ToMsgBox();
        }

        private static void ActionSample(string s, int i)
        {
            Console.WriteLine($"{s} is {i} years old");
        }
        private static bool PredicateSample(int i)
        {
            return i >= 18;
        }
        private static string FuncSample(string s, int i)
        {
            var res = string.Empty;
            for (int j = 0; j < i; j++)
            {
                res += i;
            }
            return res;
        }

        private static void DelegateVariants()
        {
            Action<string, int> act = ActionSample;
            Predicate<int> pre = PredicateSample;
            Func<string, int, string> funcSMp = FuncSample;

            act("Tom", 18);
            Console.WriteLine("------------------");
            Console.WriteLine(pre(17) ? "Old man" : "So yang :)");
            Console.WriteLine("------------------");
            Console.WriteLine(funcSMp("7", 3));
        }

        private static void PersonInfo(Person2 p) => p.Display();
        delegate void GetInfo<in T>(T item);
        private static void KontrvariantnostGenericDelegata()
        {
            GetInfo<Person2> personInfo = PersonInfo;
            GetInfo<Client2> clientInfo = personInfo;      // контравариантность - ПАРАМЕТР МОЖЕТ БЫЛЬ ТАКИМЖЕ ИЛИ БОЛЕЕ ОБОБЩЕННЫМ)

            Client2 client = new Client2 { Name = "Tom" };
            clientInfo(client); // Client: Tom
        }
        
        private static Client2 GetClient(string name)
        {
            return new Client2 { Name = name };
        }
        delegate T Builder<out T>(string name);
        private static void KovariantnostGenericDelegata()
        {
            Builder<Client2> clientBuilder = GetClient;
            Builder<Person2> personBuilder1 = clientBuilder;     // ковариантность - ВОЗВРАЩАЕМОЕ ЗНАЧЕНИЕ ДОЛЖНО БЫТЬ ТАКИМ ЖЕ ИЛИ ТОЧНЕЕ

            Person2 p = personBuilder1("Tom"); // вызов делегата
            p.Display(); // Client: Tom
        }
        
        delegate void ClientInfo(PersonChild1 client);
        private static void GetPersonInfo(Person1 p)
        {
            Console.WriteLine(p.Name);
        }
        private static void KontrvariantnostDelegata()
        {
            ClientInfo clientInfo = GetPersonInfo; // контравариантность
            PersonChild1 client = new PersonChild1 { Name = "Alice" };
            clientInfo(client);
            Console.Read();
        }

        delegate Person1 PersonFactory(string name);
        private static PersonChild1 BuildClient(string name)
        {
            return new PersonChild1 { Name = name };
        }
        private static void KovariantnostDelegata()
        {
            PersonFactory personDel;

            personDel = BuildClient; // ковариантность
            Person1 p = personDel("Tom");
            Console.WriteLine(p.Name);
        }

        delegate int Operation(int x, int y);
        delegate int Operation1(int x);
        delegate int Operation2(ref int x);
        private static void LambdaTEst()
        {
            Operation op1 = (x, y) => x + y;
            Operation op2 = (x, y) => x * y;
            Operation op3 = delegate(int a, int b)
            {
                return a * b * 2;
            };

            Operation1 op4 = i => i * 10;
            Operation2 op5 = (ref int a) => a++;

            Console.WriteLine(op1(1,2));
            Console.WriteLine(op2(1, 2));
            Console.WriteLine(op3(1, 2));
            Console.WriteLine(op4(2));
            var c1 = 23;
            op5(ref c1);
            Console.WriteLine(c1);
            Console.WriteLine("------------------");
            var aa = new EventTester();
            aa.OnLabdaEvent += (i) =>
            {
                Console.WriteLine("Your choise is " + i);
            };
            aa.MakeIt1();
            Console.WriteLine("------------------");
            aa.MakeIt2((c)=> {Console.WriteLine("Another choise is " + c);});
        }
        
        private static void EventTest()
        {
            var a = new EventTester();
            a.OnMyEventIn += EventAction;
            a.OnMyEventOut += delegate(object sndr, MyEventArgs args)
            {
                Console.WriteLine("Here " + args.Msg + " can do it in " + (sndr as EventTester).Age);
            };
            a.MakeIt();
        }

        private static void EventAction(object sender, MyEventArgs args)
        {
            var s = sender as EventTester;
            if (s != null && args != null)
            {
                if (s.Age < args.Val)
                {
                    Console.WriteLine(args.Msg + " NOT a real man");
                }
                else
                {
                    Console.WriteLine(args.Msg + " can drink BEER");
                }
            }
            //Console.WriteLine($"I'm CALL -> {txt}");
        }

        private static void DelegateTest()
        {
            DelegateInside.Check();
            Console.WriteLine("------------------");
            DelegateInside.Check2();
            Console.WriteLine("------------------");
            DelegateInside.Check3();
            Console.WriteLine("------------------");
            DelegateInside.SaySmthhng ssm = DelegateInside.SayerMethod2;
            DelegateInside.Check4(ssm);
        }

        /// <summary>
        /// Контравариантность: позволяет использовать более универсальный тип, чем заданный изначально
        /// </summary>
        private static void KontrvariantnostTest()
        {
            ///[!!!] ниверсальный параметр контрвариантного типа может применяться 
            /// только к аргументам метода,  но не может применяться к аргументам,
            ///  используемым в качестве возвращаемых типов

            ITransaction<Account> accTransaction = new Transaction<Account>();
            accTransaction.DoOperation(new Account(), 400);

            ITransaction<DepositAccount> depAccTransaction = new Transaction<Account>();
            depAccTransaction.DoOperation(new DepositAccount(), 450);

        }

        /// <summary>
        /// Ковариантность: позволяет использовать более конкретный тип, чем заданный изначально
        /// </summary>
        private static void KovariantnostTest()
        {
            ///[!!!] универсальный параметр может использоваться только в качестве типа значения, 
            ///возвращаемого методами интерфейса.Но не может использоваться в качестве типа
            ////аргументов метода или ограничения методов интерфейса.

            IBank<DepositAccount> depositBank = new Bank<DepositAccount>();
            Account acc1 = depositBank.CreateAccount(34);

            IBank<Account> ordinaryBank = new Bank<DepositAccount>();
            // или так
            // IBank<Account> ordinaryBank = depositBank;
            Account acc2 = ordinaryBank.CreateAccount(45);
        }


        private static void InternirovanieStrok()
        {
            //Интернирование строки - это способ обойти эту проблему.
            //Среда CLR поддерживает таблицу называемую пул интернирования.
            //Эта таблица содержит одну уникальную ссылку на каждую строку, 
            //которая либо объявлена, либо создана программно во время выполнения
            
            Console.WriteLine("1 ----------------");
            string a = "hello world";
            string b = a;
            a = "hello";
            Console.WriteLine("{0}, {1}", a, b);
            Console.WriteLine(a == b);
            Console.WriteLine(object.ReferenceEquals(a, b));
            Console.WriteLine("2 ----------------");
            Console.WriteLine((a + " world") == b);
            Console.WriteLine(object.ReferenceEquals((a + " world"), b));
            Console.WriteLine("3 ----------------");
            string hello = "hello";
            string helloWorld = "hello world";
            string helloWorld2 = hello + " world";

            Console.WriteLine("{0}, {1}: {2}, {3}", helloWorld, helloWorld2,
                helloWorld == helloWorld2,
                object.ReferenceEquals(helloWorld, helloWorld2));
            Console.WriteLine("4 ----------------");
            helloWorld2 = "hello world";
            Console.WriteLine("{0}, {1}: {2}, {3}", helloWorld, helloWorld2,
                helloWorld == helloWorld2,
                object.ReferenceEquals(helloWorld, helloWorld2));
            Console.WriteLine("5 ----------------");
            Console.WriteLine(object.ReferenceEquals(
                String.Intern(helloWorld),
                String.Intern(helloWorld2))); ;
            Console.WriteLine("6 ----------------");
            string a1 = new string(new char[] { 'a', 'b', 'c' });
            object o = String.Copy(a1);
            Console.WriteLine(object.ReferenceEquals(o, a1));
            String.Intern(o.ToString());
            Console.WriteLine(object.ReferenceEquals(o, String.Intern(a1)));
            Console.WriteLine("7 ----------------");
            object o2 = String.Copy(a1);
            String.Intern(o2.ToString());
            Console.WriteLine(object.ReferenceEquals(o2, String.Intern(a1)));
            Console.WriteLine("8 ----------------");
            string s = new string(new char[] { 'x', 'y', 'z' });
            Console.WriteLine(String.IsInterned(s) ?? "not interned");
            String.Intern(s);
            Console.WriteLine(String.IsInterned(s) ?? "not interned");
            Console.WriteLine(object.ReferenceEquals(
                String.IsInterned(new string(new char[] { 'x', 'y', 'z' })), s));
            Console.WriteLine("9 ----------------");
            //[!!!] >>> код содержит литерал «xyz». А когда вы добавляете литерал в вашу программу, 
            //CLR автоматически добавляет его в пул интернирования ещё до начала выполнения программы.
            //Комментируете эту строку, вы убираете литерал из программы и пул интернирования уже 
            //не будет содержать строку «xyz».
            //Console.WriteLine(object.ReferenceEquals("xyz", s));
            //Console.WriteLine(object.ReferenceEquals("x" + "y" + "z", s));
            Console.WriteLine(object.ReferenceEquals(String.Format("{0}{1}{2}", 'x', 'y', 'z'), s));
        }

        private static int a12 = 5;
        private static int b454345 = a12;
        static void StringSpecificTest()
        {
            //Структуры данных можно разделить на два вида — эфемерные и персистентные.

            //ЭФИМЕРНЫЕ / ПЕРСИСТЕНТНЫЕ
            //Эфемерными называют структуры данных, хранящие только последнюю свою версию. 
            //Персистентными называют структуры, которые сохраняют все свои предыдущие версии при изменении. 

            //Последние фактически неизменяемы, так как их операции не изменяют структуру на месте, 
            //вместо этого они возвращают новую основанную на предыдущей структуру.

            //Учитывая, что строки неизменны, они могли бы быть и персистентными, 
            //однако таковыми не являются.В.NET строки являются эфемерными. Подробнее о том, почему это именно так можно прочитать у Эрика Липперта по ссылке

            Console.WriteLine(b454345);
        }

        private static void InterfacesTest4()
        {
            //var numbers = new [] { "97", "45", "32", "65", "83", "23", "15" };

            var numbers = new[]
            {
                new Punk() {Name = "John"},
                new Punk() {Name = "Bob"},
                new Punk() {Name = "AF"},
                new Punk() {Name = "TOPOR"},
                new Punk() {Name = "Sandenick"},
                new Punk() {Name = "PRETTY_BOY"},
                new Punk() {Name = "CS"},
                new Punk() {Name = "-"},
                new Punk() {Name = "HH"},
                new Punk() {Name = "GUFF"},
            };
            //var numbers = new int[] { 97, 45, 32, 65, 83, 23, 15 };
            Array.Sort(numbers, new PunkComparer());
            foreach (var n in numbers)
            {
                Console.WriteLine(n.Name);
            }
            //Console.WriteLine("------------------");
            Array.Sort(numbers);
            foreach (var n in numbers)
            {
                Console.WriteLine(n.Name);
            }
        }

        private static void InterfacesTest3()
        {
            //var numbers = new [] { "97", "45", "32", "65", "83", "23", "15" };

            var numbers = new[]
            {
                new Raper() {Name = "John"},
                new Raper() {Name = "Bob"},
                new Raper() {Name = "AF"},
                new Raper() {Name = "TOPOR"},
                new Raper() {Name = "Sandenick"},
                new Raper() {Name = "PRETTY_BOY"},
                new Raper() {Name = "CS"},
                new Raper() {Name = "-"},
                new Raper() {Name = "HH"},
                new Raper() {Name = "GUFF"},
            };
            //var numbers = new int[] { 97, 45, 32, 65, 83, 23, 15 };
            Array.Sort(numbers);
            foreach (var n in numbers)
            {
                Console.WriteLine(n.Name);
            }
        }

        private static void InterfacesTest2()
        {
            var p = new Punk() { Name = "Sid"};
            var c = (Punk)p.Clone();
            c.Name = "ChaCha";
            Console.WriteLine(c.Name);
            Console.WriteLine("------------------");
            var d = new Raper() {Name = "Fred"};
            d.Friend = c;
            var r =(Raper) d.Clone();
            Console.WriteLine(r.Friend.Name);

        }

        private static void InterfacesTest1()
        {
            var g = new Goer();
            ((IRunner) g).Run();
            ((IStepper) g).Run();
        }

        private static void InterfacesTest()
        {
            IMoveable p = new Punk();
            ISingable r = new Raper();
            //p.Move();
            //r.Sing();
            Dancer c = (Dancer) p;
            c.Move();
            c.Sing();
        }

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
            catch (Exception e)
            {
                Console.WriteLine("ex");
            }
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
            ///overrided метод вызывается в момент выполнения и берет тип реально созданного объекта
            ///hiden - по типу переменной, куда кладется объект

            Boy boy = new BigBoy("Sam");
            boy.Say();
            boy.SayMore();
            boy.SayMoreMore();
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
            var wm = new Women("Tom");
            Boy boy = (Boy)wm;
            Boy boy1 = (Boy)wm;     // explicit (явное) приведение типоов
            boy.SayMore();
            boy1.SayMore();
            Console.WriteLine("------------------");
            var str = "Jane";
            Women wma = str;    // implicit (неявное) приведение типоов
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
