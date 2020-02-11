using System;
using System.Linq;
using System.Reflection;
using Common;
using ConsoleApp.ADO.Net;
using static System.Console;
using static ConsoleApp.Common.Utils;
using static ConsoleApp.Threading.ThreadingTests;
using static ConsoleApp.StaticTests.StaticTests;

namespace ConsoleApp
{

    public class Program
    {
        /// <summary>
        /// --ЗАПУСК-------------------------------------------
        /// </summary>
        public static void Main(string[] args)
        {
            try
            {
                var repeater = ConsoleKey.Enter;
                while (repeater == ConsoleKey.Enter)
                {
                    W("-------------------- START --------------------" );
                    Enums.StarterMode mode;
                    do
                    {
                        W(Environment.NewLine);
                        W("SELECT MODE:" + Environment.NewLine);
                        W("> 1 - StaticTests");
                        W("> 2 - QuestionTests");
                        W("> 3 - Threading");
                        W("> 4 - ADO.Net");
                        var key = ReadKey();
                        var keyChar = key.KeyChar.ToString();
                        try
                        {
                            var modeId = int.Parse(keyChar);
                            if (!Enum.IsDefined(typeof(Enums.StarterMode), modeId))
                            {
                                throw new Exception(string.Empty);
                            }
                            mode = (Enums.StarterMode) Enum.ToObject(typeof(Enums.StarterMode), modeId);
                            if (mode != Enums.StarterMode.Unknown)
                            {
                                W(Environment.NewLine);
                                W($"------SELECTED MODE IS {mode} --------------------" + Environment.NewLine);
                            }
                        }
                        catch
                        {
                            mode = Enums.StarterMode.Unknown;
                        }
                    } while (mode == Enums.StarterMode.Unknown);

                    switch (mode)
                    {
                        case Enums.StarterMode.StaticTests:
                            //тесты в виде статических методов
                            RunStaticTests();
                            break;
                        case Enums.StarterMode.QuestionTests:
                            //тестовые ситуации
                            QuestionTests();
                            break;
                        case Enums.StarterMode.Threading:
                            //потоки
                            RunThreading();
                            break;
                        case Enums.StarterMode.AdoNet:
                            AdoStarter.Run();
                            break;
                    }
                    W(Environment.NewLine + "------------------- THE_END -------------------");
                    W(Environment.NewLine);
                    W("One more?");
                    var key1 = ReadKey();
                    repeater = (ConsoleKey) key1.KeyChar;
                }
            }
            catch (Exception e)
            {
                WriteLine("[!!!][TOP_ERROR}:" + Environment.NewLine + e.Message);
                ReadKey();
            }
        }
    }
}
