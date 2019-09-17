using System;

namespace ConsoleApp
{
    public class Classes
    {

        #region Наследование (inheritance)

        internal /*sealed*/ class Man
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
            public string Name
            {
                get { return _name; }
                set { _name = value; }
            }

            public void Say()
            {
                //Интерполя́ция, интерполи́рование — в вычислительной математике способ нахождения 
                //промежуточных значений величины по имеющемуся дискретному набору известных значений.

                Console.WriteLine($"Hi! I'm {_name}.");
            }
        }

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
        }

        #endregion Наследование (inheritance)



        #region Indextors

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

        #endregion Indextors


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
