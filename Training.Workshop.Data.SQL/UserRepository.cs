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
        public bool SaveNewUser(string username,string password,string[] rolearray)
        {
            //Added user if username doesn't exist in database
            if (CountUsersWithUsername(username) == 0)
            {
                var User = new User();
                //Adding into User table
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

                        command.Parameters.Clear();

                //Adding into UserRole table
                        foreach (var role in rolearray)
                        {
                            //TODO
                            //adding new userrole rows
                            command.CommandText = "InputintoUserRole";
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("Username", username);
                            command.Parameters.AddWithValue("Rolename", role);
                            command.ExecuteNonQuery();
                            command.Parameters.Clear();
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
        public void DeleteUser(string username)
        {
            //Delete all user roles and user permissions.
            using (var unitofwork = (ISQLUnitOfWork)Training.Workshop.UnitOfWork.UnitOfWork.Start())
            {
                using (var command = unitofwork.Connection.CreateCommand())
                {
                    command.CommandText = "DeletefromUserRole";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("Username", username);
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();

                    //Deleting user from database
                    command.CommandText = "DeleteUser";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("Username", username);
                    command.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// Search and return user if he exist in database,with all his roles and permissions.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public User GetUser(string username, string password)
        {
            var user = new User(); 
            string saltfromdatabase;
            string enteredPasswordwithSaltHash;
            //take salt from database by username and generate SHA hash from entered password and salt
            using (var unitofwork = (ISQLUnitOfWork)Training.Workshop.UnitOfWork.UnitOfWork.Start())
            {
                
                using (var command = unitofwork.Connection.CreateCommand())
                {
                    var salt = new SqlParameter("salt", SqlDbType.VarChar);
                    
                    //add Value to search by username
                    command.CommandText = "TakeSaltbyUserName";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("username",username);
                    //add values to output data from database

                    salt.Direction = ParameterDirection.Output;
                    salt.Size = 15;

                    command.Parameters.Add(salt);

                    command.ExecuteNonQuery();

                    saltfromdatabase = command.Parameters["salt"].Value.ToString();
                    enteredPasswordwithSaltHash = GenerateSHAHashFromPasswordWithSalt(password, saltfromdatabase);
                    //clear parameters for new procedure
                    command.Parameters.Clear();
            
                    command.CommandText = "CheckPasswordAndReturnUsername";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("username", username);
                    command.Parameters.AddWithValue("enteredpassword", enteredPasswordwithSaltHash);

                    var correctusername = new SqlParameter("correctusername", SqlDbType.VarChar);
                    correctusername.Direction = ParameterDirection.Output;
                    correctusername.Size = 50;
                    command.Parameters.Add(correctusername);
                    command.ExecuteNonQuery();
                    //Construct User
                    user.Username = command.Parameters["correctusername"].Value.ToString();
                    
                }
            }
            //return filled user if username and password is correct
            //return empty user if user does not exist in database
            user.Roles = GetRolesandPermissionsbyUsername(user.Username);
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
        public List<string> GetRoleNamesByUsername(string username)
        {
            var rolenamelist = new List<string>();

            using (var unitofwork = (ISQLUnitOfWork)Training.Workshop.UnitOfWork.UnitOfWork.Start())
            {
                using (var command = unitofwork.Connection.CreateCommand())
                {
                    var Rolename = new SqlParameter("@Rolename", SqlDbType.VarChar);
                    
                    Rolename.Direction = ParameterDirection.Output;
                    Rolename.Size = 50;
                    command.Parameters.Add(Rolename);

                    command.CommandText = "RetrieveRolesbyUsername";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("username", username);

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        rolenamelist.Add(reader["RoleName"].ToString());    
                    }
                }
            }
            return rolenamelist;
        }
        /// <summary>
        /// return all obtained User Roles by username and fill it by permissions,return List of Roles with all permissions.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public List<Role> GetRolesandPermissionsbyUsername(string username)
        {
            List<string> RoleNamesListwhichUserhas = Data.Context.Current.RepositoryFactory.GetUserRepository().GetRoleNamesByUsername(username);

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
        /// return all users from database with permissions and roles
        /// </summary>
        /// <returns></returns>
        public List<User> GetAllUsers()
        {
            
            var listofusernames = new List<string>();
            
            var listofusers = new List<User>();
            //return all usernames
            using (var unitofwork = (ISQLUnitOfWork)Training.Workshop.UnitOfWork.UnitOfWork.Start())
            {
                using (var command = unitofwork.Connection.CreateCommand())
                {
                    command.CommandText = "RetrieveAllUsernames";
                    command.CommandType = CommandType.StoredProcedure;

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        listofusernames.Add(reader["username"].ToString());
                    }
                }
            }
            //take all roles by usernames and construct list of users with userroles
            foreach (var username in listofusernames)
            {
                var user = new User()
                {
                    Username = username,
                    Roles = GetRolesandPermissionsbyUsername(username)
                };
                listofusers.Add(user);
            }

            return listofusers;
        }
        /// <summary>
        /// return userid by username. this method used when bike creating with ownerID field
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public int GetUserIDbyUsername(string username)
        {
            int userid = 0;
            using (var unitofwork = (ISQLUnitOfWork)Training.Workshop.UnitOfWork.UnitOfWork.Start())
            {
                using (var command = unitofwork.Connection.CreateCommand())
                {
                    command.CommandText = "RetrieveUserIdbyUsername";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("username", username);

                    var userID = new SqlParameter("userID",0);
                    userID.Direction = ParameterDirection.Output;
                    command.Parameters.Add(userID);

                    command.ExecuteNonQuery();
                    //If owner with username exist in database return UserId, else return 0
                    if (command.Parameters["userID"].Value.ToString() != "")
                    {
                        userid = Int32.Parse(command.Parameters["userID"].Value.ToString());
                    }
                    
                }
            }
            return userid;
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



        /*
        public List<User> GetAllUsers()
        {
            using (var unitofwork = (ISQLUnitOfWork)Training.Workshop.UnitOfWork.UnitOfWork.Start())
            {
                using (var command = unitofwork.Connection.CreateCommand())
                {

                    using (IDataReader reader = command.ExecuteReader())
                    {

                        // process the first result
                        displayCountryRegions(reader);

                        // use NextResult to move to the second result and verify it is returned
                        if (!reader.NextResult())
                            throw new InvalidOperationException("Expected second result (StateProvinces) but only one was returned");

                        // process the second result
                        displayStateProvinces(reader);

                        reader.Close();
                    }
                }
            }


            //TODO
            //Need realization

            return new List<User>();
        }
        */
        
    }
}
