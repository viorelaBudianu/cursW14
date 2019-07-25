using System.Collections.Generic;

namespace BusinessLogic
{
    public interface IUserRepository
    {
       List<User> GetAll();
        void AddUser(User user);
        void DeleteUser(User user);
    }
}
