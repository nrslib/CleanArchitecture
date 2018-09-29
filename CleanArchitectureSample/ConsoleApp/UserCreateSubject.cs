using System;
using ConsoleApp.User.Create;

namespace ConsoleApp
{
    public class UserCreateSubject {
        private UserCreateViewModel viewModel;

        public event Action<UserCreateViewModel> UserCreateViewModelUpdated;

        public UserCreateViewModel UserCreateViewModel {
            get => viewModel;
            set {
                viewModel = value;
                UserCreateViewModelUpdated(viewModel);
            }
        }
    }
}
