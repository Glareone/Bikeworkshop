using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.Workshop.Domain.Entities;
using Training.Workshop.Data.SQL.SQLSystemUnitOfWork;
using System.Data;
using System.Security.Cryptography;

namespace Training.Workshop.Data.SQL
{
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// Save User in SQL database
        /// </summary>
        /// <param name="user"></param>
        public void Save(User user)
        {
            var salt = GenerateSalt();
            if (CountUsersWithUsername(user.Username) == 0)
            {
                using (var unitofwork = (ISQLUnitOfWork)Training.Workshop.UnitOfWork.UnitOfWork.Start())
                {
                    using (var command = unitofwork.Connection.CreateCommand())
                    {
                        //Add new user if database do not have another user with this username

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
            }
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
            using (var unitofwork = (ISQLUnitOfWork)Training.Workshop.UnitOfWork.UnitOfWork.Start())
            {
                using (var command = unitofwork.Connection.CreateCommand())
                {
                    command.CommandText = "SearchUserbyName";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("username",username);
                    command.ExecuteNonQuery();
                    
                    var salt=command.Parameters["@salt"].Value.ToString();
                 
                    var list = new List<string>();

                    //if input password are equals with user's password in database
                    if (command.Parameters["@userpassword"].Value.ToString() == GenerateSHAHashFromPasswordWithSalt(password,salt))
                    {

                        list.Add(username);
                        list.Add(command.Parameters["@userpassword"].Value.ToString());
                        list.Add(command.Parameters["@permissions"].Value.ToString());
                        list.Add(command.Parameters["@role"].Value.ToString());
                        return list;
                    }
                    return list;
                }
            }
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
                    string UserWithUsernameCount = "";
                    command.Parameters.AddWithValue("@UserWithUsernameCount", UserWithUsernameCount);
                    command.ExecuteNonQuery();
                    
                    return Convert.ToInt32(command.Parameters["@UserWithUsernameCount"].Value.ToString());
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
