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
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data.OleDb;
using System.Data;
using System.Text.RegularExpressions;
using System.Configuration;

namespace MyUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection con = new SqlConnection();
        
        public MainWindow()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-EVKTK6O\\SQLEXPRESS;Initial Catalog=MyUI;Integrated Security=True";
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-EVKTK6O\\SQLEXPRESS;Initial Catalog=MyUI;Integrated Security=True";
            con.Open();
            string userid = Username1.Text;
            string password = Password1.Password;
            SqlCommand cmd = new SqlCommand("select Username,Password from LoginDetails where Username='" + Username1.Text + "'and Password='" + Password1.Password + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Login success Welcome to Homepage");
                System.Diagnostics.Process.Start("https://www.github.com/zzako?=repositories");
            }
            else
            {
                MessageBox.Show("Invalid Login please check username and password");
            }
            con.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-EVKTK6O\\SQLEXPRESS;Initial Catalog=MyUI;Integrated Security=True";
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into LoginDetails values (@Username, @Password)", con);
            cmd.Parameters.AddWithValue("Username", Username1.Text);
            cmd.Parameters.AddWithValue("Password", Password1.Password); cmd.ExecuteNonQuery();

            MessageBox.Show("User registered successfully");
            Username1.Text = "";
            Password1.Password = "";
            Username1.Focus();

        }
    }
}
