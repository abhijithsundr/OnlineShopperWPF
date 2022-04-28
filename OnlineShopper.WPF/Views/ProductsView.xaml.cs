using System;
using System.Linq.Expressions;
using System.Windows;
using System.Windows.Controls;
using OnlineShopper.Domain.Models;
using OnlineShopper.Domain.Services.Transactions.Facade;
using OnlineShopper.WPF.State.Authenticators;
using OnlineShopper.WPF.ViewModels;

namespace OnlineShopper.WPF.Views
{
    public partial class ProductsView : UserControl
    {
        public ProductsView()
        {
            InitializeComponent();
        }

        private void btnAll_Click(object sender, RoutedEventArgs e)
        {
            ((ProductsViewModel)(this.DataContext)).LoadProductsCommand.Execute(null);
        }

        private void btnDesktops_Click(object sender, RoutedEventArgs e)
        {
            Expression<Func<Product, bool>> expr = x => x.Category.Equals(Category.Desktops);
            ((ProductsViewModel)(this.DataContext)).LoadProductsCommand.Execute(expr);
        }

        private void btnLaptops_Click(object sender, RoutedEventArgs e)
        {
            Expression<Func<Product, bool>> expr = x => x.Category.Equals(Category.Laptops);
            ((ProductsViewModel)(this.DataContext)).LoadProductsCommand.Execute(expr);
        }

        private void btnMobiles_Click(object sender, RoutedEventArgs e)
        {
            Expression<Func<Product, bool>> expr = x => x.Category.Equals(Category.Mobiles);
            ((ProductsViewModel)(this.DataContext)).LoadProductsCommand.Execute(expr);
        }

        private void btnAccessories_Click(object sender, RoutedEventArgs e)
        {
            Expression<Func<Product, bool>> expr = x => x.Category.Equals(Category.Accessories);
            ((ProductsViewModel)(this.DataContext)).LoadProductsCommand.Execute(expr);
        }

        private void btnBuy_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product product = (Product)(((Button)sender).DataContext);
                ((ProductsViewModel)(this.DataContext)).BuyProductCommand.Execute(product.Id);
                MessageBox.Show(((ProductsViewModel)(this.DataContext)).StatusMessage);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void btnSellForCash_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product product = (Product)(((Button)sender).DataContext);
                ((ProductsViewModel)(this.DataContext)).SellProductForCashCommand.Execute(
                    product.Id
                );
                MessageBox.Show(((ProductsViewModel)(this.DataContext)).StatusMessage);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void btnSellForVoucher_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product product = (Product)(((Button)sender).DataContext);
                ((ProductsViewModel)(this.DataContext)).SellProductForVoucherCommand.Execute(
                    product.Id
                );
                MessageBox.Show(((ProductsViewModel)(this.DataContext)).StatusMessage);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
    }
}
