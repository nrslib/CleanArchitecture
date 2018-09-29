using System;
using Domain.Domain.Users;
using UseCase.User.Create;

namespace Domain.Application.User
{
public class UserCreateInteractor : IUserCreateUseCase {
    private readonly IUserRepository userRepository;
    private readonly IUserCreatePresenter presenter;

    public UserCreateInteractor(IUserRepository userRepository, IUserCreatePresenter presenter) {
        this.userRepository = userRepository;
        this.presenter = presenter;
    }

    public void Handle(UserCreateInputData inputData) {
        var username = inputData.UserName;
        var duplicateUser = userRepository.FindByUserName(username);
        if (duplicateUser != null) {
            throw new Exception("duplicated");
        }

        var user = new Domain.Users.User(username);
        userRepository.Save(user);

        var outputData = new UserCreateOutputData(user.Id, DateTime.Now);
        presenter.Complete(outputData);
    }
}
}
