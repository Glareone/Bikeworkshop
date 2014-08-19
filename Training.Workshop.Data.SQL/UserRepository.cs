﻿using System;
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
        public bool SaveNewUser(string username,string password,string[] rolearray)
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

                        foreach (var role in rolearray)
                        { 
                            //TODO
                            //adding new userrole rows
                            command.CommandText = "InputintoUserRole";
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("Username", username);
                            command.Parameters.AddWithValue("Rolename", role);
                            command.ExecuteNonQuery();
                        }
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
        public User GetUser(string username, string password)
        {
            var user = new User();

            using (var unitofwork = (ISQLUnitOfWork)Training.Workshop.UnitOfWork.UnitOfWork.Start())
            {
                using (var command = unitofwork.Connection.CreateCommand())
                {
                    var userpassword = new SqlParameter("userpassword", SqlDbType.VarChar);

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

                    command.Parameters.Add(salt);

                    command.ExecuteNonQuery();
                    //if input password are equals with user's password in database
                    if (command.Parameters["userpassword"].Value.ToString() == GenerateSHAHashFromPasswordWithSalt(password, command.Parameters["salt"].Value.ToString()))
                    {

                        user.Username = username;
                        user.Password = command.Parameters["userpassword"].Value.ToString();
                        user.Roles = GetRolesandPermissionsbyUsername(username);
                        //TODO
                        //Rework
                        //may be need return user role and his permissions??
                    }
                }
            }
            return user;
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
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public List<Role> GetRolesandPermissionsbyUsername(string username)
        {
            List<string> RoleNamesListwhichUserhas = Data.Context.Current.RepositoryFactory.GetUserRepository().GetRolesByUsername(username);

            var RoleList = new List<Role>();

            foreach (var role in RoleNamesListwhichUserhas)
            {
                var Role = new Role()
                {
                    Name = role,
                    Permissions = GetPermissionsbyRolename(role)
                };
                RoleList.Add(Role);
            }

            return RoleList;
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
