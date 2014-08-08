using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Training.Workshop.Domain.Entities;

namespace Training.Workshop.Data.SQL.SQLSystemUnitOfWork
{
    class SQLSystemDatabaseUnitOfWork:ISQLUnitOfWork
    {
        /// <summary>
        /// Connection string to SQL database
        /// </summary>
        private static SqlConnection connection = new SqlConnection(
            "Data Source=KOLESNIKOV7;Initial Catalog=Training.Workshop.SQLDatabase;Integrated Security=True");
        /// <summary>
        /// SQL DataReader Class
        /// </summary>
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="unitofworkfactory"></param>
        public SQLSystemDatabaseUnitOfWork(SQLSystemDatabaseUnitofWorkFactory unitofworkfactory)
        {
        }
        /// <summary>
        /// Insert
        /// </summary>
        public void Add(User user)
        {
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(String.Format(
                    "SET IDENTITY_INSERT dbo.Users OFF;insert into dbo.Users (Username,UserPassword) VALUES ('{0}','{1}')",
                    user.Username,user.Password), connection);
                command.BeginExecuteNonQuery();

            }
            catch 
            {
                throw new InvalidOperationException("imposible insert into database");
            }
            finally
            {
                if (connection != null) 
                    connection.Close();
            }

        }

        public void Delete(string username)
        {
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(String.Format("delete from dbo.Users where username='{0}'",username), connection);
                command.BeginExecuteNonQuery();
            }
            catch 
            {
                throw new InvalidOperationException("imposible select from database");
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }
        public void Dispose()
        {
            Training.Workshop.UnitOfWork.UnitOfWork.DisposeUnitOfWork(this);
        }
    }
}
