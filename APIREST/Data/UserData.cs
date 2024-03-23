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
        public static bool CreateUser(User oUser)
        {
            using (SqlConnection oConexion = new SqlConnection(Connection.connectionString))
            {
                SqlCommand cmd = new SqlCommand("InsertUser", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Documentation", oUser.Document);
                cmd.Parameters.AddWithValue("@Names", oUser.Name);
                cmd.Parameters.AddWithValue("@PhoneNumber", oUser.PhoneNumber);
                cmd.Parameters.AddWithValue("@Mail", oUser.Mail);
                cmd.Parameters.AddWithValue("@City", oUser.City);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    oConexion.Close();
                    return true;
                }
                catch (Exception)
                {
                    oConexion.Close();
                    return false;
                }
            }
        }

        public static List<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            using (SqlConnection oConexion = new SqlConnection(Connection.connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetAllUsers", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    
                    using  (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            User oUser = new User();
                            oUser.Id = Convert.ToInt32(reader["idUser"]);
                            oUser.Document = reader["Documentation"].ToString();
                            oUser.Name = reader["Names"].ToString();
                            oUser.PhoneNumber = reader["PhoneNumber"].ToString();
                            oUser.Mail = reader["Mail"].ToString();
                            oUser.City = reader["City"].ToString();
                            oUser.DateRegister = Convert.ToDateTime(reader["DateRegister"]);
                            users.Add(oUser);
                        }
                        oConexion.Close();
                        return users;
                    }
                }
                catch (Exception)
                {
                    oConexion.Close();
                    return users;
                }
            }
        }

        public static User GetUser(int id)
        {
            User user = new User();

            using (SqlConnection oConexion = new SqlConnection(Connection.connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM TBuser WHERE IdUser = @id", oConexion);
                cmd.Parameters.AddWithValue("@id", id);

                try
                {
                    oConexion.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            User oUser = new User();
                            oUser.Id = Convert.ToInt32(reader["idUser"]);
                            oUser.Document = reader["Documentation"].ToString();
                            oUser.Name = reader["Names"].ToString();
                            oUser.PhoneNumber = reader["PhoneNumber"].ToString();
                            oUser.Mail = reader["Mail"].ToString();
                            oUser.City = reader["City"].ToString();
                            oUser.DateRegister = Convert.ToDateTime(reader["DateRegister"]);
                            user = oUser;
                        }
                        oConexion.Close();
                        return user;
                    }
                }
                catch (Exception)
                {
                    oConexion.Close();
                    return user;
                }
            }
        }

        public static bool UpdateUser(User oUser)
        {
            using (SqlConnection oConexion = new SqlConnection(Connection.connectionString))
            {
                SqlCommand cmd = new SqlCommand("UpdateUser", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idUser", oUser.Id);
                cmd.Parameters.AddWithValue("@Documentation", oUser.Document);
                cmd.Parameters.AddWithValue("@Names", oUser.Name);
                cmd.Parameters.AddWithValue("@PhoneNumber", oUser.PhoneNumber);
                cmd.Parameters.AddWithValue("@Mail", oUser.Mail);
                cmd.Parameters.AddWithValue("@City", oUser.City);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    oConexion.Close();
                    return true;
                }
                catch (Exception)
                {
                    oConexion.Close();
                    return false;
                }
            }
        }

        public static bool DeleteUser(int id)
        {
            using (SqlConnection oConexion = new SqlConnection(Connection.connectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM TBuser WHERE IdUser = @id", oConexion);
                cmd.Parameters.AddWithValue("@id", id);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    oConexion.Close();
                    return true;
                }
                catch (Exception)
                {
                    oConexion.Close();
                    return false;
                }
            }
        }

    }
}