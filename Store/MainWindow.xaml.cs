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

namespace Store
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // HELP!!!
        //יצרנו אובייקט של ADO.NET
        /*
         * עוזר להתחבר מהפרוייקט של cs לdb
         * מחליף את השיטה של sqlConnection
         * משתמשים באובייקט בשם dataAdapter 
         * שעוזר להתחבר בצורה יותר קלה לדאטאבייס
         * דרך האדפטר ניתן להשתמש בפרוצדורות ובשאילתות פשוטות של SQL
         * יצרנו קובץ XSD (DataSet)
         * וגררנו אליו את הטבלאות שהגדרנו בדאטאבייס
         * ודרכו ניתן להגדיר את כל הפרוצדורות שהגדרנו ולהריץ אותן
         * כיוון שלהריץ שאילתות פשוטות זה לא בטוח (קוד זדוני) השתמשנו בפרוצדורות בלבד
         * זאת טכניקה יותר מהירה וחוסכת המון שורות קוד
         * והרבה יותר ויזואלית וברורה לעין
         */
        CustomerOrderDS customerOrderDs = new CustomerOrderDS();
        OrderDs orderDs = new OrderDs();
        OrderTableAdapter orderTableAdapter = new OrderTableAdapter();
        CustomerTableAdapter customerTableAdapter = new CustomerTableAdapter();
        public MainWindow()
        {

            InitializeComponent();

            this.Costumer_TB.ItemsSource = customerTableAdapter.GetData();



        }



        private void btnEditCustomers_Click(object sender, RoutedEventArgs e)
        {
            EditCustomersWindow adminWindow = new EditCustomersWindow();
            adminWindow.Show();
        }
        private void btnViewOrdersForCustomer_Click(object sender, RoutedEventArgs e)
        {
            Window ordersWindow = new CustomerOrdersByID();
            ordersWindow.Show();
        }
        private void btnManageOrdersNav_Click(object sender, RoutedEventArgs e)
        {
            EditOrdersWindow ordersWindow = new EditOrdersWindow();
            ordersWindow.Show();
        }
        private void btnNavToEmail_Click(object sender, RoutedEventArgs e)
        {
            EmailForm emailForm = new EmailForm();
            emailForm.Show();
        }


    }
}
