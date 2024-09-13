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

namespace ProductApps
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Product cProduct;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                cProduct = new Product(Convert.ToDecimal(priceTextBox.Text), Convert.ToInt16(quantityTextBox.Text));

                // Calculate the total payment for the product
                cProduct.calTotalPayment();

                // Display the total payment in the totalPaymentTextBlock
                totalPaymentTextBlock.Text = Convert.ToString(cProduct.TotalPayment);

                // Add the delivery charge of $25 to the total payment
                decimal totalWithDelivery = cProduct.TotalPayment + 25;

                // Display the total payment including the delivery charge in totalChargeTextBlock
                totalChargeTextBlock.Text = totalWithDelivery.ToString("C");

                // Add the Wrapping Charge of $5 to the Total with Delivery
                decimal totalWithDeliveryWrap = cProduct.TotalPayment + 25 + 5;

                totalChargeAfterWrapTextBlock.Text = totalWithDeliveryWrap.ToString("C");

                //Add GST to total Bill
                decimal deliveryWrapCost = totalWithDeliveryWrap; // Delivery and wrap costs
                decimal gstRate = 1.1m; // GST rate (10% GST)
                decimal totalWithDeliveryWrapGST = (deliveryWrapCost * gstRate);

                totalChargeAfterGSTTextBlock.Text = totalWithDeliveryWrapGST.ToString("C");
            }
            catch (FormatException)
            {
                // Show error message if there's a data entry issue
                MessageBox.Show("Enter data again", "Data Entry Error");
            }
        }


        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            productTextBox.Text = "";
            priceTextBox.Text = "";
            quantityTextBox.Text = "";
            totalPaymentTextBlock.Text = "";
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
