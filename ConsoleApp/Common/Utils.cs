using System;
using System.Linq;
using System.Windows.Forms;

namespace ConsoleApp.Common
{
    internal static class Utils
    {

        //--КОНСТАНТЫ-----------------------------------------

        internal const string TestFolder = @"D:\Test\";

        //--ДОП. МЕТОДЫ--------------------------------------

        internal static void W(params object[] s) => Console.WriteLine(String.Join(" ", s.Select(r => r.ToString())));
        internal static void W(char[] s) => W(String.Join(String.Empty, s.Select(r => r.ToString())));

        internal static string FP(string fileName)
        {
            return $"{TestFolder}{fileName}";
        }


        internal static void ToMsgBox(this string str)
        {
            MessageBox.Show(str);
        }
    }
}
