
namespace ConsoleApp
{
    /// <summary>
    ///  Interfaces / Интерфейсы
    /// </summary>
    internal class Interfaces
    {


        internal interface IGenericIfs<T>
        {
            T Value { get; set; }
        }


        internal interface IIndexerINside
        {
            string this[string index]
            {
                get;
                set;
            }
        }
        
        internal interface IMoveable
        {
            void Move();

            string Name { get; }
        }

        internal interface ISingable
        {
            void Sing();
        }

        internal interface IRunner
        {
            void Run();
        }
        
        internal interface IStepper
        {
            void Run();
        }
    }
}
