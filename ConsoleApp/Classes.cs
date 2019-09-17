using System;

namespace ConsoleApp
{
    public class Classes
    {

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

        internal class Transaction<T> where T : Account<int>
        {
            public T FromAcc { get; private set; }

            public T ToAcc { get; private set; }

            public Transaction(T from, T to)
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
