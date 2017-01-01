using System.Windows;
using System.Windows.Media.Animation;

namespace WpfAnimatingPath
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

        private void btnStartAnimation_Click(object sender, RoutedEventArgs e)
        {
            Storyboard storyBoard = FindResource("pointAnimationBoard") as Storyboard;
            storyBoard.Begin(this);
        }
    }
}
