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
        }
        /// <summary>
        /// Delete all existing bikes with owner,mark from SQL Database
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="mark"></param>
        public void Delete(string mark, int ownerID)
        { 
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
                    

                    var manufacturer = new SqlParameter("Manufacturer",SqlDbType.NVarChar);

                    var mark = new SqlParameter("Mark",SqlDbType.NVarChar);

                    var bikeYear = new SqlParameter("BikeYear",SqlDbType.Date);

                    var ownerID = new SqlParameter("OwnerID",0);

                    var conditionState = new SqlParameter("ConditionState", SqlDbType.NVarChar);

                    command.Parameters.AddWithValue("username", owner);
                    //Parameters Configuration
                    manufacturer.Direction = ParameterDirection.Output;
                    manufacturer.Size = 30;
                    mark.Direction = ParameterDirection.Output;
                    mark.Size = 50;
                    bikeYear.Direction = ParameterDirection.Output;
                    ownerID.Direction = ParameterDirection.Output;
                    conditionState.Direction = ParameterDirection.Output;
                    conditionState.Size = 50;

                    command.Parameters.Add(manufacturer);
                    command.Parameters.Add(mark);
                    command.Parameters.Add(bikeYear);
                    command.Parameters.Add(ownerID);
                    command.Parameters.Add(conditionState);

                    var reader=command.ExecuteReader();
                    
                    while(reader.Read())
                    {
                        Bike bike=new Bike();
                         
                        bike.Manufacturer=reader["Manufacturer"].ToString();
                        bike.Mark=reader["Mark"].ToString();
                        bike.OwnerID = int.Parse(reader["OwnerID"].ToString());
                        bike.BikeYear=Convert.ToDateTime(reader["BikeYear"].ToString());
                        bike.ConditionState=reader["ConditionState"].ToString();
                         
                        OwnerBikes.Add(bike);
                    }

                    
                }
            }
            return OwnerBikes;
        }
    }
}
