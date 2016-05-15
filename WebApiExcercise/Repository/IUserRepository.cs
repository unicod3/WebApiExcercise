using System.Collections.Generic;
using WebApiExcercise.Models;

namespace WebApiExcercise.Repository
{
    public interface IUserRepository
    {
        IEnumerable<User> AllUsers();

        User GetById(int Id);

        void Add(User user);

        void Update(User user);

        bool Remove(int Id);
    }
}