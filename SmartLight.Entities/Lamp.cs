//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SmartLight.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Lamp
    {
        public System.Guid LampId { get; set; }
        public string LampName { get; set; }
        public Enumerations.LampState CurrentState { get; set; }
        public Nullable<System.Guid> TimelockId { get; set; }
        public bool TurnOnWhenInRange { get; set; }
        public string TurnOnCode { get; set; }
        public string TurnOffCode { get; set; }
    
        public virtual Timelock Timelock { get; set; }
    }
}
