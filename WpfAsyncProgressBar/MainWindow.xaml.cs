using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfAsyncProgressBar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int _counter = 0;
        private bool _isCanceled = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnBeginProcess_Click(object sender, RoutedEventArgs e)
        {
            bdrProgress.Visibility = Visibility.Visible;
            new Thread(delegate ()
            {
                DoLongRunningProcess();
            }).Start();
        }

        private void btnInteractWithUI_Click(object sender, RoutedEventArgs e)
        {
            Title = _counter++.ToString();
        }

        private void btnCancelProgress_Click(object sender, RoutedEventArgs e)
        {
            _isCanceled = true;
        }

        private void DoLongRunningProcess()
        {
            Thread.Sleep(2000);
            if (!_isCanceled)
            {
                Dispatcher.BeginInvoke(DispatcherPriority.Background, (SendOrPostCallback)delegate { prgProgressBar.SetValue(ProgressBar.ValueProperty, .5); }, null);

                Dispatcher.BeginInvoke(DispatcherPriority.Background, (SendOrPostCallback)delegate { txtProgress.SetValue(TextBox.TextProperty, "50%"); }, null);

                Thread.Sleep(2000);
                if (!_isCanceled)
                {
                    Dispatcher.BeginInvoke(DispatcherPriority.Background, (SendOrPostCallback)delegate { prgProgressBar.SetValue(ProgressBar.ValueProperty, 1.0); }, null);

                    Dispatcher.BeginInvoke(DispatcherPriority.Background, (SendOrPostCallback)delegate { txtProgress.SetValue(TextBox.TextProperty, "100%"); }, null);

                    Dispatcher.BeginInvoke(DispatcherPriority.Background, (SendOrPostCallback)delegate { bdrProgress.SetValue(Border.VisibilityProperty, Visibility.Collapsed); }, null);
                }
            }
        }
    }
}
