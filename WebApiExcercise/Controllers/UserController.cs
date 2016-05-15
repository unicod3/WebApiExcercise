using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiExcercise.Models;
using WebApiExcercise.Repository;

namespace WebApiExcercise.Controllers
{
    public class UserController : ApiController
    {
        private static readonly IUserRepository _userRepository = new UserRepository();


        public IEnumerable<User> Get()
        {
            var users = _userRepository.AllUsers();
            return users;
        }

        [HttpGet]
        public IHttpActionResult Get(string Id)
        {
            var user = _userRepository.GetById(Convert.ToInt32(Id));
            if (user == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No user with ID = {0}", Id)),
                    ReasonPhrase = "User ID Not Found"
                };
                throw new HttpResponseException(resp);
            }
            return Ok(user);
        }

        [HttpPost]
        public void Post(User user)
        {
            _userRepository.Add(user);
        }

        [HttpPut]
        public void Put(User user)
        {
            _userRepository.Update(user);
        }


        public void Delete(string Id)
        {
            if (!_userRepository.Remove(Convert.ToInt32(Id)))
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No user with ID = {0}", Id)),
                    ReasonPhrase = "User ID Not Found"
                };
                throw new HttpResponseException(resp);
            }
        }

    }
}
