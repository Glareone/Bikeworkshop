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
            var salt=GenerateSalt();
            var HashFromPasswordandSalt = GenerateHashWithSalt(salt, user.Password);
            using (var unitofwork = (ISQLUnitOfWork)Training.Workshop.UnitOfWork.UnitOfWork.Start())
            {
                using (var command = unitofwork.Connection.CreateCommand())
                {
                    command.CommandText = "InsertUser";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("Username", user.Username);
                    command.Parameters.AddWithValue("Password", HashFromPasswordandSalt);
                    command.Parameters.AddWithValue("Salt", salt);
                    command.ExecuteNonQuery();
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

        private string GenerateSalt()
        {
            string salt = "";

            //Create salt with random lenght
            Random rnd = new Random();
            for(int i=0;i<rnd.Next(1,15);i++)
            {
                //Take random char from eng alphabet and push to string salt
                salt += Convert.ToChar(64+rnd.Next(1, 31));
            }
            return salt;
        }

        private string GenerateHashWithSalt(string salt, string password)
        {
            string hashwithsalt = "";
              
            using (MD5 md5Hash = MD5.Create())
            {
                hashwithsalt = GetMd5Hash(md5Hash, password+salt);
            }
            
            return hashwithsalt;
        }

        private string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        private bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
