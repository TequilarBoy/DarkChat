using DarkChat.Cryptography;
using DarkChat.Helpers;
using System;
using System.Windows.Forms;

namespace DarkChat
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMainServer());
        }
    }
}
