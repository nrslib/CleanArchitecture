namespace ConsoleApp.User.Create
{
    public class UserCreateViewModel {
        private string userId;
        private string createdData;
        
        public UserCreateViewModel(string userId, string createdDate) {
            UserId = userId;
            CreatedDate = createdDate;
        }

        
        public string UserId { get; }
        public string CreatedDate { get; }
    }
}
