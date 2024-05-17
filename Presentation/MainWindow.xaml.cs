using System;
using System.Windows;
using Domain.UseCase;
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
            RefreshDataGrid();
            studentDataGrid.CellEditEnding += studentDataGrid_CellEditEnding; 
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            _userViewModel.AddUser("SampleFirstName", "SampleLastName", 30, 100);
            RefreshDataGrid();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (studentDataGrid.SelectedItem != null)
            {
                
                Domain.Models.Core selectedUser = (Domain.Models.Core)studentDataGrid.SelectedItem;


            }
            else
            {
                MessageBox.Show("Please select a user to edit.");
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (studentDataGrid.SelectedItem != null)
            {
               
                Domain.Models.Core selectedUser = (Domain.Models.Core)studentDataGrid.SelectedItem;
                _userViewModel.RemoveUser(selectedUser.Id);
                RefreshDataGrid();
            }
            else
            {
                MessageBox.Show("Please select a user to remove.");
            }
        }

        private void RefreshDataGrid()
        {
            _userViewModel.RefreshData();
            studentDataGrid.ItemsSource = _userViewModel.Users;
        }

        private void studentDataGrid_CellEditEnding(object sender, System.Windows.Controls.DataGridCellEditEndingEventArgs e)
        {
            if (e.EditAction == System.Windows.Controls.DataGridEditAction.Commit)
            {
                var editedTextBox = e.EditingElement as System.Windows.Controls.TextBox;
                if (editedTextBox != null)
                {
                    var newValue = editedTextBox.Text;
                    
                    var selectedUser = (Domain.Models.Core)e.Row.Item;
                    
                    if (e.Column.Header.Equals("FirstName"))
                    {
                        selectedUser.FirstName = newValue;
                    }
                    else if (e.Column.Header.Equals("LastName"))
                    {
                        selectedUser.LastName = newValue;
                    }
                    else if (e.Column.Header.Equals("Age"))
                    {
                        int age;
                        if (int.TryParse(newValue, out age))
                        {
                            selectedUser.Age = age;
                        }
                        else
                        {
                            
                            MessageBox.Show("Please enter a valid age.");
                        }
                    }
                    else if (e.Column.Header.Equals("Points"))
                    {
                        int points;
                        if (int.TryParse(newValue, out points))
                        {
                            selectedUser.Points = points;
                        }
                        else
                        {
                            
                            MessageBox.Show("Please enter a valid points.");
                        }
                    }
                }
            }
        }
    }
}
