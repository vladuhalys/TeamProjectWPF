using Domain.UseCase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Repository
{
    public class UserViewModelsRepository
    {
        private readonly ObservableCollection<UserViewModel> _userViewModels;

        public UserViewModelsRepository()
        {
            _userViewModels = new ObservableCollection<UserViewModel>();
        }

        public void AddUserViewModel(UserViewModel userViewModel)
        {
            _userViewModels.Add(userViewModel);
        }

        public void RemoveUserViewModel(UserViewModel userViewModel)
        {
            _userViewModels.Remove(userViewModel);
        }

        public ObservableCollection<UserViewModel> GetUserViewModels()
        {
            return _userViewModels;
        }
    }
}
