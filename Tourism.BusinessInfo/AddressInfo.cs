/*
 * Sample Project Created for Freshers or Junior Developers.
 * Developed by Vasu Ravuri, Please look at below link for more details
 * http://dotnettrainer.wordpress.com/ or http://onlinetrainingdotnet.com or onlinetrainingdotnet.com
 */

namespace Tourism.BusinessInfo
{
    /// <summary>
    /// Summary description for Address
    /// </summary>
    public class AddressInfo
    {
        #region Class Members

        private int _addressId;
        private string _address1;
        private string _address2;
        private string _city;
        private string _state;
        private string _zip;

        //these properties can also declared as  public int AddressId { get; set; }
       
        public int AddressId
        {
            get { return _addressId; }
            set { _addressId = value; }
        }
        public string Address1
        {
            get { return _address1; }
            set { _address1 = value; }
        }

        public string Address2
        {
            get { return _address2; }
            set { _address2 = value; }
        }
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }
        public string State
        {
            get { return _state; }
            set { _state = value; }
        }
        public string Zip
        {
            get { return _zip; }
            set { _zip = value; }
        }
        #endregion
    }
}
