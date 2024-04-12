using Domain.UseCase;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Domain.Models;

namespace Presentation
{
    public partial class MainWindow : Window
    {
        private readonly UserViewModel _userViewModel;

        public MainWindow()
        {
            InitializeComponent();
            _userViewModel = new UserViewModel();
            studentDataGrid.ItemsSource = _userViewModel.Users;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            _userViewModel.AddUser("SampleFirstName", "SampleLastName", 30, 100);
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (studentDataGrid.SelectedItem != null)
            {
                var selectedUser = (Domain.Models.Core)studentDataGrid.SelectedItem;

                int newAge = 40;
                int newPoints = 150;

                _userViewModel.EditUser(selectedUser.Id, selectedUser.FirstName, selectedUser.LastName, newAge, newPoints);
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (studentDataGrid.SelectedItem != null)
            {
                var selectedUser = (Domain.Models.Core)studentDataGrid.SelectedItem;

                _userViewModel.RemoveUser(selectedUser.Id);
            }
        }
    }
}