/*
 * Sample Project Created for Freshers or Junior Developers.
 * Developed by Vasu Ravuri, Please look at below link for more details
 * http://dotnettrainer.wordpress.com/ or http://onlinetrainingdotnet.com
 */

using System;
using System.Data;
using System.Data.SqlClient;
using Tourism.BusinessInfo;
namespace Tourism.DataAccess
{
    /// <summary>
    /// Summary description for Location
    /// </summary>
    public class Location : DataAccess
    {
        /// <summary>
        /// To insert location details.
        /// </summary>
        /// <param name="locationInfo"></param>
        public void InsertLocation(LocationInfo locationInfo)
        {

            try
            {
                /*Opening database connection*/
                OpenConn(true);
                /*Fill stored procedure parameters*/
                FillParameters(locationInfo, "Insert");
                ExecuteNonQuery(DbCommands.sp_InsetUpdateLocation);
                /*this is output parameters and retrying the value after performing the insert.*/
                locationInfo.LocationId = Convert.ToInt32(Parameters["@LocationId"].Value);
            }
            finally
            {
                /*Close Connection, this code will always executes..*/
                OpenConn(false);
            }
        }
        public void UpdateLocation(LocationInfo locationInfo)
        {

            try
            {
                /*Opening database connection*/
                OpenConn(true);
                /*Fill stored procedure parameters*/
                FillParameters(locationInfo, "Update");
                ExecuteNonQuery(DbCommands.sp_InsetUpdateLocation);
            }
            finally
            {
                /*Close Connection, this code will always executes..*/
                OpenConn(false);
            }

        }
        public LocationInfo GetLocationById(int locationId)
        {
            LocationInfo locationInfo = new LocationInfo();
            try
            {
                /*Opening database connection*/
                OpenConn(true);
                Parameters.AddWithValue("@LocationId", locationId);
                SqlDataReader dr = ExecReader(DbCommands.sp_GetLocationById);
                if (dr.Read())
                {
                    /*Assigning values to locationInfo object*/
                    locationInfo.LocationId = Convert.ToInt32(dr["LocationId"]);
                    locationInfo.LocationName = dr["LocationName"].ToString();
                    locationInfo.Description = dr["Description"].ToString();
                    locationInfo.LocationUrl = dr["LocationUrl"].ToString();
                }
            }
            finally
            {
                /*Close Connection, this code will always executes..*/
                OpenConn(false);
            }

            /*Returning filled object.*/
            return locationInfo;

        }

        public void Deletelocation(int locationId)
        {
            try
            {
                /*Opening database connection*/
                OpenConn(true);
                Parameters.AddWithValue("@LocationId", locationId);
                ExecuteNonQuery(DbCommands.sp_DeleteLocationById);

            }
            finally
            {
                /*Close Connection, this code will always executes..*/
                OpenConn(false);
            }
        }

        private void FillParameters(LocationInfo locationInfo, string action)
        {
            Parameters.AddWithValue("@LocationName", locationInfo.LocationName);
            Parameters.AddWithValue("@Description", locationInfo.Description);
            Parameters.AddWithValue("@LocationUrl", locationInfo.LocationUrl);
            Parameters.AddWithValue("@Action", action);

            /*Declaring output parameters which helps to retrieve the ids after performing any database operations*/
            SqlParameter locationId = new SqlParameter();
            locationId.ParameterName = "@LocationId";
            locationId.Value = locationInfo.LocationId;
            locationId.Direction = ParameterDirection.InputOutput;
            locationId.DbType = DbType.Int32;
            Parameters.Add(locationId);
        }
    }
}
