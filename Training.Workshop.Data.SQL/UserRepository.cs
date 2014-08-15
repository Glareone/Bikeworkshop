using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.Workshop.Domain.Entities;
using Training.Workshop.Data.SQL.SQLSystemUnitOfWork;
using System.Data;
using System.Security.Cryptography;
using System.Data.SqlClient;

namespace Training.Workshop.Data.SQL
{
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// Save User in SQL database
        /// </summary>
        /// <param name="user"></param>
        public bool Save(User user)
        {
            
            if (CountUsersWithUsername(user.Username) == 0)
            {
                using (var unitofwork = (ISQLUnitOfWork)Training.Workshop.UnitOfWork.UnitOfWork.Start())
                {
                    using (var command = unitofwork.Connection.CreateCommand())
                    {
                        //Add new user if database do not have another user with this username
                        var salt = GenerateSalt();

                        command.CommandText = "InsertUser";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("Username", user.Username);
                        command.Parameters.AddWithValue("Password", GenerateSHAHashFromPasswordWithSalt(user.Password, salt));
                        command.Parameters.AddWithValue("Salt", salt);
                        command.Parameters.AddWithValue("Permissions", user.Permissions);
                        command.Parameters.AddWithValue("Role", user.Role);
                        command.ExecuteNonQuery();


                    }

                }
                return true;
            }
            return false;
        }
        /// <summary>
        /// Delete all users with username from SQL Database
        /// </summary>
        /// <param name="username"></param>
        public void Delete(string username)
        {
            using (var unitofwork = (ISQLUnitOfWork)Training.Workshop.UnitOfWork.UnitOfWork.Start())
            {
                using (var command = unitofwork.Connection.CreateCommand())
                {
                    command.CommandText = "DeleteUser";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("Username", username);
                    command.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// Search and return user if he exist in database
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public List<string> Read(string username, string password)
        {
            var list = new List<string>();

            using (var unitofwork = (ISQLUnitOfWork)Training.Workshop.UnitOfWork.UnitOfWork.Start())
            {
                using (var command = unitofwork.Connection.CreateCommand())
                {
                    var userpassword = new SqlParameter("userpassword", SqlDbType.VarChar);

                    var permissions = new SqlParameter("permissions", SqlDbType.VarChar);

                    var role = new SqlParameter("role", SqlDbType.VarChar);

                    var salt = new SqlParameter("salt", SqlDbType.VarChar);
                    
                    
                    
                    //add Value to search by username
                    command.CommandText = "SearchUserbyName";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("username",username);
                    //add values to output data from database
                    
                    userpassword.Direction = ParameterDirection.Output;
                    userpassword.Size = 50;
                    permissions.Direction = ParameterDirection.Output;
                    permissions.Size = 50;
                    role.Direction = ParameterDirection.Output;
                    role.Size = 30;
                    salt.Direction = ParameterDirection.Output;
                    salt.Size = 15;

                    command.Parameters.Add(userpassword);
                    command.Parameters.Add(permissions);
                    command.Parameters.Add(role);
                    command.Parameters.Add(salt);

                    command.ExecuteNonQuery();
                    //if input password are equals with user's password in database
                    if (command.Parameters["userpassword"].Value.ToString() == GenerateSHAHashFromPasswordWithSalt(password, command.Parameters["salt"].Value.ToString()))
                    {

                        list.Add(username);
                        list.Add(command.Parameters["userpassword"].Value.ToString());
                        list.Add(command.Parameters["permissions"].Value.ToString());
                        list.Add(command.Parameters["role"].Value.ToString());
                    }
                }
            }
            return list;
        }

        public List<string> Search(string username)
        {
            var list = new List<string>();

            using (var unitofwork = (ISQLUnitOfWork)Training.Workshop.UnitOfWork.UnitOfWork.Start())
            {
                using (var command = unitofwork.Connection.CreateCommand())
                {
                    
                   

                    var permissions = new SqlParameter("permissions", SqlDbType.VarChar);

                    var role = new SqlParameter("role", SqlDbType.VarChar);

                    command.CommandText = "RetrievePermissionsAndRoleFromUserbyUsername";
                    command.CommandType = CommandType.StoredProcedure;
                    
                    permissions.Direction = ParameterDirection.Output;
                    permissions.Size = 50;
                    role.Direction = ParameterDirection.Output;
                    role.Size = 30;

                    command.Parameters.AddWithValue("username", username);
                    command.Parameters.Add(permissions);
                    command.Parameters.Add(role);

                    command.ExecuteNonQuery();

                    list.Add(command.Parameters["permissions"].Value.ToString());
                    list.Add(command.Parameters["role"].Value.ToString());
                }
            }
            return list;
        }

        /// <summary>
        /// Function returns Count of Users with this username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public int CountUsersWithUsername(string username)
        {
            using (var unitofwork = (ISQLUnitOfWork)Training.Workshop.UnitOfWork.UnitOfWork.Start())
            {
                using (var command = unitofwork.Connection.CreateCommand())
                {
                    command.CommandText = "CountUsersWithUsername";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("username", username);

                    var countParameter = new SqlParameter("@UserWithUsernameCount", 0);
                    
                    countParameter.Direction = ParameterDirection.Output;
                    command.Parameters.Add(countParameter);
                    command.ExecuteNonQuery();
                    
                    int count=Int32.Parse(command.Parameters["@UserWithUsernameCount"].Value.ToString());
                    
                    return count;
                }
            }
        }

        private string GenerateSalt()
        {
            string salt = "";

            //Create salt with random lenght
            var rnd = new Random();

            for(int i=0;i<rnd.Next(8,15);i++)
            {
                //Take random char from eng alphabet and push to string salt
                salt += Convert.ToChar(64+rnd.Next(1, 26));
            }
            return salt;
        }

        private string GenerateSHAHashFromPasswordWithSalt(string password, string salt)
        {

            byte[] hash;
            
            using (var sha1 = new System.Security.Cryptography.SHA1CryptoServiceProvider())
            {
                 hash = sha1.ComputeHash(Encoding.Unicode.GetBytes(password+salt));
            }

            var stringbuilder = new StringBuilder();
            
            foreach (byte b in hash)
            {
                stringbuilder.AppendFormat("{0:x2}", b);
            } 

            return stringbuilder.ToString();
        }
    }
}
