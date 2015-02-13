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
using System.Windows.Shapes;
using System.ComponentModel;
using System.Windows.Threading;
using System.Diagnostics;

namespace Thread_102
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BackgroundWorker worker = new BackgroundWorker();
        Stopwatch sw = new Stopwatch();

        public MainWindow()
        {
            InitializeComponent();
            
            for (int i = 0; i < 100; i++)
            {

            }
        }

        private void btnGo_Click(object sender, RoutedEventArgs e)
        {
            worker.RunWorkerAsync(100);
        }

    }
}
