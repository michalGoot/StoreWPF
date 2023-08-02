using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using Store.CustomerOrderDSTableAdapters;
using Store.OrderDsTableAdapters;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Store
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class EditCustomersWindow : Window
    {
        CustomerOrderDS customerOrderDs = new CustomerOrderDS();
        OrderTableAdapter orderTableAdapter = new OrderTableAdapter();
        CustomerTableAdapter customerTableAdapter = new CustomerTableAdapter();

        public EditCustomersWindow()
        {
            //דוגמאות

            InitializeComponent();
            
            customerTableAdapter.Fill(customerOrderDs.Customer);
        }

        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);
                return Convert.ToBase64String(hashBytes);
            }
        }
        private void InsertCustomerClick(object sender, RoutedEventArgs e)
        {
            int? customerId = null;
            string password = txtCustPassword.Password;
            bool isValidPassword = CheckValidPassword(password);
            string email = txtCustEmail.Text;
            bool isValidEmail = CheckValidEmail(email);
            if (isValidPassword && isValidEmail)
            {
                string encryptedPassword = HashPassword(password);
                customerTableAdapter.createNewCustomer(txtInsertCustomerName.Text, encryptedPassword, email, ref customerId);
                txtInsertCustomerId.Text = customerId.ToString();
                MessageBox.Show($"Successfully added {txtInsertCustomerName.Text}!");
            }
            else
            {
                MessageBox.Show("The email or password does not meet the requirements!");
                return;
            }
        }

        private bool CheckValidEmail(string email)
        {
            string emailPattern = @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$";
            if (Regex.IsMatch(email, emailPattern))
            {
                return true;
            }
            return false;
        }

        private bool CheckValidPassword(string password)
        {
            string passwordPattern = @"^(?=.*[a-z])(?=.*[A-Z]).{8,}$";
            if (Regex.IsMatch(password, passwordPattern))
            {
                return true;
            }
            return false;
        }

        private void DeleteCustomerClick(object sender, RoutedEventArgs e)
        {

            int id = 0;
            if (int.TryParse(this.txtDeleteCustomerId.Text, out id))
            {
                int success = Convert.ToInt32(customerTableAdapter.deleteCustomerById(id));
                deleteStatus.Text = success == 1 ? "Succeeded" : "Failed";
            }
            else
                deleteStatus.Text = "Invalid Customer Id";
        }

        private void UpdateCustomerClick(object sender, RoutedEventArgs e)
        {
            int id = 0;
            if (int.TryParse(this.txtUpdateCustomerId.Text, out id))
            {
                int success = Convert.ToInt32(customerTableAdapter.updateCustomerById(id, txtUpdateNewCustomerName.Text));
                updateStatus.Text = success == 1 ? "Succeeded" : "Failed";
            }
            else
                updateStatus.Text = "Invalid Customer Id";
        }

        

    }

}
