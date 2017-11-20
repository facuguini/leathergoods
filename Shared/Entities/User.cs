using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;


namespace Entities
{
    /// <summary>
    /// Represents a row of entity data.
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class User : EntityBase
    {
        /// <summary>
        ///
        /// </summary>
        [DataMember]
        [DisplayName("Id")]
        [Browsable(false)]
        public int Id { get; set; }

        /// <summary>
        ///
        /// </summary>
        [DataMember]
        [DisplayName("Email")]
        public string Email { get; set; }

        /// <summary>
        ///
        /// </summary>
        [DataMember]
        [DisplayName("EmailConfirmed")]
        public bool EmailConfirmed { get; set; }

        /// <summary>
        ///
        /// </summary>
        [DataMember]
        [DisplayName("PasswordHash")]
        public string PasswordHash { get; set; }

        /// <summary>
        ///
        /// </summary>
        [DataMember]
        [DisplayName("SecurityStamp")]
        public string SecurityStamp { get; set; }

        /// <summary>
        ///
        /// </summary>
        [DataMember]
        [DisplayName("PhoneNumber")]
        public string PhoneNumber { get; set; }

        /// <summary>
        ///
        /// </summary>
        [DataMember]
        [DisplayName("PhoneNumberConfirmed")]
        public bool PhoneNumberConfirmed { get; set; }

        /// <summary>
        ///
        /// </summary>
        [DataMember]
        [DisplayName("TwoFactorEnabled")]
        public bool TwoFactorEnabled { get; set; }

        /// <summary>
        ///
        /// </summary>
        [DataMember]
        [DisplayName("LockoutEndDateUtc")]
        public DateTime LockoutEndDateUtc { get; set; }

        /// <summary>
        ///
        /// </summary>
        [DataMember]
        [DisplayName("LockoutEnabled")]
        public bool LockoutEnabled { get; set; }

        /// <summary>
        ///
        /// </summary>
        [DataMember]
        [DisplayName("AccessFailedCount")]
        public int AccessFailedCount { get; set; }

        /// <summary>
        ///
        /// </summary>
        [DataMember]
        [DisplayName("UserName")]
        public string UserName { get; set; }

        /// <summary>
        ///
        /// </summary>
        [DataMember]
        [DisplayName("Roles")]
        public List<Role> Roles { get; set; }
    }
}
