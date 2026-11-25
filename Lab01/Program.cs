using System;
using System.Windows.Forms;
using Lab01.Forms;

namespace Lab01
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm());
        }
    }
}
