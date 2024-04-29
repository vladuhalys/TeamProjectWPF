using System;
using Domain.UseCase;
using Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.ObjectModel;

namespace UnitTests
{
    [TestClass]
    public class UserViewModelTests
    {
        [TestMethod]
        public void AddUser_WithValidData_ShouldAddUser()

        {
            // Arrange
            var userViewModel = new UserViewModel();
            var initialCount = userViewModel.Users.Count;

            // Act
            userViewModel.AddUser("John", "Doe", 25, 100);

            // Assert
            Assert.AreEqual(initialCount + 1, userViewModel.Users.Count);
        }

        [TestMethod]
        public void EditUser_WithValidData_ShouldEditUser()
        {
            // Arrange
            var userViewModel = new UserViewModel();
            userViewModel.AddUser("John", "Doe", 25, 100);
            var userToEdit = userViewModel.Users[0];
            var newAge = 30;
            var newPoints = 200;

            // Act
            userViewModel.EditUser(userToEdit.Id, userToEdit.FirstName, userToEdit.LastName, newAge, newPoints);

            // Assert
            var editedUser = userViewModel.Users[0];
            Assert.AreEqual(newAge, editedUser.Age);
            Assert.AreEqual(newPoints, editedUser.Points);
        }

        [TestMethod]
        public void RemoveUser_WithValidData_ShouldRemoveUser()
        {
            // Arrange
            var userViewModel = new UserViewModel();
            userViewModel.AddUser("John", "Doe", 25, 100);
            var userToRemove = userViewModel.Users[0];
            var initialCount = userViewModel.Users.Count;

            // Act
            userViewModel.RemoveUser(userToRemove.Id);

            // Assert
            Assert.AreEqual(initialCount - 1, userViewModel.Users.Count);
        }

        [TestMethod]
        public void SortByPoints_ShouldSortUsersByPoints()
        {
            // Arrange
            var userViewModel = new UserViewModel();
            userViewModel.AddUser("John", "Doe", 25, 100);
            userViewModel.AddUser("Jane", "Smith", 30, 200);
            userViewModel.AddUser("Alice", "Johnson", 35, 150);

            // Act
            userViewModel.SortByPoints();

            // Assert
            var sortedUsers = new ObservableCollection<Core>(userViewModel.Users);
            for (int i = 1; i < sortedUsers.Count; i++)
            {
                Assert.IsTrue(sortedUsers[i - 1].Points >= sortedUsers[i].Points);
            }
        }
    }
}
