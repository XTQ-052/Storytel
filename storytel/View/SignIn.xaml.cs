using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace storytel.View
{
	/// <summary>
	/// Interaction logic for SignIn.xaml
	/// </summary>
	public partial class SignIn : Window
	{
		public SignIn()
		{
			InitializeComponent();
		}

		private void loginInRegister_btn_Click(object sender, RoutedEventArgs e)
		{
			SignUp_stckpnl.Visibility = Visibility.Hidden;
			SignIn_stckpnl.Visibility = Visibility.Visible;
		}

		private void registerInLogin_btn_Click(object sender, RoutedEventArgs e)
		{
			SignIn_stckpnl.Visibility = Visibility.Hidden;
			SignUp_stckpnl.Visibility = Visibility.Visible;
		}

		private void storytelLogoInSignIn_btn_Click(object sender, RoutedEventArgs e)
		{
			SignInXaml.Visibility = Visibility.Hidden;
		}

		private void fullname_txtbox_GotFocus(object sender, RoutedEventArgs e)
		{
			TextBox tb = (TextBox)sender;
			tb.Text = string.Empty;
			tb.GotFocus -= fullname_txtbox_GotFocus;
			tb.Foreground = Brushes.Black;
		}

		private void register_btn_Click(object sender, RoutedEventArgs e)
		{
			string connectionString = "Data Source=DESKTOP-DNH8G00;Initial Catalog=Storytel;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
			SqlConnection sqlConnection = new SqlConnection(connectionString);

			try
			{
				if (sqlConnection.State == ConnectionState.Closed)
				{
					sqlConnection.Open();
					string query = $"INSERT INTO Users ([username], [password], [fullname], [age], [location]) VALUES({username_txtbox.Text}, {password_txtbox.Text}, {fullname_txtbox.Text}, {age_txtbox.Text}, {location_txtbox.Text})";

					SqlCommand command = new SqlCommand(query, sqlConnection);
				}
			}
			catch (Exception)
			{
				MessageBox.Show("Error In SQL Connection");
			}
		}
	}
}
