using Store.CustomerOrderDSTableAdapters;
using Store.OrderDsTableAdapters;
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
using System.Windows.Shapes;

namespace Store
{
    /// <summary>
    /// Interaction logic for CustomerOrdersByID.xaml
    /// </summary>
    public partial class CustomerOrdersByID : Window
    {
        CustomerOrderDS customerOrderDs = new CustomerOrderDS();
        CustomerTableAdapter customerTableAdapter = new CustomerTableAdapter();
        OrderTableAdapter orderTableAdapter = new OrderTableAdapter();
        public CustomerOrdersByID()
        {
            InitializeComponent();
        }

        private void btnShowOrdersForCustomer_Click(object sender, RoutedEventArgs e)
        {
            int custId = int.Parse(txtCustIDforOrders.Text);
            this.TB_Customer_Orders.ItemsSource = orderTableAdapter.selectOrderByCustomerId(custId);
            this.TB_Customer_Orders.Columns[1].Visibility = Visibility.Collapsed;
        }
    }
}
