using System;
using System.Windows;

namespace HotelAccounting
{
    internal class Program
    {
        [STAThread]
        public static void Main()
        {
            var data = new My_AccountingModel();
            var wnd = new MainWindow();
            wnd.DataContext = data;
            new Application().Run(wnd);
        }
    }
}