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
    /// Interaction logic for EditOrdersWindow.xaml
    /// </summary>
    public partial class EditOrdersWindow : Window
    {
        OrderTableAdapter orderTableAdapter = new OrderTableAdapter();
        public EditOrdersWindow()
        {
            InitializeComponent();
        }

        private void btnCreateOrderForCustomer_Click(object sender, RoutedEventArgs e)
        {
            int? orderId = null; // new order id that will be created
            int custId = int.Parse(txtCustIdForOrder.Text);
            DateTime? orderDate = DateTime.Now;
            int prodAmount = int.Parse(txtProductAmountForOrder.Text);
            
            orderTableAdapter.createOrderForCustomer(custId, orderDate, prodAmount, ref orderId);
            MessageBox.Show($"Successfully added order #{orderId} for cust #{custId} on {orderDate.ToString()}");

        }
        private void btnDeleteOrderByID_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int orderId = int.Parse(TxtOrderIdToDelete.Text);
                orderTableAdapter.deleteOrderById(orderId);
                MessageBox.Show($"Successfully deleted order #{orderId}!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
