using System.Windows.Forms;

namespace ConsoleApp
{
    /// <summary>
    /// Методы расширения
    /// </summary>
    internal static class MyExtensions
    {
        internal static void ToMsgBox(this string str)
        {
            MessageBox.Show(str);
        }
    }
}
