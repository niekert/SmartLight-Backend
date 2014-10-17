using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace SmartLight.Services.DTO
{
    [DataContract]
    public class LampDTO
    {
        [DataMember]
        public Entities.Enumerations.LampState LampState { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public TimelockDTO TimeLock { get; set; }


        public LampDTO(SmartLight.Entities.Lamp lampEntity)
        {
            this.LampState = lampEntity.CurrentState;
            this.Name = lampEntity.LampName;
            this.Id = lampEntity.LampId;
            this.TimeLock = new TimelockDTO(lampEntity.Timelock);
        }
    }
}