using System;

namespace IDTP.Models
{
    public class User
    {
        public string EntityType { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string PostalCode { get; set; }
        public string NID { get; set; }
        public string TIN { get; set; }
        public string BIN { get; set; }
        public string Password { get; set; }
        public string IDTP_PIN { get; set; }
        public string FIName { get; set; }
        public string RoutingNumber { get; set; }
        public string AccountNumber { get; set; }
    }


    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class address
    {

        private string toField;

        private string fromField;

        /// <remarks/>
        public string to
        {
            get
            {
                return this.toField;
            }
            set
            {
                this.toField = value;
            }
        }

        /// <remarks/>
        public string from
        {
            get
            {
                return this.fromField;
            }
            set
            {
                this.fromField = value;
            }
        }
    }


}
