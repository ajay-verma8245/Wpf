namespace WpfCustomValidation
{
    using System.Collections.Generic;
    using System.Windows;
    using Models;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Child> _children = new List<Child>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _children.Add(new Child { Name = "John", Age = 12 });
            _children.Add(new Child { Name = "Sally", Age = 30 });
            _children.Add(new Child { Name = "Roman", Age = 55 });
            pnlChildren.DataContext = _children;
        }

        private void btnMessage_Click(object sender, RoutedEventArgs e)
        {
            ImageWindow window = new ImageWindow();
            window.Show();
            Close();
        }
    }
}
