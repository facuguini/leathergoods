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
    public partial class Role
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
        [DisplayName("Name")]
        public string Name { get; set; }
    }
}
