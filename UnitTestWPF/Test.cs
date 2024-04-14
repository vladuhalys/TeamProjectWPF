using Domain.UseCase;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Presentation.Tests
{
    [TestClass]
    public class UserViewModelTests
    {
        private UserViewModel _userViewModel;

        [TestInitialize]
        public void Setup()
        {
            _userViewModel = new UserViewModel();
        }

        [TestMethod]
        public void AddUser_ValidInput_SuccessfullyAddsUser()
        {
            // Arrange
            int initialUsersCount = _userViewModel.Users.Count;

            // Act
            _userViewModel.AddUser("TestFirstName", "TestLastName", 25, 50);

            // Assert
            Assert.AreEqual(initialUsersCount + 1, _userViewModel.Users.Count);
        }

        [TestMethod]
        public void RemoveUser_ValidInput_SuccessfullyRemovesUser()
        {
            // Arrange
            _userViewModel.AddUser("TestFirstName", "TestLastName", 25, 50);
            int initialUsersCount = _userViewModel.Users.Count;

            // Act
            _userViewModel.RemoveUser(1); 

            // Assert
            Assert.AreEqual(initialUsersCount - 1, _userViewModel.Users.Count);
        }

        [TestMethod]
        public void EditUser_ValidInput_SuccessfullyEditsUser()
        {
            // Arrange
            _userViewModel.AddUser("TestFirstName", "TestLastName", 25, 50);
            var user = _userViewModel.Users[0]; 
            int originalAge = user.Age;
            int originalPoints = user.Points;
            int newAge = 30;
            int newPoints = 60;

            // Act
            _userViewModel.EditUser(user.Id, user.FirstName, user.LastName, newAge, newPoints);

            // Assert
            Assert.AreEqual(newAge, user.Age);
            Assert.AreEqual(newPoints, user.Points);
        }
    }
}
