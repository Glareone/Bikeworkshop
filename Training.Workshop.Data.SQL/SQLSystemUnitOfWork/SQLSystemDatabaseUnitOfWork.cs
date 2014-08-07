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
        private static SqlConnection connectionstring = new SqlConnection(
            "Data Source=(local);Initial Catalog=Northwind;Integrated Security=SSPI");
        
        /// <summary>
        /// SQL DataReader Class
        /// </summary>
        private SqlDataReader sqldatareader = null;
        
        public SQLSystemDatabaseUnitOfWork(SQLSystemDatabaseUnitofWorkFactory unitofworkfactory)
        {
            try 
            {
             SqlCommand cmd = new SqlCommand("select * from Users", connectionstring);
             sqldatareader= cmd.ExecuteReader();
                 while (sqldatareader.Read())
                {
                 //TODO
                 //need realisation
                }
            }
            catch
            {
                throw new InvalidOperationException();
            }
        }


        public void Dispose()
        {
            Training.Workshop.UnitOfWork.UnitOfWork.DisposeUnitOfWork(this);
        }
    }
}
