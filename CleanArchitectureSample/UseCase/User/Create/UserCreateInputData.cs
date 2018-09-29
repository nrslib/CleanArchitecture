namespace UseCase.User.Create
{
    public class UserCreateInputData {
        public UserCreateInputData(string userName) {
            UserName = userName;
        }

        public string UserName { get; }
    }
}
