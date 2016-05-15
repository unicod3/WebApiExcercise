using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiExcercise.Models;

namespace WebApiExcercise.Repository
{
    public class UserRepository : IUserRepository
    {
        private List<User> _testTable;
        public UserRepository() {
            _testTable = TestDataHelper.GetMyUsers();
        }

        public void Add(User user)
        {
            _testTable.Add(user);
        }

        public IEnumerable<User> AllUsers()
        {
            return _testTable;
        }

        public User GetById(int Id)
        {
            var user = (from s in _testTable where s.Id == Id select s).SingleOrDefault();
            return user;
        }

        public bool Remove(int Id)
        {
            var user = GetById(Id);
            if (user != null)
                _testTable.Remove(user);

            return GetById(Id) == null;
        }

        public void Update(User user)
        {
            var oldUser = GetById(user.Id);
            oldUser.Name = user.Name;
            oldUser.Email = user.Email;
        }
    }
}