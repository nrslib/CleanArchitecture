using System;

namespace UseCase.User.Create
{
    public class UserCreateOutputData {
        public UserCreateOutputData(string userId, DateTime created) {
            UserId = userId;
            Created = created;
        }

        public string UserId { get; }
        public DateTime Created { get; }
    }
}
