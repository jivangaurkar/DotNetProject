/*
 * Sample Project Created for Freshers or Junior Developers.
 * Developed by Vasu Ravuri, Please look at below link for more details
 * http://dotnettrainer.wordpress.com/ or http://onlinetrainingdotnet.com
 */
using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Configuration;

namespace Tourism.DataAccess
{
    /// <summary>
    /// This class has all supported database operations and can be reused in all dataaccess classes.
    /// </summary>
    public class DataAccess
    {

        SqlConnection cn = null;
        private SqlParameterCollection _parameters;
        SqlTransaction _sqlTran = null;
        public SqlParameterCollection Parameters
        {
            get { return _parameters; }
        }

        //public ParameterCollection Parameters = null;

        private SqlCommand cmd = null;
        public DataAccess()
        {
            _parameters = GetInitCollection();

            string con = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
            cn = new SqlConnection(con);

        }

        public void BeginTran()
        {
            _sqlTran = cn.BeginTransaction();
        }
        public void CommitTran()
        {
            if (_sqlTran != null)
                _sqlTran.Commit();
        }
        public void RollBackTran()
        {
            if (_sqlTran != null)
                _sqlTran.Rollback();
        }


        public void OpenConn(bool openConn)
        {
            if (openConn == true && cn.State.ToString() != "open")
            {
                cn.Open();
            }
            else if (openConn == false && cn.State.ToString() == "open")
            {
                cn.Close();
                cn.Dispose();
            }
        }
        public void ExecuteNonQuery(string procName)
        {
            cmd = new SqlCommand();
            cmd.CommandText = procName;
            foreach (SqlParameter param in _parameters)
                cmd.Parameters.Add(((ICloneable)param).Clone());
            cmd.Connection = cn;
            if (_sqlTran != null)
                cmd.Transaction = _sqlTran;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            _parameters = cmd.Parameters;
        }
        public SqlDataReader ExecReader(string procName)
        {

            cmd = new SqlCommand();
            cmd.CommandText = procName;
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            foreach (SqlParameter param in _parameters)
                cmd.Parameters.Add(((ICloneable)param).Clone());

            SqlDataReader dr = cmd.ExecuteReader();
            _parameters = cmd.Parameters;
            return dr;



        }

        /*SqlParameterCollection doesn't have public constructor hence using reflection to create a instance.
         We can also use generic list (List<SqlParameter>) to hold these parameters*/
        private SqlParameterCollection GetInitCollection()
        {
            return (SqlParameterCollection)typeof(SqlParameterCollection).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, Type.EmptyTypes, null).Invoke(null);
        }
    }
}