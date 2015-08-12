using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PasswordKeeper
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Singleton.Start();
        }
    }
}
