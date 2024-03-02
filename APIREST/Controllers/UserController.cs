using APIREST.Models;
using APIREST.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIREST.Controllers
{
    public class UserController : ApiController
    {

        // GET api/<controller>
        public List<User> Get()
        {
            return UserData.GetAllUsers();
        }

        // GET api/<controller>/5
        public User Get(int id)
        {
            return UserData.GetUser(id);
        }

        // POST api/<controller>
        public bool Post([FromBody] User oUser)
        {
            return UserData.CreateUser(oUser);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody] User oUser)
        {

            return UserData.UpdateUser(oUser);
        }

        // delete api/<controller>/5
        public bool Delete(int id)
        {
            return UserData.DeleteUser(id);
        }
    }
}