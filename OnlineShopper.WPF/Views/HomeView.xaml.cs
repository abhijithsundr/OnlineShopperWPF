using System.Windows;
using System.Windows.Controls;

namespace OnlineShopper.WPF.Views
{
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text;
            if (!string.IsNullOrEmpty(name) || !lstNames.Items.Contains(name))
            {
                lstNames.Items.Add(name);
                txtName.Clear();
            }
        }
    }
}
