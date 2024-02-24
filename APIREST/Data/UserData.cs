using APIREST.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace APIREST.Data
{
    public class UserData
    {
        public static bool RegisterUser(User oUser)
        {
            using (SqlConnection oConexion = new SqlConnection(Connection.connectionString))
            {
                SqlCommand cmd = new SqlCommand("InsertUser", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", oUser.Id);
                cmd.Parameters.AddWithValue("@documentoidentidad", oUser.Document);
                cmd.Parameters.AddWithValue("@nombres", oUser.Name);
                cmd.Parameters.AddWithValue("@telefono", oUser.PhoneNumber);
                cmd.Parameters.AddWithValue("@correo", oUser.Mail);
                cmd.Parameters.AddWithValue("@ciudad", oUser.City);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}