using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIREST.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Document { get; set; }
        public string Name { get; set; }
        public string PhoneNumber{ get; set; }
        public string Mail { get; set; }
        public string City { get; set; }

        public DateTime DateRegister { get; set; }
    }
}