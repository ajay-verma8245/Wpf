using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace WpfBusyIndicator
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

        private void btnProgrss_Click(object sender, RoutedEventArgs e)
        {
            progressBar.IsBusy = true;

            Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                    {
                        progressBar.BusyContent = String.Format("Running thread : {0}", i);
                    }));
                    Thread.Sleep(1000);
                }
            }).ContinueWith((task) =>
            {
                progressBar.IsBusy = false;
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
