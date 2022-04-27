using System;
using System.Collections.Generic;
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
using OnlineShopper.Domain.Services.Facade;
using OnlineShopper.WPF.ViewModels;

namespace OnlineShopper.WPF.Controls
{
    public partial class ProfileCard : UserControl
    {
        public ProfileCard()
        {
            InitializeComponent();
        }

        private async void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var stringNumber = txtAmount.Text;
            double numericValue;
            bool isParsable = double.TryParse(stringNumber, out numericValue);

            if (!isParsable)
            {
                MessageBox.Show("Please enter an amount");
                return;
            }

            await ((ProfileViewModel)(this.DataContext)).AddMoney(numericValue);

            MessageBox.Show("Success");

            txtAmount.Text = string.Empty;

            return;
        }
    }
}
