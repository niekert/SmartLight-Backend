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
        public int TurnOnSeconds {get; set;} //Seconds to turn on after midnight
        [DataMember]
        public int TurnOffSeconds { get; set; } //Seconds to go back off after midnight.
        [DataMember]
        public bool HasTimeLock { get; set; }
        [DataMember]
        public bool TurnOnInRange { get; set; }

        public LampDTO(SmartLight.Entities.Lamp lampEntity)
        {
            this.LampState = lampEntity.CurrentState;
            this.Name = lampEntity.LampName;
            this.Id = lampEntity.LampId;
            this.HasTimeLock = (lampEntity.Timelock != null);
            this.TurnOnInRange = lampEntity.TurnOnWhenInRange;
            
            if(this.HasTimeLock)
            {
                this.TurnOnSeconds = (lampEntity.Timelock.StartTime.Hours * 3600) + (lampEntity.Timelock.StartTime.Minutes * 60);
                this.TurnOffSeconds = (lampEntity.Timelock.EndTime.Hours * 3600) + (lampEntity.Timelock.EndTime.Minutes * 60);
            }
        }
    }
}