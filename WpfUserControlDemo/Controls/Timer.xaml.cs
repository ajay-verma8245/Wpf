namespace WpfUserControlDemo.Controls
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
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

    /// <summary>
    /// Interaction logic for Timer.xaml
    /// </summary>
    public partial class Timer : UserControl
    {
        private int _seconds = 0;
        private DispatcherTimer _timer = new DispatcherTimer();
        public Timer()
        {
            InitializeComponent();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += TimerTicking;
        }

        private void TimerTicking(object sender, EventArgs e)
        {
            _seconds += 1;
            _ElapsedTimer.Text = _seconds.ToString();
        }

        private void btnStartTimer_Click(object sender, RoutedEventArgs e)
        {
            _timer.Start();
        }

        private void btnStopTimer_Click(object sender, RoutedEventArgs e)
        {
            _timer.Stop();
        }
    }
}
