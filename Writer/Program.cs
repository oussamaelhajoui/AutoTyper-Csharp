using System;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Input;

namespace Writer
{
    class Program
    {
        private static KeyStates _key;
        [STAThread]
        static void Main(string[] args)
        {
            Thread th = new Thread(Keyboardd);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            while (true) 
            {
                if (_key == KeyStates.Toggled)
                {
                    SendKeys.SendWait("AutoTyper Test🤗 {ENTER}");
                    //Console.WriteLine("hi");
                    Thread.Sleep(50);
                }
            }
        }

        public static void Keyboardd()
        {
            while (true)
            {
                Thread.Sleep(50);
                _key = Keyboard.GetKeyStates(Key.RightCtrl);
                Console.WriteLine(_key);
            }
        }
    }
}
