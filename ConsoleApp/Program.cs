using System;
using static System.Console;
using static ConsoleApp.Common.Utils;
using static ConsoleApp.Threading.ThreadingTests;
using static ConsoleApp.StaticTests.StaticTests;

namespace ConsoleApp
{
    public class Program
    {
        //--ЗАПУСК-------------------------------------------
        static void Main(string[] args)
        {
            try
            {
                W("-------------------- START --------------------" + Environment.NewLine);
                
                //тесты в виде статических методов
                RunStaticTests();
                //тестовые ситуации
                //QuestionTests();
                //потоки
                //RunThreading();
                
                ReadKey();
                W(Environment.NewLine + "------------------- THE_END -------------------");
            }
            catch (Exception e)
            {
                WriteLine("[!!!] ВЕРХНИЙ УРОВЕНЬ:" + Environment.NewLine + e.Message);
            }
        }
    }
}
