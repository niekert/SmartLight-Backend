using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartLight.Services
{
    public class Utils
    {
        public static Entities.Enumerations.LampState ReverseState(Entities.Enumerations.LampState currentState)
        {
            if(currentState == Entities.Enumerations.LampState.On)
            {
                return Entities.Enumerations.LampState.Off;
            }
            else
            {
                return Entities.Enumerations.LampState.On;
            }
        }
    }
}