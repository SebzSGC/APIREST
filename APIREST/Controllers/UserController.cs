using APIREST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIREST.Controllers
{
    public object UsuarioData { get; private set; }
    public class UserController : ApiController
    {
        private UsuarioData usuarioData;

        public UserController()
        {
            usuarioData = new UsuarioData();
        }

        // GET api/<controller>
        public List<User> Get()
        {
            return usuarioData.Listar();
        }

        // GET api/<controller>/5
        public User Get(int id)
        {
            return usuarioData.Obtener(id);
        }

        // POST api/<controller>
        public bool Post([FromBody] User oUser)
        {
            return usuarioData.Registrar(oUser);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody] User oUser)
        {
            return usuarioData.Modificar(oUser);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return usuarioData.Eliminar(id);
        }
    }
}