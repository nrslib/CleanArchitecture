using System;
using ConsoleApp.User.Create;

namespace ConsoleApp {
    public class ConsoleView : IDisposable {
        private readonly UserCreateSubject subject;

        public ConsoleView(UserCreateSubject subject) {
            subject.UserCreateViewModelUpdated += Update;
        }

        public void Dispose() {
            subject.UserCreateViewModelUpdated -= Update;
        }

        public void Update(UserCreateViewModel viewModel) {
            Console.WriteLine("id:" + viewModel.UserId + " created:" + viewModel.CreatedDate);
        }
    }
}
