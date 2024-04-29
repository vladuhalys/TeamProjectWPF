using System.Windows;

namespace Presentation
{
    public partial class EditUserDialog : Window
    {
        public EditUserDialog(Domain.Models.Core user)
        {
            InitializeComponent();
            DataContext = new EditUserVeiwModel(user);
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
