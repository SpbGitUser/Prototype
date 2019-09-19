using System;
using System.Collections.Generic;
using static ConsoleApp.Interfaces;

namespace ConsoleApp
{
    public class Classes
    {
        #region Event's

        internal class EventTester
        {
            public delegate void Eve(string smthngHappenns);
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

        internal class GenericSample<T> : IGenericIfs<string>
        {
            public string Value { get; set; }

            public T ClassValue { get; set; }
        }

        internal class Goer : IRunner, IStepper
        {
            void IRunner.Run()
            {
                Console.WriteLine("Fast run :)");
            }
            void IStepper.Run()
            {
                Console.WriteLine("Stepping may be faster ;)");
            }
        }

        internal abstract class Dancer : IMoveable, ISingable, ICloneable, IComparable<Dancer>
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
                Console.WriteLine("Mikron creaqted!");
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
                //Console.WriteLine("Man's Basic");
            }

            public Man(string name) : base()
            {
                _name = name;
                //Console.WriteLine("Man's Band");
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
                //Console.WriteLine("Boy's Band");
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

            public static implicit operator Boy(Women param)
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

        internal class Person
        {
            public string Name { get; set; }
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
                    var res = string.Empty;
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
