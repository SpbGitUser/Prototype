using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml.Serialization;
using static ConsoleApp.Classes;
using static ConsoleApp.Classes2;
using static ConsoleApp.Enums;
using static ConsoleApp.Interfaces;
using static System.Console;

namespace ConsoleApp
{
    public class Program
    {

        //--КОНСТАНТЫ-----------------------------------------
        private const string TestFolder = @"D:\Test\";

        //--ДОП. МЕТОДЫ--------------------------------------
        private static void W(params object[] s) => WriteLine(string.Join(" ", s.Select(r => r.ToString())));
        private static void W(char[] s) => W(string.Join(string.Empty, s.Select(r => r.ToString())));

        private static string FP(string fileName)
        {
            return $"{TestFolder}{fileName}";
        }

        //--ЗАПУСК-------------------------------------------
        static void Main(string[] args)
        {
            //тесты в виде статических методов
            StaticTests();
            //тестовые ситуации
            //QuestionTests();
        }

        //--ЭТАПЫ ТЕСТИРОВАНИЯ------------------------------
        private static void StaticTests()
        {
            try
            {
                W("-------------------- START --------------------" + Environment.NewLine);
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
                //KovariantnostDelegata();
                //KontrvariantnostDelegata();
                //KovariantnostGenericDelegata();
                //KontrvariantnostGenericDelegata();
                //DelegateVariants();
                //ExtensionsTest();
                //PartialTest();
                //AnonimusType();
                //PatternMatching();
                //IntTest();
                //OperatorsTest();
                //EnumerableTest();
                //ArreyListTest();
                //GenericListTest();
                //LinkedListTest();
                //QuueTest();
                //StackTest();
                //DictionaryTest();
                //ObservableCollectionTest();
                //YieldTest();
                //DriveInfoTest();
                //DirectoryInfoTest();
                //DirectoryInfoTest2();
                //FileStramTest();
                //FileStramSeekTest();
                //StreamReaderWriterTest();
                //BinaryWriterReaderTest();
                //GZipStreamDeflateStreamTest();
                //BinaryFormatterTest();
                //SoapFormatterTest();
                //XmlSerializerTest();
                //DataContractJsonSerializerTest();
                //StringTest1();
                //StringFormatTest();
                //StringBuilderTest();
                //RegexTest();
                //RegexIsMatchTest();
                //RegexIsMatchTest1();
                //TestDistructor();
                //TestIDisposed();
                //TestIDisposed2();
                //DateTimeTest();
                //LazyTest();
                //MathTest();
                //ParserTest();
                //ArrayTest();
                //SpanTest();
                //IndexArrayTest();
                //ThreadingTest();
                //ThreadingTest2();
                //ParameterizedThreadStartTest();
                //ThreadLockerTest();
                //ThreadingMonitorTest();
                //AutoResetEventTest();
                //MutexTest();
                //SemaphoreTest();
                TimerTest();
            }
            catch (Exception e)
            {
                WriteLine(e);
                throw;
            }
            W(Environment.NewLine + "------------------- THE_END -------------------");
            ReadKey();
        }


        private static void QuestionTests()
        {
            W("-------------------- START --------------------" + Environment.NewLine);
            try
            {
                //QuesTest1Q1();
                //QuesTest1Q2();
                //QuesTest1Q3();
                //QuesTest1Q4();
                //QuesTest2Q5();
                //QuesTest2Q6();
                //QuesTest2Q7();
                //QuesTest2Q8();
                //QuesTest2Q13();
                //QuesTest2Q14();
                QuesTest6Q57();
            }
            catch (Exception e)
            {
                WriteLine(e);
                //throw;
            }
            W(Environment.NewLine + "------------------- THE_END -------------------");
            ReadKey();
        }

        //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        //XXXXXXXXXXXXXXXXXXXXXXXXX_T_E_S_T_I_N_G_XXXXXXXXXXXXXXXXXXXXXXXXXXXX
        //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

        //W("------------------------------------");
        //private static void Test() {}

        private static void QuesTest6Q57()
        {
            try
            {
                var array = new int[] { 1, 2 };
                Console.Write(array[5]);
            }
            catch (ApplicationException e)
            {
                Console.Write(1);
            }
            catch (SystemException e)
            {
                Console.Write(2);
                throw;
            }
            catch (Exception e)
            {
                Console.Write(3);
            }
            Console.ReadLine();
        }

        private static void QuesTest2Q14()
        {
            try
            {
                Calc();
            }
            catch (MyCustomException e)
            {
                Console.WriteLine("Catch MyCustomException");
                throw;
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Catch Exception");
            }
            Console.ReadLine();
        }
        private static void Calc()
        {
            int result = 0;
            var x = 5;
            int y = 0;
            try
            {
                result = x / y;
            }
            catch (MyCustomException e)
            {
                Console.WriteLine("Catch DivideByZeroException");
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine("Catch Exception");
            }
            finally
            {
                throw new MyCustomException();
            }
        }

        private static void QuesTest2Q13()
        {
            object sync = new object();
            var thread = new Thread(() =>
            {
                try
                {
                    Work();
                }
                finally
                {
                    lock (sync)
                    {
                        Monitor.PulseAll(sync);
                    }
                }
            });
            thread.Start();
            lock (sync)
            {
                Monitor.Wait(sync);
            }
            Console.WriteLine("test");
        }
        private static void Work()
        {
            Thread.Sleep(1000);
        }

        private static void QuesTest2Q8()
        {
            var w = new Wrap();
            var wraps = new Wrap[3];
            for (int i = 0; i < wraps.Length; i++)
            {
                wraps[i] = w;
            }

            var values = wraps.Select(x => x.Value);
            var results = Square(values);
            int sum = 0;
            int count = 0;
            foreach (var r in results)
            {
                count++;
                sum += r;
            }
            Console.WriteLine("Count {0}", count);
            Console.WriteLine("Sum {0}", sum);

            Console.WriteLine("Count {0}", results.Count());
            Console.WriteLine("Sum {0}", results.Sum());
        }

        static IEnumerable<int> Square(IEnumerable<int> a)
        {
            foreach (var r in a)
            {
                Console.WriteLine(r * r);
                yield return r * r;
            }
        }

        private static void QuesTest2Q7()
        {
            var c = new C7();
            A7 a = c;

            //var aa = new A7();
            //aa.Print1();

            a.Print2();
            a.Print1();
            c.Print2();

            //a.PrintV();
        }

        private static void QuesTest2Q6()
        {
            lock (syncObject)
            {
                Write();
            }
        }
        private static Object syncObject = new Object();
        private static void Write()
        {
            lock (syncObject)
            {
                Console.WriteLine("test");
            }
        }

        private static void QuesTest2Q5()
        {
            var s1 = string.Format("{0}{1}", "abc", "cba");
            var s2 = "abc" + "cba";
            var s3 = "abccba";
            
            Console.WriteLine(s1 == s2);
            Console.WriteLine((object)s1 == (object)s2);
            Console.WriteLine(s2 == s3);
            Console.WriteLine((object)s2 == (object)s3);
        }

        private static void QuesTest1Q4()
        {
            int i = 1;
            object obj = i;
            ++i;
            Console.WriteLine(i);
            Console.WriteLine(obj);
            Console.WriteLine((int)obj);
        }

        private static void QuesTest1Q3()
        {
            List<Action> actions = new List<Action>();
            for (var count = 0; count < 10; count++)
            {
                actions.Add(() => Console.WriteLine(count));
            }
            foreach (var action in actions)
            {
                action();
            }
        }

        private static void QuesTest1Q2()
        {
            var s = new S();
            using (s)
            {
                Console.WriteLine(s.GetDispose());
            }
            Console.WriteLine(s.GetDispose());
        }

        private static void QuesTest1Q1()
        {
            //Classes2.B obj1 = new Classes2.A();
            //obj1.Foo();
            B obj2 = new B();
            obj2.Foo();
            A obj3 = new B();
            obj3.Foo();
        }

        private static void TimerTest()
        {
            int num = 0;
            TimerCallback tc = new TimerCallback(RunCounter6);
            var timer = new Timer(tc, num, 0, 2000);

        }
        public static void RunCounter6(object obj)
        {
            int x = (int)obj;
            for (int i = 1; i < 9; i++, x++)
            {
                Console.WriteLine($"{x * i}");
            }
            W("------------------------------------");
        }

        private static void SemaphoreTest()
        {
            for (int i = 1; i < 6; i++)
            {
                var reader = new SemaphoreReader(i);
            }

        }

        private static Mutex _nutex = new Mutex();
        private static void MutexTest()
        {
            for (int i = 0; i < 5; i++)
            {
                Thread myThread = new Thread(RunCounter5);
                myThread.Name = $"Поток {i.ToString()}";
                myThread.Start();
            }
        }
        public static void RunCounter5()
        {
            _nutex.WaitOne();
            //AutoResetEvent.WaitAll(new WaitHandle[] {_waitHandler, _waitHandler1});
            AutoResetEvent.WaitAny(new WaitHandle[] { _waitHandler, _waitHandler1 });
            _sincX = 1;
            for (int i = 0; i < 9; i++)
            {
                W($"{Thread.CurrentThread.Name}: {_sincX}");
                _sincX++;
                Thread.Sleep(300);
            }
            _nutex.ReleaseMutex();
        }

        private static AutoResetEvent _waitHandler = new AutoResetEvent(true);     ///* ЕСЛИ стртовое состояние (false) - нужен _waitHandler.Set();
        private static AutoResetEvent _waitHandler1 = new AutoResetEvent(true);
        private static void AutoResetEventTest()
        {
            //*_waitHandler.Set();
            for (int i = 0; i < 5; i++)
            {
                Thread myThread = new Thread(RunCounter4);
                myThread.Name = $"Поток {i.ToString()}";
                myThread.Start();
            }
        }
        public static void RunCounter4()
        {
            _waitHandler.WaitOne();
            //AutoResetEvent.WaitAll(new WaitHandle[] {_waitHandler, _waitHandler1});
            AutoResetEvent.WaitAny(new WaitHandle[] { _waitHandler, _waitHandler1 });
            _sincX = 1;
            for (int i = 0; i < 9; i++)
            {
                W($"{Thread.CurrentThread.Name}: {_sincX}");
                _sincX++;
                Thread.Sleep(300);
            }
            _waitHandler.Set();
        }

        private static void ThreadingMonitorTest()
        {
            for (int i = 0; i < 5; i++)
            {
                Thread myThread = new Thread(RunCounter3);
                myThread.Name = $"Поток {i.ToString()}";
                myThread.Start();
            }
        }
        public static void RunCounter3()
        {
            bool acquiredLock = false;
            try
            {
                Monitor.Enter(_locker, ref acquiredLock);
                _sincX = 1;
                for (int i = 1; i < 9; i++)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name}: {_sincX}");
                    _sincX++;
                    Thread.Sleep(300);
                }
            }
            finally
            {
                if (acquiredLock) Monitor.Exit(_locker);
            }

            ///Кроме блокировки и разблокировки объекта класс Monitor имеет еще ряд методов, 
            ///которые позволяют управлять синхронизацией потоков. 
            /// 
            /// Monitor.Wait освобождает блокировку объекта и переводит поток в очередь ожидания объекта. 
            /// Следующий поток в очереди готовности объекта блокирует данный объект. 
            /// А все потоки, которые вызвали метод Wait, остаются в очереди ожидания, 
            /// пока не получат сигнала от метода Monitor.Pulse или Monitor.PulseAll, посланного владельцем блокировки. 
            /// 
            /// Если метод Monitor.Pulse отправил сигнал, то поток, находящийся во главе очереди ожидания,
            /// получает сигнал и блокирует освободившийся объект. 
            /// 
            /// Если же метод Monitor.PulseAll отправлен, то все потоки, находящиеся в очереди ожидания, 
            /// получают сигнал и переходят в очередь готовности, где им снова разрешается получать блокировку объекта.
        }

        private static object _locker = new object();
        private static int _sincX = 0;
        private static void ThreadLockerTest()
        {
            var name = "";
            for (int i = 0; i < 5; i++)
            {
                Thread myThread = new Thread(RunCounter2);
                myThread.Name = name + i.ToString();
                //name = name + " ";
                myThread.Start();
            }
        }
        public static void RunCounter2()
        {
            lock (_locker)
            {
                _sincX = 1;
                for (int i = 1; i < 9; i++)
                {
                    Console.WriteLine("{0}: {1}", Thread.CurrentThread.Name, _sincX);
                    _sincX++;
                    Thread.Sleep(400);
                }
            }
        }

        private static void ParameterizedThreadStartTest()
        {
            var thread = new Thread(new ParameterizedThreadStart(RunCounter1));
            var param = new int[] {27, 600};
            thread.Start(param);

            for (var i = 10; i < 19; i++)
            {
                W("1  - " + i);
                Thread.Sleep(300);
            }
        }
        private static void RunCounter1(object x)
        {
            var arr = x as int[];
            if (arr != null)
            {
                var max = arr.First();
                var sleep = arr.Last();
                for (var i = 1; i < max; i++)
                {
                    W(" 2 - " + i);
                    Thread.Sleep(sleep);
                }
            }
            else
            {
                W("ERROR > Parameter != int[]");
            }
        }

        private static void ThreadingTest2()
        {
            var thread = new Thread(RunCounter);
            thread.Start();

            for (var i = 10; i < 19; i++)
            {
                W("1  - " + i);
                Thread.Sleep(300);
            }
        }
        private static void RunCounter()
        {
            for (var i = 1; i < 9; i++)
            {
                W(" 2 - " + i);
                Thread.Sleep(600);
            }
        }

        private static void ThreadingTest()
        {
            // получаем текущий поток
            var t = Thread.CurrentThread;

            //получаем имя потока
            W($"Имя потока: {t.Name}");
            t.Name = "Метод Main";
            W($"Имя потока: {t.Name}");
            W($"Запущен ли поток: {t.IsAlive}");
            W($"Приоритет потока: {t.Priority}");
            W($"Статус потока: {t.ThreadState}");

            // получаем домен приложения
            W($"Домен приложения: {Thread.GetDomain().FriendlyName}");
        }

        private static void IndexArrayTest()
        {
            //Index myIndex1 = 2;     // третий элемент
            //Index myIndex2 = ^ 2;    // предпоследний элемент

            //string[] people = { "Tom", "Bob", "Sam", "Kate", "Alice" };
            //string selected1 = people[myIndex1];    // Sam
            //string selected2 = people[myIndex2];    // Kate
            //Console.WriteLine(selected1);
            //Console.WriteLine(selected2);

            //W("------------------------------------");

            //Index start = 1;
            //Index end = 4;
            //Range myRange1 = start..end;

            //Range myRange2 = 1..4;

            //string[] people = { "Tom", "Bob", "Sam", "Kate", "Alice" };
            //string[] peopleRange = people[1..4]; // получаем 2, 3 и 4-й элементы из массива
            //foreach (var person in peopleRange)
            //{
            //    Console.WriteLine(person);
            //}
        }

        private static void SqlCollationTest()
        {
            //Collation, который использовался в проекте:
            //SQL_Latin1_General_CP1_CI_AS
            //    Небольшое отступление о том, как прочесть Collation. (Если вы знакомы с ним, смело пропускайте.)
            //Итак, в Collation есть несколько частей:

            //SQL — параметры сортировки по SQL Server(SQL в начале Collation) или Windows(тогда было бы просто Latin1_ …);
            //Latin1_General — локаль или используемый язык;
            //CP1 — code page — кодовая страница;
            //CI — Case Insensitive — без учета регистра;
            //AS — Accent Sensitive — с учетом аксонов или диакритических знаков, проще говоря 'a' не считается равным 'ấ'.

            //AI — Accent Sensitive — БЕЗ учета аксонов или диакритических знаков, проще говоря 'a' не считается равным 'ấ'.

            //Этот Collation был когда-то Collation по умолчанию, когда устанавливали SQL Server.
            //    Какие опции есть еще?

            //_KS — с учетом японских иероглифов хирагана и катакана, если параметр не выбран, то SQL Server будет интерпретировать иероглифы хирагана и катакана как одинаковые.
            //_WS — с учетом ширины символов, если параметр не выбран, то “Text” и “T e x t” считаются одинаковыми строками.
            //_VSS — с учетом знаков выбора варианта написания в японском языке, появился с версии 2017.
            //_UTF8 — позволяет хранить данные в UTF8.
        }



        private static void SpanTest()
        {
            ///[1.]
            ///Ну и наконец был добавлен тип Span<T>, который позволяет создать 
            /// коллекцию данных, хранимую в стеке, но доступ к которой 
            /// осуществляется по ссылке.Тип Memory< T > является расширением
            ///  типа Span<T> и используется для потокобезопасного доступа по
            ///  ссылке к коллекции хранимой в стеке.
            
            ///[2.]
            /// Добавлен модификатор in, который указывает, что значимый тип должен передаваться по ссылке, но при этом накладывается ограничение, что он не может быть изменен внутри метода.
            //private int Sum(in int value1, in int value2);
    }

        private static void ArrayTest()
        {
            var arr = new string[2,23];
            W(".Length = " + arr.Length);       // 26 = 2x23
            W(".Rank = " + arr.Rank);           // 2мерный масив
        }

        private static void ParserTest()
        {
            IFormatProvider formatter = new NumberFormatInfo()
            {
                NumberDecimalSeparator = "."
            };
            double res;
            if (double.TryParse("123.255555555555", NumberStyles.Number, formatter, out res))
            {
                W(Math.Round(res, 2, MidpointRounding.AwayFromZero));
            }

            int n = Convert.ToInt32("23");
            W(n);
            // n = Convert.ToInt32("2a3");      //НЕВЕРНЫЙ ФОРМАТ -> Exception
            W(n);
        }

        private static void MathTest()
        {
            W(".BigMul(5,4) = " + Math.BigMul(5,4));    //20
            W(".Ceiling(5,4) = " + Math.Ceiling(5.4));  //6
            W(".Floor(5.4) = " + Math.Floor(5.4));      //5
            W(".Sqrt(4) = " + Math.Sqrt(16));           //4
            W(".Sqrt(4) = " + Math.Truncate(16.345));   //16
        }

        private static void LazyTest()
        {
            Reader reader = new Reader();
            reader.ReadEbook();
            reader.ReadBookLazy();
            //reader.ReadBook();
        }

        private static void DateTimeTest()
        {
            var dateTime = new DateTime(1991, 11, 21, 12, 52, 44,  DateTimeKind.Unspecified);
            W(dateTime);
            var dt2 = dateTime.AddTicks(100);       //НАНОСЕКУ"НДНЫЕ ТАКТЫ
            W(dt2.Ticks);
            W(dt2.ToLocalTime());
            W("------------------------------------");
            DateTime now = DateTime.Now;
            WriteLine("D: " + now.ToString("D"));
            WriteLine("d: " + now.ToString("d"));
            WriteLine("F: " + now.ToString("F"));
            WriteLine("f: {0:f}", now);
            WriteLine("G: {0:G}", now);
            WriteLine("g: {0:g}", now);
            WriteLine("M: {0:M}", now);
            WriteLine("O: {0:O}", now);
            WriteLine("o: {0:o}", now);
            WriteLine("R: {0:R}", now);
            WriteLine("s: {0:s}", now);
            WriteLine("T: {0:T}", now);
            WriteLine("t: {0:t}", now);
            WriteLine("U: {0:U}", now);
            WriteLine("u: {0:u}", now);
            WriteLine("Y: {0:Y}", now);
            W("------------------------------------");
            W(now.ToString("yyyyy-zz"));
        }

        private static void TestIDisposed2()
        {
            using (PersonDstr p = new PersonDstr())
            {
                W("using");
            }
        }

        private static void TestIDisposed()
        {
            PersonDstr p = null;
            try
            {
                p = new PersonDstr();
            }
            finally
            {
                if (p != null)
                {
                    p.Dispose();
                }
            }
        }
        private static void TestDistructor()
        {
            var p = new PersonDstr();       //ДЕСТРУКТОР ВЫЗОВЕТСЯ В МОМЕНТ ЗАВЕРШЕНИЯ ПРОГРАММЫ

            ///сборщик мусора при размещении объекта в куче определяет, 
            /// поддерживает ли данный объект метод Finalize. 
            /// И если объект имеет метод Finalize, то указатель на него 
            /// сохраняется в специальной таблице, которая называется очередь финализации. 
        }


        private static void RegexIsMatchTest1()
        {
            string s = "456-435-2318";
            Regex regex = new Regex(@"\d{3}-\d{3}-\d{4}");

            W(Regex.IsMatch(s, @"\d{3}-\d{3}-\d{4}", RegexOptions.IgnoreCase) ? "DA" : "HET");

            Regex regex1 = new Regex(@"[2|3]{3}-[0-9]{3}-\d{4}"); //"222-222-2222" и "323-435-2318"

            string s1 = "Мама  мыла  раму. ";
            string pattern = @"\s*";
            string target = "v";
            Regex regex2 = new Regex(pattern);
            string result = regex.Replace(s1, target);
            W(result);
        }

        private static void RegexIsMatchTest()
        {
            string pattern = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                             @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";
            while (true)
            {
                Console.WriteLine("Введите адрес электронной почты");
                string email = Console.ReadLine();

                if (Regex.IsMatch(email ?? string.Empty, pattern, RegexOptions.IgnoreCase))
                {
                    Console.WriteLine("Email подтвержден");
                    break;
                }
                else
                {
                    Console.WriteLine("Некорректный email");
                }
            }
        }

        private static void RegexTest()
        {
            string s = "Бык тупогуб, туПогубенький бычок, у быка губа бела была тупа";
            W(s+Environment.NewLine);
            //var regexp = new Regex(@"туп(\w*)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            //var regexp = new Regex(@"ту п(\w*)", RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase); // @"ту п(\w*)" берется как "туп(\w*)"

            var patternArrey = new[] { @"ту п(\w*)", @"^Б\w*", @"\w*а$", @"б.ла", @"\w*\s\w*" };

            foreach (var pttrn in patternArrey)
            {
                var regexp = new Regex(pttrn, RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase); // @"ту п(\w*)" берется как "туп(\w*)"
                MatchCollection mtches = regexp.Matches(s);
                if (mtches.Count > 0)
                {
                    foreach (var item in mtches)
                    {
                        W(item);
                    }
                }
                else
                {
                    W("Нет совпадений!");
                }
                W("------------------------------------");
            }
        }

        private static void StringBuilderTest()
        {
            var sb = new StringBuilder("Hello world!");
            W(sb.Insert(sb.Length, " It's Me"));
            W(sb.Remove(0, 1));
            W(sb.Replace("world", "men"));
            W(sb.AppendFormat(" :)"));
        }

        private static void StringFormatTest()
        {
            int num = 23;
            W(String.Format("{0:C2}", num));    //23.00 $
            W("------------------------------------");
            W(String.Format("{0:d4}", num));    //0023
            W("------------------------------------");
            W(String.Format("{0:e}", num));     //23,00000000e+01
            W("------------------------------------");
            W(String.Format("{0:e}", num));     //23,00000000e+01
            W("------------------------------------");
            W(String.Format("{0:f5}", num));     //23,00000
            W("------------------------------------");
            W(String.Format("{0:g}", num));     //Задает более короткий из двух форматов: F или E
            W("------------------------------------");
            W(String.Format("{0:n3}", num));     //23,000
            W("------------------------------------");
            W(String.Format("{0:p}", num));     //2300,00 %
            W("------------------------------------");
            W(String.Format("{0:x}", num));     //17
        }

        private static void StringTest1()
        {
            var src = "1234567890";
            var dst = new[] {'a','b','c','d','e','f'};
            src.CopyTo(0, dst, 1, 3);     //a123ef
            ///c 0го символа SRC в DST, начиная с 1го симвога, вставляем 3 символа из SRC   
            W(dst);
        }

        private static void StringTest()
        {
            var s1 = "1";
            var s11 = "b";
            W(s1);
            W("------------------------------------");
            var s2 = null as string;
            W(s2 ?? "NULL");
            W("------------------------------------");
            var s3 = new string('a', 5);
            W(s3);
            W("------------------------------------");
            W(string.Compare(s1,s11, StringComparison.CurrentCulture));
            W(string.CompareOrdinal(s1, s11));
            W(string.Concat(s1,s11));
            W("------------------------------------");
            string strSource = "changed";
            char[] destination = { 'T', 'h', 'e', ' ', 'i', 'n', 'i', 't', 'i', 'a', 'l', ' ', 'a', 'r', 'r', 'a', 'y' };
            Console.WriteLine(destination);
            strSource.CopyTo(0, destination, 4, strSource.Length);
            Console.WriteLine(destination);
            W("*");
            strSource = "A different string";
            strSource.CopyTo(2, destination, 3, 9);
            Console.WriteLine(destination);
            W("------------------------------------");
            var strSource1 = "changed c";
            W(strSource.EndsWith("ed") ? "Yes" : "No");
            W("------------------------------------");
            W(string.Format("Hi, my name is {0}!", "Tom"));
            W("------------------------------------");
            W(strSource1.IndexOf('h'));
            W("------------------------------------");
            W(strSource1.Insert(strSource1.Length, " STR"));
            W("------------------------------------");
            W(string.Join("_", "P", "U", "N", "K", "S"));
            W("------------------------------------");
            W(strSource1.LastIndexOf("c", StringComparison.Ordinal));
            W("------------------------------------");
            W(strSource1.Replace("d c","d"));
            W("------------------------------------");
            W(strSource1.Substring(2, 3));
            W("------------------------------------");
            W(strSource1.Remove(4,2).ToUpper());
            W("------------------------------------");
        }

        private static void DataContractJsonSerializerTest()
        {
            var p1 = new SerializedPerson("Tom", 1951, new SerializeableCompany { Name = "Adidas" });
            var p2 = new SerializedPerson("Jack", 1992, new SerializeableCompany { Name = "Nike" });
            var p3 = new SerializedPerson("Ted", 1982);
            var formatter = new DataContractJsonSerializer(typeof(SerializedPerson[]));
            var filePath = FP("JsonSerialization.json");
            using (var fs = new FileStream(filePath, File.Exists(filePath) ? FileMode.Truncate : FileMode.OpenOrCreate))
            {
                formatter.WriteObject(fs, new[] { p1, p3, p2 });
                W("JSON Serialization Finished");
            }
            W(Environment.NewLine);

            using (var fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                var a = (SerializedPerson[])formatter.ReadObject(fs);
                W("Count: " + a.Length);
                W("Name: " + a.First().Name);
                W("Year: " + a.First().Year);
                W("Company: " + a.First().Company?.Name);
            }
        }

        private static void XmlSerializerTest()
        {
            var p1 = new SerializedPerson("Tom", 1951, new SerializeableCompany {Name = "Adidas"});
            var p2 = new SerializedPerson("Jack", 1992, new SerializeableCompany {Name = "Nike"});
            var p3 = new SerializedPerson("Ted", 1982);
            var formatter = new XmlSerializer(typeof(SerializedPerson[]));
            var filePath = FP("XmlSerialization.xml");
            using (var fs = new FileStream(filePath, File.Exists(filePath) ? FileMode.Truncate : FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, new[] { p1, p3, p2 });
                W("Serialization Finished");
            }
            W(Environment.NewLine);

            using (var fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
               var a = (SerializedPerson[])formatter.Deserialize(fs);
                W("Count: " + a.Length);
                W("Name: " + a.Last().Name);
                W("Year: " + a.Last().Year);
                W("Company: " + a.Last().Company?.Name);
            }
        }

        /// <summary>
        /// System.Runtime.Serialization.Formatters.Soap.dll
        /// </summary>
        private static void SoapFormatterTest()
        {
            var person = new SerializedPerson("Tom", 25);
            var person1 = new SerializedPerson("Sam", 31);
            var peoplw = new[] { person, person1 };
            var formatter = new SoapFormatter();
            using (var stream = new FileStream(FP("SoapFormatter.soap"), FileMode.OpenOrCreate))
            {
                formatter.Serialize(stream, peoplw);
            }

            using (var stramReader = new FileStream(FP("SoapFormatter.soap"), FileMode.OpenOrCreate))
            {
                var ps = formatter.Deserialize(stramReader) as SerializedPerson[];
                W(ps?.Select(r => r).Last().Name);
                W(ps?.Select(r => r).Last().Year);
            }
        }

        private static void BinaryFormatterTest()
        {
            var person = new SerializedPerson("Tom", 25);
            var person1 = new SerializedPerson("Sam", 31);
            var peoplw = new[] {person, person1};
            var formatter = new BinaryFormatter();
            using (var stream = new FileStream(FP("BinaryFormatter.dat"), FileMode.OpenOrCreate))
            {
                formatter.Serialize(stream, peoplw);
            }

            using (var stramReader = new FileStream(FP("BinaryFormatter.dat"), FileMode.OpenOrCreate))
            {
                var ps = formatter.Deserialize(stramReader) as SerializedPerson[];
                W(ps?.Select(r => r).Last().Name);
                W(ps?.Select(r => r).Last().Year);
            }
        }

        private static void GZipStreamDeflateStreamTest()
        {
            string sourceFile = FP("Pdf_1.pdf"); // исходный файл
            string compressedFile = FP("book.gz"); // сжатый файл
            string targetFile = FP("book_new.pdf"); // восстановленный файл

            // поток для чтения исходного файла
            using (FileStream sourceStream = new FileStream(sourceFile, FileMode.OpenOrCreate))
            {
                // поток для записи сжатого файла
                using (FileStream targetStream = File.Create(compressedFile))
                {
                    // поток архивации
                    using (GZipStream compressionStream = new GZipStream(targetStream, CompressionMode.Compress))
                    {
                        sourceStream.CopyTo(compressionStream); // копируем байты из одного потока в другой
                        Console.WriteLine("Сжатие файла {0} завершено. Исходный размер: {1}  сжатый размер: {2}.",
                            sourceFile, sourceStream.Length.ToString(), targetStream.Length.ToString());
                    }
                }
            }
            W("");
            // поток для чтения из сжатого файла
            using (FileStream sourceStream = new FileStream(compressedFile, FileMode.OpenOrCreate))
            {
                // поток для записи восстановленного файла
                using (FileStream targetStream = File.Create(targetFile))
                {
                    // поток разархивации
                    using (GZipStream decompressionStream = new GZipStream(sourceStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(targetStream);
                        Console.WriteLine("Восстановлен файл: {0}", targetFile);
                    }
                }
            }
        }

        private static void BinaryWriterReaderTest()
        {
            State[] states = new State[2];
            states[0] = new State("Германия", "Берлин", 357168, 80.8);
            states[1] = new State("Франция", "Париж", 640679, 64.7);

            string path = FP("states.dat");

            using (var b = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                foreach (var st in states)
                {
                    b.Write(st.name);
                    b.Write(st.area);
                    b.Write(st.capital);
                    b.Write(st.people);
                }
            }

            using (var br = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                while (br.PeekChar() > -1)
                {
                    var name = br.ReadString();
                    var cpital = br.ReadString();
                    var area = br.ReadInt32();
                    var people = br.ReadDouble();

                    W(name,cpital,area,people);
                }
            }
        }

        private static void StreamReaderWriterTest()
        {
            string ssr;
            using (var sr = new StreamReader(FP("StreamReader.txt")))
            {
                ssr = sr.ReadToEnd();
                W(ssr);
            }
            WriteLine("------------------");
            using (var sr = new StreamReader(FP("StreamReader.txt"), Encoding.Default))
            {
                string ln;
                while ((ln = sr.ReadLine()) != null)
                {
                    W(ln);
                }
            }
            WriteLine("------------------");
            using (var sr = new StreamReader(FP("StreamReader.txt"), Encoding.UTF8))
            {
                char[] arr = new char[4];
                sr.Read(arr, 0, 4);

                W(arr);

                using (var sw = new StreamWriter(FP("StreamReader2_NoEncoding.txt"), true))
                {
                    sw.Write(ssr);
                }
                using (var sw = new StreamWriter(FP("StreamReader2_Default.txt"), true, Encoding.Default))
                {
                    sw.Write(ssr);
                }
                using (var sw = new StreamWriter(FP("StreamReader2_UTF8.txt"), true, Encoding.UTF8))
                {
                    sw.Write(ssr);
                }
            }
        }


        private static void FileStramSeekTest()
        {
            string text = "hello world";
            // запись в файл
            using (FileStream fstream = new FileStream(FP("FileStreamTest1.txt"), FileMode.OpenOrCreate))
            {
                // преобразуем строку в байты
                byte[] input = Encoding.Default.GetBytes(text);
                // запись массива байтов в файл
                fstream.Write(input, 0, input.Length);
                Console.WriteLine("Текст записан в файл");

                // перемещаем указатель в конец файла, до конца файла- пять байт
                fstream.Seek(-5, SeekOrigin.End); // минус 5 символов с конца потока

                // считываем четыре символов с текущей позиции
                byte[] output = new byte[4];
                fstream.Read(output, 0, output.Length);
                // декодируем байты в строку
                string textFromFile = Encoding.Default.GetString(output);
                Console.WriteLine("Текст из файла: {0}", textFromFile); // worl

                // заменим в файле слово world на слово house
                string replaceText = "house";
                fstream.Seek(-5, SeekOrigin.End); // минус 5 символов с конца потока
                input = Encoding.Default.GetBytes(replaceText);
                fstream.Write(input, 0, input.Length);

                // считываем весь файл
                // возвращаем указатель в начало файла
                fstream.Seek(0, SeekOrigin.Begin);
                output = new byte[fstream.Length];
                fstream.Read(output, 0, output.Length);
                // декодируем байты в строку
                textFromFile = Encoding.Default.GetString(output);
                Console.WriteLine("Текст из файла: {0}", textFromFile); // hello house
            }

            ///FILESTREAM без Using'a НУЖНО ЗАКРЫВАТЬ

            //if (fstream != null)
                //fstream.Close();
        }

        private static void FileStramTest()
        {
            var di = new DirectoryInfo(TestFolder);
            if (!di.Exists)
            {
                di.Create();
            }
            W("Enter the text, please:");
            string txt = Console.ReadLine();
            W(string.Empty);

            ///нормализации текста, после которого он пригоден для сравнения.
            ///Композиция, декомпозиция, и преобразование экзотических символов
            ///В Unicode есть 4 вида нормализации. 
            /// 
            /// Первые два из них — композиция и декомпозиция — позволяют справиться со следующими проблемами:
            ///В Unicode одна и таже сложная буква типа «Ç» может быть представлена в двух формах:
            ///в виде единой буквы и в виде базовой буквы(«C») и модификаторов. Процесс, 
            /// при котором все буквы по возможности объединяются в одну, называется композицией
            ///  (Normalization Form C, далее — NFC), а процесс, при котором все буквы по
            ///  возможности разбиваются на модификаторы — декомпозицией(Normalization Form D, далее — NFD).
            ///
            /// Далее.Существует множество символов, типа вышепреведенной точки «．», которые выглядят очень похожими 
            /// на другие и могут быть подло использованы спамерами. 
            /// Специально для таких случаев существует Normalization Form KC (NFKC)и Normalization Form KD(NFKD),
            ///  которые, помимо(де)композиции, нормализуют следующие символы:
            ///
            /// Изощрённые шрифты(ℍ и ℌ)
            /// Кружки(①)
            /// Изменённый размер и угол поворота(ｶ и カ, ︷ и {)
            /// Степени(⁹ и ₉)
            /// Дроби(¼)
            /// Другие(™)

            var fp = FP("FileStreamTest.txt");
            if (!string.IsNullOrEmpty(txt))
            using (var fs = new FileStream(fp, FileMode.OpenOrCreate))
            {
                byte[] array = Encoding.Default.GetBytes(txt);
                fs.Write(array, 0, array.Length);
                W("Writing has DONE!");
            }
            W(string.Empty);
            if (File.Exists(fp))
            {
                using (var fs2 = File.OpenRead(fp))
                {
                    byte[] array2 = new byte[fs2.Length];
                    fs2.Read(array2, 0, array2.Length);
                    var res = Encoding.Default.GetString(array2);
                    W($"RESULT IS >>> {res}");
                }
            }
        }

        private static void DirectoryInfoTest2()
        {
            var subPath = "NewSub";
            var di = new DirectoryInfo(TestFolder);
            if (!di.Exists)
            {
                di.Create();
                di.CreateSubdirectory(subPath);
            }
            Directory.Delete(TestFolder, false);
        }

        private static void DirectoryInfoTest()
        {
            string dirName = "C:\\Program Files";

            DirectoryInfo dirInfo = new DirectoryInfo(dirName);

            Console.WriteLine("Название каталога: {0}", dirInfo.Name);
            Console.WriteLine("Полное название каталога: {0}", dirInfo.FullName);
            Console.WriteLine("Время создания каталога: {0}", dirInfo.CreationTime);
            Console.WriteLine("Корневой каталог: {0}", dirInfo.Root);
        }

        private static void DriveInfoTest()
        {
            var drvs = DriveInfo.GetDrives();
            foreach (var d in drvs)
            {
                W("Название: " + d.Name);
                W("Тип: " + d.DriveType);
                if (d.IsReady)
                {
                    W("Объем диска: " + d.TotalSize);
                    W("Свободное пространство: " + d.TotalFreeSpace);
                    W("Метка: " + d.VolumeLabel);
                }
            }
        }

        /// <summary>
        /// ИТЕРАТОР
        /// </summary>
        private static void YieldTest()
        {
            Numbers numbers = new Numbers();
            foreach (int n in numbers)
            {
                W(n);
            }
            WriteLine("------------------");
            var l = new Libra();
            foreach (Book one in l)
            {
                W(one.Name);
            }
            WriteLine("------------------");
            //foreach (Book one in l.GetMyEnumerator())
            //{
            //    W(one.Name);
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
                W(item.ToString());
            }
            //o.RemoveAt(1);
            foreach (var item in o)
            {
                W(item.ToString());
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

            W(act + " >> " + e.NewItems[0].ToString());
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
                    W(a.Last().Value);
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
                W(item.Value + " - " + item.Key);
            }
        }

        private static void StackTest()
        {
            var a = new Stack<int>();
            a.Push(1);
            a.Push(2);
            a.Push(3);
            W(a.Pop().ToString());
            W(a.Peek().ToString());
        }

        private static void QuueTest()
        {
            var a = new Queue<string>();
            a.Enqueue("a");
            a.Enqueue("b");
            a.Enqueue("c");

            var d = a.Dequeue();
            W(d);

            var e = a.Peek();
            W(e);
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
            Console.WriteLine("------------------");
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
            if (man2 is Boy)
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
            var men = new Man("Ilya");
            Console.WriteLine("------------------");
            var boy = new Boy("Nikola");
            Console.WriteLine("------------------");
            var boy2 =  men as Boy; //контрвариантнось не проходит
            boy2?.Say();
            Console.WriteLine("------------------");
            Man men2 = boy as Man;
            men2?.Say();
            Console.WriteLine("------------------");
            Boy bBoy = boy;
            bBoy?.SayMore();
            Console.WriteLine("------------------");
            boy?.SayMore();
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
