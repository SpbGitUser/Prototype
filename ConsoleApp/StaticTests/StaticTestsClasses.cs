using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace ConsoleApp.StaticTests
{
    public class NumberGetHashCode
    {
        private int n;

        public NumberGetHashCode(int value)
        {
            n = value;
        }

        public int Value
        {
            get { return n; }
        }

        public override bool Equals(Object obj)
        {
            if (obj == null || !(obj is NumberGetHashCode))
                return false;
            else
                return n == ((NumberGetHashCode)obj).n;
        }

        public override int GetHashCode()
        {
            return 1;
            //return n;
        }

        public override string ToString()
        {
            return n.ToString();
        }
    }

    internal class MailManager
    {
        // Этап 2. Определение члена-события
        public event EventHandler<NewMailEventArgs> NewMail;
    }

    internal class NewMailEventArgs : EventArgs
    { }


    internal partial class PartialTest_1
    {
        partial void Do(int a);

        public int A(int b)
        {
            return 32;
        }

        //public double A(int b)
        //{
        //    return 32.2;
        //}
    }

    internal partial class PartialTest_1
    {
        partial void Do(int a)
        {
            Console.WriteLine("Partial_" + a);
        }

        internal void DoExt(int a)
        {
            Do(a);
        }
    }

    public class Phone
    {
        public const int Number = 1231;

        public Phone() {}

        public void Deal()
        {
           Console.WriteLine("Phone.Deal");
            Cnn();
        }

        public virtual void Cnn()
        {
            Console.WriteLine("Phone.Cnn");
        }
    }

    public class PhoneNew : Phone
    {
        public PhoneNew() {}

        //public new void Deal()
        //{
        //    Console.WriteLine("Phone.Deal");
        //    Cnn();
        //}

        public override void Cnn()
        {
            Console.WriteLine("PhoneNew.Cnn");
        }
    }

    public interface IClass123
    {
    }
    public static class Class_1 
    {
        
    }
    public static  class Class_2 
    { 
    }

    public struct Stru_1 : IClass123
    {
    }
    public struct Stru_2 //: Stru_1 - только от интерфейсов
    {
    }

    public static class Class123
    {
        static Class123()
        {
        }

        public static string A => "asd";
    }

    //НЕВОЗМОЖНО наследование для статических классов
    //public static class Class124 : Class123 ОБРАТИ ВНИМАНИЕ!!!! === ОБРАТИ ВНИМАНИЕ!!!! === ОБРАТИ ВНИМАНИЕ!!!! ОБРАТИ ВНИМАНИЕ!!!! ==
    //{}

    public struct MyStruct
    {
        public int Abc;
    }
    // ОБРАТИ ВНИМАНИЕ!!!! === ОБРАТИ ВНИМАНИЕ!!!! === ОБРАТИ ВНИМАНИЕ!!!! ОБРАТИ ВНИМАНИЕ!!!! ==
    //наследование от структуры невозможно
    //public struct MyStruct2 : MyStruct
    //{

    //}

    public class StaticTestsClasses
    {
        internal class MyException1 : MyException
        {
            public MyException1(string mes) : base(mes)
            {
            }
        }

        internal class MyException2 : MyException1
        {
            public MyException2(string mes) : base(mes)
            {
            }
        }


        internal class Int : IInt1, IInt2
        {
            public int a { get; set; }
            public int b { get; set; }
        }

        internal interface IInt1
        {
            int a { get; set; }
        }

        internal interface IInt2
        {
            int b { get; set; }
        }


        internal class NoModificator
        {
            string Abc => "ca";
        }

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

        public interface IInt1123 : IInt112311
        {
        }

        public interface IInt112311
        {
        }

        public class Wrap : IDisposable, ICloneable 
        {
            private static int init = 0;
            public int Value
            {
                get
                {
                    return ++init;
                }
            }

            public void Dispose()
            {
                //throw new NotImplementedException();
            }

            public object Clone()
            {
                throw new NotImplementedException();
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

        [Serializable]
        public class DclNetSettings
        {
            public DclNetSettings() { }

            public InetPaysSettings InetPays { get; set; }
        }

        [Serializable]
        public class InetPaysSettings
        {
            public InetPaysSettings() { }

            /// <summary>
            /// РАУНД: адрес для обращения (новый)
            /// </summary>
            public string PayHdServerAddress { get; set; }

            /// <summary>
            /// Таможенная Карта: отправитель
            /// </summary>
            public string CustomsCardSenderInformation { get; set; }

            /// <summary>
            /// Таможенная Карта: получатель
            /// </summary>
            public string CustomsCardReceiverInformation { get; set; }

            /// <summary>
            /// Таможенная Карта: адрес для обращения
            /// </summary>
            public string CustomsCardServer { get; set; }

            /// <summary>
            /// Таможенная Карта: адрес для обращения - резервный
            /// </summary>
            public string CustomsCardServerReserve { get; set; }

            /// <summary>
            /// Таможенная Карта: архив - адрес для обращения
            /// </summary>
            public string CustomsCardServerArch { get; set; }

            /// <summary>
            /// Таможенная Карта: архив - адрес для обращения - резервный
            /// </summary>
            public string CustomsCardServerArchReserve { get; set; }
        }

        #region LINQ

        internal class Player
        {
            public string Name { get; set; }
            public string Team { get; set; }
        }
        internal class Team
        {
            public string Name { get; set; }
            public string Country { get; set; }
        }

        internal class User
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public List<string> Languages { get; set; }
            public User()
            {
                Languages = new List<string>();
            }
        }

        #endregion


        #region Threading

        internal class SemaphoreReader
        {
            private static Semaphore _sem = new Semaphore(3,3);
            private Thread _myThread;
            private int _countSem = 3;

            public SemaphoreReader(int i)
            {
                _myThread = new Thread(Read);
                _myThread.Name = $"SEMAFORE_THREAD {i}";
                _myThread.Start();
            }

            public void Read()
            {
                while (_countSem > 0)
                {
                    _sem.WaitOne();

                    Console.WriteLine($"{Thread.CurrentThread.Name} входит в библиотеку");
                    Console.WriteLine($"{Thread.CurrentThread.Name} читает");
                    Thread.Sleep(1000);
                    Console.WriteLine($"{Thread.CurrentThread.Name} покидает библиотеку");

                    _sem.Release();

                    _countSem--;
                    Thread.Sleep(600);

                }
            }
        }

        #endregion Threading


        #region Lazy

        public class Reader
        {
            Library _library = new Library();
            Lazy<Library2> _library2 = new Lazy<Library2>();

            public void ReadBook()
            {
                _library.GetBook();
                Console.WriteLine("ЧИТАТЕЛЬ - Читаем бумажную книгу");
            }

            /// <summary>
            /// [!!!] Lazy вызывается через .VALUE
            /// </summary>
            public void ReadBookLazy()
            {
                _library2.Value.GetBook();
                Console.WriteLine("ЧИТАТЕЛЬ - Читаем бумажную книгу");
            }

            public void ReadEbook()
            {
                Console.WriteLine("ЧИТАТЕЛЬ - Читаем книгу на компьютере");
            }
        }


        public class Library
        {
            private string[] books = new string[99];

            public void GetBook()
            {
                Console.WriteLine("БИБИЛИОТЕКА - Выдаем книгу читателю");
            }
        }

        public class Library2
        {
            private string[] books = new string[99];

            public void GetBook()
            {
                Console.WriteLine("БИБИЛИОТЕКА LAZY - Выдаем книгу читателю");
            }
        }

        #endregion Lazy


        #region Destructor

        public class PersonDstr : IDisposable
        {
            public void Dispose()
            {
                Console.Beep();
                Console.WriteLine("--- Disposed!");

                ///[!!!] После вызова метода Dispose необходимо блокировать у 
                /// объекта вызов метода Finalize с помощью GC.SuppressFinalize

                // подавляем финализацию
                GC.SuppressFinalize(this);

                ///При создании производных классов от базовых, которые реализуют интерфейс 
                /// IDisposable, следует также вызывать метод Dispose базового класса:
                // base.Dispose(disposing);
            }

            ~PersonDstr()
            {
                Console.WriteLine("Destructed");
            }
        }

        #endregion


        #region Сериализация

        /// <summary>
        /// Сериализация представляет процесс преобразования какого-либо объекта в поток байтов
        /// </summary>
        /// Формат сериализации
        /// - бинарный      BinaryFormatter
        /// - SOAP          SoapFormatter
        /// - xml           XmlSerializer
        /// - JSON          DataContractJsonSerializer
        /// 
        /// Для классов BinaryFormatter и SoapFormatter
        /// public interface IFormatter
        //{
        //    SerializationBinder Binder { get; set; }
        //    StreamingContext Context { get; set; }
        //    ISurrogateSelector SurrogateSelector { get; set; }
        //    object Deserialize(Stream serializationStream);
        //    void Serialize(Stream serializationStream, object graph);
        //}

        [Serializable]
        public class SerializedPerson    // XML SERIALIZATION  - только Public
        {
            public string Name { get; set; }
            public int Year { get; set; }
            public SerializeableCompany Company { get; set; }

            [NonSerialized]
            public string AccNumber = String.Empty;

            public SerializedPerson()
            {
            }

            public SerializedPerson(string name, int year, string acc)
            {
                Name = name;
                Year = year;
                AccNumber = acc;
            }

            public SerializedPerson(string name, int year, SerializeableCompany cmp = null)
            {
                Name = name;
                Year = year;
                Company = cmp;
            }
        }

        [Serializable]
        public class SerializeableCompany
        {
            public string Name { get; set; }

            // стандартный конструктор без параметров
            public SerializeableCompany() { }

            public SerializeableCompany(string name)
            {
                Name = name;
            }
        }

        [Serializable]
        public class SerializedPersonSon : SerializedPerson
        {
            public SerializedPersonSon(string name, int year, string acc) : base(name, year, acc)
            {
            }
        }


        #endregion Сериализация


        #region Binary Reader / Writer

        internal struct State
        {
            public string name;
            public string capital;
            public int area;
            public double people;

            public State(string n, string c, int a, double p)
            {
                name = n;
                capital = c;
                people = p;
                area = a;
            }
        }

        #endregion Binary Reader / Writer


        #region Итератор / yield

        internal class Book
        {
            public string Name { get; set; }

            public Book(string n)
            {
                Name = n;
            }
        }

        internal class Libra
        {
            private Book[] _books;

            public Libra()
            {
                _books = new Book[]
                {
                    new Book("Pushkin"),
                    new Book("Tolstoy"),
                    new Book("Petrov"),
                    new Book("Gogol")

                };
            }

            public int Len => _books.Length;

            public IEnumerator GetEnumerator()
            {
                foreach (var item in _books)
                {
                    yield return item;

                    if (item.Name == "Petrov")
                    {
                        yield break;
                    }
                }
            }

            internal IEnumerator GetMyEnumerator()
            {
                foreach (var item in _books)
                {
                    yield return item;
                    if (item.Name == "Petrov")
                    {
                        yield break;
                    }
                }
            }
        }
        
        internal class Numbers
        {
            public IEnumerator GetEnumerator()
            {
                for (int i = 0; i < 6; i++)
                {
                    yield return i * i;
                }
            }
        }
        
        #endregion Итератор / yield


        #region ДеКОНструктор ( > С# 7.0)

        internal class Person4
        {
            public string Name { get; set; }
            public int Age { get; set; }

            public void Deconstruct(out string name, out int age)
            {
                name = this.Name;
                age = this.Age;
            }

            //Паттерн свойств
            //static string GetMessage(Person p) => p switch
            //{
            //    { Language: "english" } => "Hello!",
            //    { Language: "german", Status: "admin" } => "Hallo!",
            //    { Language: "french" } => "Salut!",
            //    { } => "Hello world!"
            //};

            //static string GetWelcome(string lang, string daytime) => (lang, daytime) switch
            //{
            //    ("english", "morning") => "Good morning",
            //    ("english", "evening") => "Good evening",
            //    ("german", "morning") => "Guten Morgen",
            //    ("german", "evening") => "Guten Abend",
            //    _ => "Здрасьть"
            //};

            //Нам не обязательно сравнивать все значения кортежа, мы можем использовать только некоторые элементы кортежа.В случае, если мы не хотим использовать элемент кортежа, то вместо него ставим прочерк:
            //static string GetWelcome(string lang, string daytime, string status) => (lang, daytime, status) switch
            //{
            //    ("english", "morning", _) => "Good morning",
            //    ("english", "evening", _) => "Good evening",
            //    ("german", "morning", _) => "Guten Morgen",
            //    ("german", "evening", _) => "Guten Abend",
            //    (_, _, "admin") => "Hello, Admin",
            //    _ => "Здрасьть"
            //};
        }

        #endregion


        #region Pattern matching

        internal class Employee3
        {
            public virtual void Work()
            {
                Console.WriteLine("Да работаю я, работаю");
            }
        }

        internal class Manager3 : Employee3
        {
            public override void Work()
            {
                Console.WriteLine("Отлично, работаем дальше");
            }
            public bool IsOnVacation { get; set; }
        }

        #endregion Pattern matching


        #region Частичные классы / методы

        internal partial class PartialTest
        {
            public PartialTest(string name)
            {
                Name = name;
            }

            partial void Hi();

            public void HI2()
            {
                Hi();
            }

            public string Name { get; set; }
        }

        internal partial class PartialTest
        {
            public void SayName()
            {
                Console.WriteLine($"My name is {Name}!");
            }

            partial void Hi()
            {
                Console.WriteLine("Hi!");
            }
        }
        
        #endregion Частичные классы / методы


        #region Ковариантность и контравариантность делегатов

        internal class Person1
        {
            public string Name { get; set; }
        }
        internal class PersonChild1 : Person1 { }

        // VVV В обощенных делегатах

        internal class Person2
        {
            public string Name { get; set; }
            public virtual void Display() => Console.WriteLine($"Person {Name}");
        }
        internal class Client2 : Person2
        {
            public override void Display() => Console.WriteLine($"Client {Name}");
        }

        #endregion Ковариантность и контравариантность делегатов


        #region Event'ы и лямбда-делегаты

        internal class MyEventArgs
        {
            public MyEventArgs(string m, int v)
            {
                Msg = m;
                Val = v;
            }

            public string Msg { get; set; }

            public int Val { get; set; }
        }

        internal class EventTester
        {
            public delegate void EventDelegate(object sender, MyEventArgs args);

            public delegate void Operation4(int x);

            public event EventDelegate OnMyEventIn;

            public event EventDelegate OnMyEventOut;

            public event Operation4 OnLabdaEvent;

            public int Age { get; set; } = 18;

            private int _sum;

            public void MakeIt()
            {
                OnMyEventIn(this, new MyEventArgs("Tom", 16));
                OnMyEventOut(this, new MyEventArgs("Jack", 21));
            }

            public void MakeIt1()
            {
                OnLabdaEvent(12);
            }

            public void MakeIt2(Operation4 lmb)
            {
                lmb(77);
            }
        }

        #endregion Event's


        #region Делегаты

        internal static class DelegateInside
        {
            public delegate void SaySmthhng(string text);
            delegate int Operation(int x, int y);

            public static void Check()
            {
                SaySmthhng saySmthhng;
                saySmthhng = SayerMethod;
                saySmthhng("Bu-ga-ga");
            }

            public static void Check2()
            {
                // присваивание адреса метода через контруктор
                Operation del = Add; // делегат указывает на метод Add
                int result = del(4, 5); // фактически Add(4, 5)
                Console.WriteLine(result);

                del = Multiply; // теперь делегат указывает на метод Multiply
                result = del(4, 5); // фактически Multiply(4, 5)
                Console.WriteLine(result);
            }

            public static void Check3()
            {
                SaySmthhng saySmthhng;
                SaySmthhng saySmthhng1;

                saySmthhng = SayerMethod;
                saySmthhng += SayerMethod2;

                saySmthhng1 = SayerMethod;
                saySmthhng("GO");
                
                saySmthhng -= saySmthhng1;
                saySmthhng("Ya");

                saySmthhng1.Invoke("INvoke done");
            }

            public static void Check4(SaySmthhng sms)
            {
                sms.Invoke("Bro");
            }

            private static void SayerMethod(string txt)
            {
                Console.WriteLine("1raz - " + txt);
            }

            internal static void SayerMethod2(string txt)
            {
                Console.WriteLine("2raz - " + txt);
            }


            private static int Add(int x, int y)
            {
                return x + y;
            }
            private static int Multiply(int x, int y)
            {
                return x * y;
            }
        }


        #endregion Делегаты


        #region Контрвариантность

        internal interface ITransaction<in T>
        {
            void DoOperation(T account, int sum);
        }

        internal class Transaction<T> : ITransaction<T> where T : Account
        {
            public void DoOperation(T account, int sum)
            {
                account.DoTransfer(sum);
            }
        }

        #endregion


        #region Ковариантность

        //Ковариантность: позволяет использовать более конкретный тип, чем заданный изначально
        //Контравариантность: позволяет использовать более универсальный тип, чем заданный изначально
        //Инвариантность: позволяет использовать только заданный тип

        internal class Account
        {
            public virtual void DoTransfer(int sum)
            {
                Console.WriteLine($"Клиент положил на счет {sum} долларов");
            }
        }
        internal class DepositAccount : Account
        {
            public override void DoTransfer(int sum)
            {
                Console.WriteLine($"Клиент положил на депозитный счет {sum} долларов");
            }
        }
        
        internal interface IBank<out T>
        {
            T CreateAccount(int sum);
        }

        internal class Bank<T> : IBank<T> where T : Account, new()
        {
            public T CreateAccount(int sum)
            {
                T acc = new T();  // создаем счет
                acc.DoTransfer(sum);
                return acc;
            }
        }

        #endregion Ковариантность


        #region Контрвариантность


        #endregion Контрвариантность


        #region Comparer / Сравнение

        internal class PunkComparer:IComparer<Punk>
        {
            public int Compare(Punk r1, Punk r2)
            {
                return r2?.Name.Length - r1?.Name.Length ?? 0;
            }
        }

        #endregion Comparer / Сравнение


        #region Interfaces / Интерфейсы

        internal class GenericSample<T> : Interfaces.IGenericIfs<string>
        {
            public string Value { get; set; }

            public T ClassValue { get; set; }
        }

        internal class Goer : Interfaces.IRunner, Interfaces.IStepper
        {
            void Interfaces.IRunner.Run()
            {
                Console.WriteLine("Fast run :)");
            }
            void Interfaces.IStepper.Run()
            {
                Console.WriteLine("Stepping may be faster ;)");
            }
        }

        internal abstract class Dancer : Interfaces.IMoveable, Interfaces.ISingable, ICloneable, IComparable<Dancer>
        {
            public abstract void Move();

            public abstract void Sing();

            public abstract object Clone();

            public string Name { get; set; }

            public int CompareTo(Dancer o)
            {
                return Name.Length - ((Dancer) o).Name.Length;
            }
        }

        internal class Punk : Dancer
        {
            public override void Move()
            {
                Console.WriteLine("Dance Pogo!");
            }

            public override void Sing()
            {
                Console.WriteLine("Hoy!");
            }

            public override object Clone()
            {
                return new Punk() {Name = "PUNK ASS - " + this.Name};
            } 
        }

        internal class Raper : Dancer
        {
            public override void Move()
            {
                Console.WriteLine("Brake dance!");
            }

            public override void Sing()
            {
                Console.WriteLine("Yo!");
            }

            public Punk Friend { get; set; }

            public override object Clone()
            {
                //return new Punk() { Name = "DANCER - " + this.Name };
                return this.MemberwiseClone();
            }
        }
        
        #endregion Interfaces / Интерфейсы


        #region Exceptions / Исключения

        internal class MyException : Exception
        {
            public MyException(string mes) : base(mes)
            {
            }
        }

        internal class ExceptionTestClass
        {
            public static void Method1()
            {
                try
                {
                    Method2();
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine($"Catch в Method1 : {ex.Message}");
                }
                //catch (Exception ex)      // <<< ЕСЛИ БУДЕТ АКТИВНЫМ, ТО ПЕРЕХВАТИТ СИКЛЮЧЕНИЕ ИМЕННО ОН
                //{
                //    Console.WriteLine($"GENERAL Catch в Method1 : {ex.Message}");
                //}
                finally
                {
                    Console.WriteLine("Блок finally в Method1");
                }
                Console.WriteLine("Конец метода Method1");
            }
            static void Method2()
            {
                try
                {
                    int x = 8;
                    int y = x / 0;
                }
                finally
                {
                    Console.WriteLine("Блок finally в Method2");
                }
                Console.WriteLine("Конец метода Method2");
            }
        }

        #endregion


        #region Generics / Обобщения

        internal class Account<T>
        {
            public static T Value;

            public T Id { get; private set; } // номер счета
            public int Sum { get; set; }
            public Account(T id)
            {
                Id = id;
            }
        }

        internal class MyAccount : Account<string>
        {
            public MyAccount(string id) : base(id)
            {
            }
        }

        internal class Transaction1<T> where T : Account<int>
        {
            public T FromAcc { get; private set; }

            public T ToAcc { get; private set; }

            public Transaction1(T from, T to)
            {
                FromAcc = from;
                ToAcc = to;
            }
        }

        #endregion Generics / Обобщения


        #region Наследование (inheritance) / преобразование типов

        internal class Mikron
        {
            public Mikron()
            {
                //SConsole.WriteLine("Mikron creaqted!");
            }
        }

        /// <summary>
        /// Человек
        /// </summary>
        internal abstract class Human : Mikron
        {
            public string SurName { get; set; }

            public abstract ushort Age { get; set; }

            public void SayType()
            {
                Console.WriteLine(this.GetType().ToString());
            }
        }

        internal abstract class Homosapien : Human
        {
            
        }

        /// <summary>
        /// Мужчина
        /// </summary>
        internal /*sealed*/ class Man : Human
        {
            public Man()
            {
                Console.WriteLine("Man's Constructor");
            }

            public Man(string name) : base()
            {
                _name = name;
                Console.WriteLine("Man's Constructor +size");
            }

            private string _name;
            public virtual string Name
            {
                get { return _name; }
                set { _name = value; }
            }

            public override ushort Age { get; set; }

            public virtual void Say()
            {
                //Интерполя́ция, интерполи́рование — в вычислительной математике способ нахождения 
                //промежуточных значений величины по имеющемуся дискретному набору известных значений.

                Console.WriteLine($"Hi! I'm MAN {_name}.");
            }
        }

        /// <summary>
        /// Мальчик
        /// </summary>
        internal class Boy : Man
        {
            public Boy(string boyName) : base(boyName)
            {
                Console.WriteLine("Boy's COnstructor");
            }

            public virtual void SayMoreMore()
            {
                Console.WriteLine($"MoreMore - Boy's name is {Name}!");
            }

            public void SayMore()
            {
                Console.WriteLine($"Boy's name is {Name}!");
            }

            public override void Say()
            {
                Console.WriteLine($"Boy {Name}");
            }
        }

        /// <summary>
        /// Парень
        /// </summary>
        internal class BigBoy : Boy
        {
            public BigBoy(string boyName) : base(boyName)
            {
                _name = boyName;
            }

            private string _name;
            public override string Name
            {
                get
                {
                    return $"{_name} ;)";
                }
                set
                {
                    _name = value;
                }
            }


            public override void SayMoreMore()
            {
                Console.WriteLine($"MoreMore - BIG boy's name is {Name}!");
            }


            public new void SayMore()
            {
                Console.WriteLine($"BIG boy's name is {Name}!");
            }

            public static explicit operator BigBoy(string name)
            {
                var bb = new BigBoy(name);
                return bb;
            }

            public override void Say()
            {
                Console.WriteLine($"BigBoy {Name}");
            }
        }

        /// <summary>
        /// Женщина
        /// </summary>
        internal class Women : Human
        {
            public Women(string womenName) //: base(boyName)
            {
                //Console.WriteLine("Women's Band");
                Name = womenName;
            }
            
            public string Name { get; set; }

            public override ushort Age { get; set; }

            public void SayMore()
            {
                Console.WriteLine($"Women's name is {Name}!");
            }

            public static explicit operator Boy(Women param)
            {
                var boy = new Boy(param.Name);
                return boy;
            }

            public static implicit operator Women(string name)
            {
                var res = new Women(name);
                return res;
            }

            public void Say()
            {
                Console.WriteLine($"I'm WOMEN - {Name}");
            }
        }

        #endregion Наследование (inheritance) / преобразование типов


        #region Indextors / Индексаторы

        internal class Person : IDisposable 
        {
            public Person()
            { }

            public Person(string name)
            {
                throw new Exception("BAM2!");
            }

            public string Name { get; set; }
            
            public void Dispose()
            {
                Console.WriteLine("Disposed - " + Name);
            }
        }

        internal class People
        {
            private Person[] _data;

            public People()
            {
                _data = new Person[5];
            }

            public Person this[int index]
            {
                get
                {
                    return _data[index];
                }
                set
                {
                    _data[index] = value;
                }
            }
            public string this[string index]
            {
                get
                {
                    var res = String.Empty;
                    switch (index)
                    {
                        case "1":
                            res = _data[0].Name;
                            break;
                        case "2":
                            res = _data[1].Name;
                            break;
                        case "3":
                            res = _data[2].Name;
                            break;
                        case "4":
                            res = _data[3].Name;
                            break;
                        case "5":
                            res = _data[4].Name;
                            break;
                    }
                    return res;
                }
            }
        }

        #endregion Indextors / Индексаторы


        #region Статической свойство

        internal class WithStaticMemeber
        {
            public static int Age { get; set; }

            public string Name { get; set; }
        }

        #endregion Статической свойство


        #region Перегрузка оператора

        internal class Counter
        {
            public static Counter operator +(Counter c1, Counter c2)
            {
                return new Counter { Value = c1.Value + c2.Value };
            }

            public int Value { get; set; }
        }

        #endregion Перегрузка оператора
    }
}
