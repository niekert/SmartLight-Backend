using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace SmartLight.Services.DTO
{
    [DataContract]
    public class LampIDState
    {
        [DataMember]
        public Guid LampID { get; set; }
        [DataMember]
        public Entities.Enumerations.LampState LampState { get; set; }
    }
}