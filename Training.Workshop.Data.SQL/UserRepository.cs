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
        public bool SaveNewUser(string username,string password,string[] role)
        {
            //Added user if username doesn't exist in database
            if (CountUsersWithUsername(username) == 0)
            {
                using (var unitofwork = (ISQLUnitOfWork)Training.Workshop.UnitOfWork.UnitOfWork.Start())
                {
                    using (var command = unitofwork.Connection.CreateCommand())
                    {
                        //Add new user if database do not have another user with this username
                        var salt = GenerateSalt();

                        command.CommandText = "InsertUser";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("Username", username);
                        command.Parameters.AddWithValue("Password", GenerateSHAHashFromPasswordWithSalt(password, salt));
                        command.Parameters.AddWithValue("Salt", salt);
                        command.ExecuteNonQuery();

                        //TODO
                        //need added to UserRole rows!!!
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
        public List<string> GetUser(string username, string password)
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
                        //TODO
                        //Rework
                        //may be need return user role and his permissions??
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
                    //TODO
                    //Need realization
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
        /// <summary>
        /// Get all permissions that role has.
        /// </summary>
        /// <param name="rolename"></param>
        /// <returns></returns>
        public List<string> GetPermissionsbyRolename(string rolename)
        {
            var Permissionlist = new List<string>();

            using (var unitofwork = (ISQLUnitOfWork)Training.Workshop.UnitOfWork.UnitOfWork.Start())
            {
                using (var command = unitofwork.Connection.CreateCommand())
                {
                    //Configure parameters
                    var Permission = new SqlParameter("Permissionname", SqlDbType.VarChar);
                    
                    Permission.Direction = ParameterDirection.Output;
                    Permission.Size = 50;

                    command.CommandText = "RetrievePermissionbyRolename";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("Rolename", rolename);
                    command.Parameters.Add(Permission);
                    
                    var reader=command.ExecuteReader();
                    //take all permissions from database to list
                    while (reader.Read())
                    {
                        Permissionlist.Add(reader["Permissionname"].ToString());
                    }
                }
            }
            return Permissionlist;
        }
        /// <summary>
        /// return all role names which user with username obtained
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        public List<string> GetRolesByUsername(string username)
        {
            var rolenamelist = new List<string>();

            using (var unitofwork = (ISQLUnitOfWork)Training.Workshop.UnitOfWork.UnitOfWork.Start())
            {
                using (var command = unitofwork.Connection.CreateCommand())
                {
                    command.CommandText = "RetrieveRolesbyUsername";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("username", username);

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        rolenamelist.Add(reader["Rolename"].ToString());    
                    }
                }
            }
            return rolenamelist;
        }
        /// <summary>
        /// Generate Salt. Function,that works with user creating.
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Generate new SHA-hash using user password and salt.
        /// Used when user creating or when userpassword checking.
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
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
