using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp
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

        private void btnShowMessage_Click(object sender, RoutedEventArgs e)
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_datareader;

            // create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;New=True;Compress=True;");

            // open the connection:
            sqlite_conn.Open();

            // create a new SQL command:
            sqlite_cmd = sqlite_conn.CreateCommand();

            // Let the SQLiteCommand object know our SQL-Query:
            sqlite_cmd.CommandText = "CREATE TABLE test (id integer primary key, text varchar(100));";

            // Now lets execute the SQL ;D
            sqlite_cmd.ExecuteNonQuery();

            // Lets insert something into our new table:
            sqlite_cmd.CommandText = "INSERT INTO test (id, text) VALUES (1, 'Test Text 1');";

            // And execute this again ;D
            sqlite_cmd.ExecuteNonQuery();

            // ...and inserting another line:
            sqlite_cmd.CommandText = "INSERT INTO test (id, text) VALUES (2, 'Test Text 2');";

            // And execute this again ;D
            sqlite_cmd.ExecuteNonQuery();

            // But how do we read something out of our table ?
            // First lets build a SQL-Query again:
            sqlite_cmd.CommandText = "SELECT * FROM test";

            // Now the SQLiteCommand object can give us a DataReader-Object:
            sqlite_datareader = sqlite_cmd.ExecuteReader();

            // The SQLiteDataReader allows us to run through the result lines:
            string data = "";
            while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
                data += sqlite_datareader.GetString(1) + "\n";

            MessageBox.Show(data);
            // We are ready, now lets cleanup and close our connection:
            sqlite_conn.Close();
        }

        private void imageFade_MouseLeave(object sender, MouseEventArgs e)
        {
            Image ladyImage = sender as Image;
            DoubleAnimation ladyAnimation = new DoubleAnimation(0.5, TimeSpan.FromSeconds(2));
            ladyImage.BeginAnimation(Image.OpacityProperty, ladyAnimation);
        }

        private void imageFade_MouseEnter(object sender, MouseEventArgs e)
        {
            Image ladyImage = sender as Image;
            DoubleAnimation ladyAnimation = new DoubleAnimation(1, TimeSpan.FromSeconds(2));
            ladyImage.BeginAnimation(Image.OpacityProperty, ladyAnimation);
        }
    }
}
