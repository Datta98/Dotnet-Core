using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Data.SqlClient;
using WebApiDependency.Data;
using WebApiDependency.Models;
using System.Configuration;

namespace WebApiDependency.Repositories
{
    public class UserSqlRepository : IUserRepository
    {
        string connection;
        public UserSqlRepository(string _connection)
        {
            connection = _connection;
        }


        Boolean DbExecuteOperation(string query)
        {
            int rowsafected = 0;
          //  SqlConnection con = new SqlConnection("Data Source=ES-LAPTOP-510\\SQL2017;Initial Catalog=UserDetails;Integrated Security=True");
                 SqlConnection con = new SqlConnection(connection);
            try
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Connection = con;
                        rowsafected = cmd.ExecuteNonQuery();

                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return rowsafected > 0 ? true : false;
        }
        public bool AddUser(UserModel user)
        {
            string query = "insert into AccountsUser values ('" + user.UserName + "','" + user.EmailId + "','" + user.Password + "')";
            Boolean isValid = DbExecuteOperation(query);
            return isValid;
        }

        public bool DeleteUser(string username)
        {
            string query = "delete from AccountsUser  Where  UserName='" + username + "' ";
            Boolean isValid = DbExecuteOperation(query);
            return isValid;
        }

        public IEnumerable<UserModel> GetallUsers()
        {
            List<UserModel> listuser = new List<UserModel>();
           // SqlConnection con = new SqlConnection("Data Source=ES-LAPTOP-510\\SQL2017;Initial Catalog=UserDetails;Integrated Security=True");
            SqlConnection con = new SqlConnection(connection);
            try
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    string query = "Select * from AccountsUser ";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            UserModel _usermodel = new UserModel();
                            _usermodel.UserName = reader["UserName"].ToString();
                            _usermodel.EmailId = reader["EmailId"].ToString();
                            _usermodel.Password = reader["Password"].ToString();

                            listuser.Add(_usermodel);
                        }
                    }
                }

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

            return listuser;
        }

        public bool UpdateUser(UserModel user)
        {
            string query = "update AccountsUser set EmailId='" + user.EmailId + "' , Password='" + user.Password + "'    where UserName='" + user.UserName + "' ";
            Boolean isValid = DbExecuteOperation(query);
            return isValid;
        }
    }
}
