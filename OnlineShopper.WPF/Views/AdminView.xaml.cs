using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using OnlineShopper.Domain.Models;
using OnlineShopper.Domain.Services.Facade;
using OnlineShopper.Data;
using OnlineShopper.WPF.ViewModels;

namespace OnlineShopper.WPF.Views
{
    public partial class AdminView : UserControl
    {
        public AdminView()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Product product = new();

            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Name should not be empty");
                return;
            }

            product.ProductName = txtName.Text;

            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                MessageBox.Show("Description should not be empty");
                return;
            }

            product.ProductDescription = txtDescription.Text;

            var comboItem = (ComboBoxItem)ddlCat.SelectedItem;
            Enum.TryParse(comboItem.Content.ToString(), out Category cat);
            product.Category = cat;

            double buyPrice;
            if (!double.TryParse(txtBuyPrice.Text, out buyPrice))
            {
                MessageBox.Show("Buy price is not in the correct format");
                return;
            }

            product.BuyPrice = buyPrice;

            double sellPrice;
            if (!double.TryParse(txtSellPrice.Text, out sellPrice))
            {
                MessageBox.Show("Buy price is not in the correct format");
                return;
            }

            product.SellPrice = sellPrice;

            double voucherPrice;
            if (!double.TryParse(txtVoucherPrice.Text, out voucherPrice))
            {
                MessageBox.Show("Selling price is not in the correct format");
                return;
            }

            product.VoucherPrice = voucherPrice;

            int inventory;
            if (!int.TryParse(txtInventory.Text, out inventory))
            {
                MessageBox.Show("Inventory is not in the correct format");
                return;
            }

            product.Inventory = inventory;

            try
            {
                ((AdminViewModel)this.DataContext).AddProductCommand.Execute(product);
                MessageBox.Show(((AdminViewModel)this.DataContext).StatusMessage);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
