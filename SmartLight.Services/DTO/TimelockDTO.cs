using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace SmartLight.Services.DTO
{
    [DataContract]
    public class TimelockDTO
    {
        [DataMember]
        public TimeSpan StartTime { get; set; }
        [DataMember]
        public TimeSpan EndTime { get; set; }

        public TimelockDTO(Entities.Timelock timelockEntity)
        {
            this.StartTime = timelockEntity.StartTime;
            this.EndTime = timelockEntity.EndTime;
        }
    }
}