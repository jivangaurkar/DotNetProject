/*
 * Sample Project Created for Freshers or Junior Developers.
 * Developed by Vasu Ravuri, Please look at below link for more details
 * http://dotnettrainer.wordpress.com/ or http://onlinetrainingdotnet.com
 */

namespace Tourism.DataAccess
{
/// <summary>
/// This class contains all stored procedure names used in this project.
/// </summary>
    public static class DbCommands
    {
        public const string sp_InsetMember = "usp_InsertUpdateMember";
        public const string sp_InsetUpdateAddress = "usp_InsertUpdateAddress";
        public const string sp_GetMemberById = "usp_GetMemberById";
        public const string sp_InsetUpdateLocation = "usp_InsertUpdateLocation";
        public const string sp_GetLocationById = "usp_GetLocationById";
        public const string sp_DeleteLocationById = "usp_DeleteLocationById";
        public const string sp_DeleteMemberById = "usp_DeleteMemberById";
    }

}
