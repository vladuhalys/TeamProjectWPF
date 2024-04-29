using Domain.UseCase;
using System.Windows;

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
                var dialogResult = new EditUserDialog((Domain.Models.Core)studentDataGrid.SelectedItem);
                var save = dialogResult.ShowDialog();
                if (save == true)
                {
                    var viewmodel = (EditUserVeiwModel)dialogResult.DataContext;
                    var user = new Domain.Models.Core
                    {
                        Id = viewmodel.Id,
                        FirstName = viewmodel.FirstName,
                        LastName = viewmodel.LastName,
                        Age = viewmodel.Age,
                        Points = viewmodel.Points
                    };
                    _userViewModel.RemoveUser(selectedUser.Id);
                    _userViewModel.AddUser("SampleFirstName", "SampleLastName", 30, 100);
                }
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