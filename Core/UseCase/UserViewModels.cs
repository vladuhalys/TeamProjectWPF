using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCase
{
    public class UserViewModel
    {
        private readonly Core core;

        public ObservableCollection<Models.Core> Users { get; set; }    // ObservableCollection is used to update the UI automatically

        public UserViewModel()
        {
            core = new Core();
            Users = new ObservableCollection<Models.Core>(core.GetUsers());
        }

        public void RefreshData()
        {
            Users.Clear();
            List<Models.Core> users = core.GetUsers();
            foreach (var user in users)
            {
                Users.Add(user);
            }
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
            Users.Clear();
            foreach (var user in sortedUsers)
            {
                Users.Add(user);
            }
        }

        public void SortByAge()
        {
            List<Models.Core> sortedUsers = Users.OrderBy(u => u.Age).ToList();                  // (u => u.Age) - is used to sort by Age
            Users.Clear();
            foreach (var user in sortedUsers)
            {
                Users.Add(user);
            }
        }

        public void SortByName()
        {
            List<Models.Core> sortedUsers = Users.OrderBy(u => u.FirstName).ToList();           // (u => u.FirstName) - is used to sort by FirstName
            Users.Clear();
            foreach (var user in sortedUsers)
            {
                Users.Add(user);
            }
        }
    }

    internal class Core
    {
        public List<Models.Core> GetUsers()
        {
            return new List<Models.Core>
        {
            new Models.Core { Id = 1, FirstName = "John", LastName = "Doe", Age = 25, Points = 100 },
            new Models.Core { Id = 2, FirstName = "Jane", LastName = "Doe", Age = 30, Points = 200 },
            new Models.Core { Id = 3, FirstName = "Alice", LastName = "Smith", Age = 35, Points = 300 },
            new Models.Core { Id = 4, FirstName = "Bob", LastName = "Smith", Age = 40, Points = 400 }
        };
        }

        public void EditUser(int id, string firstName, string lastName, int age, int points) { }

        public void RemoveUser(int id) { }

        public void AddUser(string firstName, string lastName, int age, int points) { }
    }
}
