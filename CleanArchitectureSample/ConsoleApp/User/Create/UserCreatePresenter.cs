using System;
using UseCase.User.Create;

namespace ConsoleApp.User.Create {
    public class UserCreatePresenter : IUserCreatePresenter {
        private readonly UserCreateSubject subject;

        public UserCreatePresenter(UserCreateSubject subject) {
            this.subject = subject;
        }

        public void Complete(UserCreateOutputData outputData) {
            var userId = outputData.UserId;
            var createdDate = outputData.Created;
            var createdDateText = createdDate.ToString("yyyy/MM/dd");
            var model = new UserCreateViewModel(userId, createdDateText);
            subject.UserCreateViewModel = model;
        }
    }
}
