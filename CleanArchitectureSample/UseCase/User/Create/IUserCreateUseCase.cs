namespace UseCase.User.Create
{
    public interface IUserCreateUseCase {
        void Handle(UserCreateInputData inputData);
    }
}
