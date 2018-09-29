using System.Collections.Generic;

namespace Domain.Domain.Users
{
    public interface IUserRepository {
        void Save(User user);
        User FindByUserName(string userName);
        IEnumerable<User> FindAll();
    }
}
