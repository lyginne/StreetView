using System;
using System.Windows.Forms;
using StreetView.Windows;

namespace StreetView
{
    static class MainClass
    {
        [STAThread]
        static void Main()
        {
            Application.Run(new MainWindow());
        }
    }
}
