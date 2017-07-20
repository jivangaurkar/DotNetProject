/*
 * Sample Project Created for Freshers or Junior Developers.
 * Developed by Vasu Ravuri, Please look at below link for more details
 * http://dotnettrainer.wordpress.com/ or http://onlinetrainingdotnet.com
 */

using System;
using System.Data.SqlClient;
using Tourism.BusinessInfo;
namespace Tourism.DataAccess
{
    /// <summary>
    /// Summary description for Member
    /// </summary>
    public class Member : DataAccess
    /*Deriving Member from DataAccess*/
    {
        #region Class Members
        public Address Address { get; set; }
        #endregion

        public Member()
        {
            /*Creating object for child table.*/
            Address = new Address();
        }

        #region Class Methods


        public void InsertMember(MemberInfo memberInfo)
        {

            try
            {
                /*Opening database connection*/
                OpenConn(true);
                /*Beginning database transaction, which helps to rollback the inserted data if anything went wrong.*/
                BeginTran();
                /*Passing data access object to child object so that child object will use the base object connection and transaction*/
                Address.InsertAddress(memberInfo.AddressInfo, this);

                /*Clearing parameters that are added in child object.*/
                Parameters.Clear();
                FillParmeters(memberInfo, "Insert");
                ExecuteNonQuery(DbCommands.sp_InsetMember);

                /*If all actions in parent and child tables are performed well then commit transaction.*/
                CommitTran();
            }
            catch
            {
                /*If anything went wrong in parent or child tables then rollback transaction.*/
                RollBackTran();
                throw;
            }
            finally
            {
                /*Close Connection, this code will always executes..*/
                OpenConn(false);
            }



        }
        public void UpdateMember(MemberInfo memberInfo)
        {

            try
            {
                /*Opening database connection*/
                OpenConn(true);
                /*Beginning database transaction, which helps to rollback the inserted data if anything went wrong.*/
                BeginTran();
                /*Passing data access to child object so that child object will share the base object connection and transaction*/
                Address.UpdateAddress(memberInfo.AddressInfo, this);

                /*Clearing parameters that are added in child object.*/
                Parameters.Clear();
                FillParmeters(memberInfo, "Update");
                ExecuteNonQuery(DbCommands.sp_InsetMember);

                /*If all actions in parent and child tables are performed well then commit transaction.*/
                CommitTran();

            }
            catch
            {
                /*If anything went wrong in parent or child tables then rollback transaction.*/
                RollBackTran();
                throw;
            }
            finally
            {
                /*Close Connection, this code will always executes..*/
                OpenConn(false);
            }



        }
        public void DeleteMember(int memberId)
        {

            try
            {
                /*Opening database connection*/
                OpenConn(true);
                /*Beginning database transaction, which helps to rollback the deleted data if anything went wrong.
                 This database call has multiple deletes in it.
                 */
                BeginTran();
                Parameters.AddWithValue("@MemberId", memberId);
                ExecuteNonQuery(DbCommands.sp_DeleteMemberById);
                /*If all actions in procedure are performed well then commit the transaction.*/
                CommitTran();

            }
            catch
            {
                /*If anything went wrong in deleting records from any of the parent or child table then rollback the transaction.*/
                RollBackTran();
            }
            finally
            {
                /*Close Connection, this code will always executes..*/
                OpenConn(false);
            }
        }


        public MemberInfo GetMemberById(int memberId)
        {

            try
            {
                /*Opening database connection*/
                OpenConn(true);
                Parameters.AddWithValue("@MemberId", memberId);
                SqlDataReader dr = ExecReader(DbCommands.sp_GetMemberById);
                /*Creating object to fill the data*/
                MemberInfo memberInfo = new MemberInfo();
                if (dr.Read())
                    FillMember(memberInfo, dr);
                /*Return filled object.*/
                return memberInfo;
            }
            finally
            {
                OpenConn(false);
            }

        }
        private MemberInfo FillMember(MemberInfo memberInfo, SqlDataReader dr)
        {
            memberInfo.MemberId = Convert.ToInt32(dr["MemberId"]);
            memberInfo.LastName = dr["LastName"].ToString();
            memberInfo.FirstName = dr["FirstName"].ToString();
            memberInfo.MiddleName = dr["MiddleName"].ToString();
            memberInfo.Email = dr["Email"].ToString();
            memberInfo.PhoneNo = dr["PhoneNo"].ToString();
            memberInfo.MobileNo = dr["MobileNo"].ToString();
            memberInfo.MemberType = dr["MemberType"].ToString();

            /*Assigning values to child (address) object*/
            if (dr.NextResult())/*NextResult() will be used to move to next select statement in the query.*/
            {
                if (dr.Read())
                {
                    memberInfo.AddressInfo.AddressId = Convert.ToInt32(dr["AddressId"]);
                    memberInfo.AddressInfo.Address1 = dr["Address1"].ToString();
                    memberInfo.AddressInfo.Address2 = dr["Address2"].ToString();
                    memberInfo.AddressInfo.City = dr["City"].ToString();
                    memberInfo.AddressInfo.State = dr["State"].ToString();
                    memberInfo.AddressInfo.Zip = dr["zip"].ToString();
                }
            }
            return memberInfo;
        }

        private void FillParmeters(MemberInfo memberInfo, string action)
        {

            Parameters.AddWithValue("@MemberId", memberInfo.MemberId.ToString());
            Parameters.AddWithValue("@AddressId", memberInfo.AddressInfo.AddressId.ToString());
            Parameters.AddWithValue("@Lastname", memberInfo.LastName);
            Parameters.AddWithValue("@FirstName", memberInfo.FirstName);
            Parameters.AddWithValue("@MiddleName", memberInfo.MiddleName);
            Parameters.AddWithValue("@PhoneNo", memberInfo.PhoneNo);
            Parameters.AddWithValue("@MobileNo", memberInfo.MobileNo);
            Parameters.AddWithValue("@Email", memberInfo.Email);
            Parameters.AddWithValue("@MemberType", memberInfo.MemberType);
            Parameters.AddWithValue("@Action", action);
        }

        #endregion



    }
}