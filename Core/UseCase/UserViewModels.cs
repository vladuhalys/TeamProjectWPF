using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Domain.Models;

namespace Domain.UseCase
{
    public class UserViewModel
    {
        private readonly Core core;

        public ObservableCollection<Models.Core> Users { get; set; }    // ObservableCollection is used to update the UI automatically

        public UserViewModel()
        {
            core = new Core();
            RefreshData();
        }

        public void RefreshData()
        {
            Users = new ObservableCollection<Models.Core>(core.GetUsers());
        }

        public void EditUser(int id, string firstName, string lastName, int age, int points)
        {
            core.EditUser(id, firstName, lastName, age, points);
            RefreshData();
        }

        public void RemoveUser(int id)
        {
            core.RemoveUser(id);
            RefreshData();
        }

        public void AddUser(string firstName, string lastName, int age, int points)
        {
            core.AddUser(firstName, lastName, age, points);
            RefreshData();
        }

        public void SortByPoints()
        {
            List<Models.Core> sortedUsers = Users.OrderByDescending(u => u.Points).ToList();    // (u => u.Points) - is used to sort by Points
            Users = new ObservableCollection<Models.Core>(sortedUsers);
        }

        public void SortByAge()
        {
            List<Models.Core> sortedUsers = Users.OrderBy(u => u.Age).ToList();                  // (u => u.Age) - is used to sort by Age
            Users = new ObservableCollection<Models.Core>(sortedUsers);
        }

        public void SortByName()
        {
            List<Models.Core> sortedUsers = Users.OrderBy(u => u.FirstName).ToList();           // (u => u.FirstName) - is used to sort by FirstName
            Users = new ObservableCollection<Models.Core>(sortedUsers);
        }
    }

    public class Core
    {
        private List<Models.Core> users; // Поле для зберігання списку користувачів

        public Core()
        {
            // Ініціалізуємо список користувачів
            users = new List<Models.Core>
            {
                new Models.Core { Id = 1, FirstName = "John", LastName = "Doe", Age = 25, Points = 100 },
                new Models.Core { Id = 2, FirstName = "Jane", LastName = "Doe", Age = 30, Points = 200 },
                new Models.Core { Id = 3, FirstName = "Alice", LastName = "Smith", Age = 35, Points = 300 },
                new Models.Core { Id = 4, FirstName = "Bob", LastName = "Smith", Age = 40, Points = 400 }
            };
        }

        public List<Models.Core> GetUsers()
        {
            return users;
        }

        public void AddUser(string firstName, string lastName, int age, int points)
        {
            int id = users.Count > 0 ? users.Max(u => u.Id) + 1 : 1; 
            users.Add(new Models.Core { Id = id, FirstName = firstName, LastName = lastName, Age = age, Points = points });
        }

        public void RemoveUser(int id)
        {
            Models.Core userToRemove = users.FirstOrDefault(u => u.Id == id);
            if (userToRemove != null)
            {
                users.Remove(userToRemove);
            }
        }

        public void EditUser(int id, string firstName, string lastName, int age, int points)
        {
            Models.Core userToEdit = users.FirstOrDefault(u => u.Id == id);
            if (userToEdit != null)
            {
                userToEdit.FirstName = firstName;
                userToEdit.LastName = lastName;
                userToEdit.Age = age;
                userToEdit.Points = points;
            }
        }
    }
}
