using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.Workshop.Domain.Entities;
using Training.Workshop.Data.SQL.SQLSystemUnitOfWork;
using System.Data;
using System.Data.SqlClient;

namespace Training.Workshop.Data.SQL
{
    public class BikeRepository : IBikeRepository
    {
        /// <summary>
        /// Save new bike in SQL Database
        /// </summary>
        /// <param name="bike"></param>
        public void Save(Bike bike)
        {
            using (var unitofwork = (ISQLUnitOfWork)Training.Workshop.UnitOfWork.UnitOfWork.Start())
            {
                using (var command = unitofwork.Connection.CreateCommand())
                {
                    command.CommandText = "InsertBike";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("Manufacturer", bike.Manufacturer);
                    command.Parameters.AddWithValue("Mark", bike.Mark);
                    command.Parameters.AddWithValue("BikeYear", bike.BikeYear);
                    command.Parameters.AddWithValue("ownerID", bike.OwnerID);
                    command.Parameters.AddWithValue("ConditionState", bike.ConditionState);
                    command.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// Delete all existing bikes with owner,mark from SQL Database
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="mark"></param>
        public void Delete(string mark, int ownerID)
        {
            using (var unitofwork = (ISQLUnitOfWork)Training.Workshop.UnitOfWork.UnitOfWork.Start())
            {
                using (var command = unitofwork.Connection.CreateCommand())
                {
                    command.CommandText = "DeleteBike";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("ownerID", ownerID);
                    command.Parameters.AddWithValue("mark", mark);
                    command.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// Find First income bike from SQL Database by mark 
        /// </summary>
        /// <param name="mark"></param>
        /// <returns></returns>
        public Bike Find(string mark)
        {
            //TODO
            //Need realisation
            return new Bike();
        }
        /// <summary>
        /// Update existing bike with owner,mark in SQL Database
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="mark"></param>
        public void Update(string owner, string mark)
        {
        }
        /// <summary>
        /// Search all owner bikes by owner name
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public List<Bike> Search(string owner)
        {
            var OwnerBikes=new List<Bike>();

            using (var unitofwork = (ISQLUnitOfWork)Training.Workshop.UnitOfWork.UnitOfWork.Start())
            {
                using (var command = unitofwork.Connection.CreateCommand())
                {
                    command.CommandText = "SearchBikesByOwner";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("Username", owner);


                    var reader=command.ExecuteReader();
                    
                    while(reader.Read())
                    {
                        OwnerBikes.Add
                        (new Bike
                        {
                            Manufacturer=reader["Manufacturer"].ToString(),
                            Mark=reader["Mark"].ToString(),
                            OwnerID = int.Parse(reader["OwnerID"].ToString()),
                            BikeYear=Convert.ToDateTime(reader["BikeYear"].ToString()),
                            ConditionState=reader["ConditionState"].ToString()
                        }
                        );
                    }

                    
                }
            }
            return OwnerBikes;
        }
    }
}
