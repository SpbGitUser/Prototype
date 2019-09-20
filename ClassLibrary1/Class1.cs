using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ClassLibrary1
{
    [ComVisible(true)]
    [Guid("82B579BE-64D9-4F97-BBFC-FFB8597C364D")]
    public class Class1
    {
        private string mes;
        public Class1()
        {
            mes = "Hi!";
        }

        public void Say()
        {
            MessageBox.Show(mes);
        }
    }

    [Guid("4ACF7988-55F2-4BE1-9FD5-4CCB0BE83335")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    [ComVisible(true)]
    public interface IClass1
    {
        void Say();
    }
}
