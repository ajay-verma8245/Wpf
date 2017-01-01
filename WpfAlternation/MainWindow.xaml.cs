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
using WpfAlternation.Models;

namespace WpfAlternation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            lstEmployees.ItemsSource = GetEmployees();
        }

        private List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee { FirstName ="Ajay", LastName="Verma" },
                new Employee { FirstName ="Rahul", LastName="Singh" },
                new Employee { FirstName ="Mukesh", LastName="Ambani" },
                new Employee { FirstName ="Mitesh", LastName="Gupta" },
                new Employee { FirstName ="Ravi", LastName="Teja" },
                new Employee { FirstName ="Mihir", LastName="Soni" },
                new Employee { FirstName ="Mithila", LastName="Maresh" },
                new Employee { FirstName ="Mohan", LastName="Jodaro" },
                new Employee { FirstName ="Raja", LastName="Swami" },
                new Employee { FirstName ="Hrithik", LastName="Roshan" },
                new Employee { FirstName ="Subham", LastName="Gupta" },
                new Employee { FirstName ="Sri", LastName="Babu" },
                new Employee { FirstName ="Rohit", LastName="Soni" }
            };
            return employees;
        }
    }
}
