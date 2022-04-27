using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using OnlineShopper.Domain.Models;
using OnlineShopper.Domain.Services.Facade;
using OnlineShopper.Data;

namespace OnlineShopper.WPF.Views
{
    public partial class AdminView : UserControl
    {
        public AdminView()
        {
            InitializeComponent();
        }

        // private void btnAdd_Click(object sender, RoutedEventArgs e)
        // {
        //     string name = txtName.Text;
        //     if (!string.IsNullOrEmpty(name) || !lstNames.Items.Contains(name))
        //     {
        //         lstNames.Items.Add(name);
        //         txtName.Clear();
        //     }
        // }
        
    }
}
