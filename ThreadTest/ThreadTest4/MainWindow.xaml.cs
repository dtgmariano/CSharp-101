using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

namespace ThreadTest4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<DateTime> dt = new List<DateTime>();

            for (int i = 0; i < 1000; i++)
            {
                dt.Add(DateTime.Now);
                tbInfo.Text = "Processing: " + i;
                Thread.Sleep(50);
            }

            //List<TimeSpan> ts = new List<TimeSpan>();
            TimeSpan ts;
            List<int> intervals = new List<int>();

            for (int i = 0; i < dt.Count() - 1; i++)
            {
                ts = (dt[i + 1].TimeOfDay - dt[i].TimeOfDay);
                intervals.Add(ts.Milliseconds);
            }

            List<int> distinct = intervals.Distinct().ToList();

            tbInfo.Text = (intervals.Count().ToString() + " " + distinct.Count().ToString());
        }
    }
}
