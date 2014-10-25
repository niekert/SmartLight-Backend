using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SmartLight.Services
{
    public class LampService : ILampService
    {
        public List<DTO.LampDTO> GetLamps()
        {
            var returnList = new List<DTO.LampDTO>();
            using (Entities.SmartLightEntities entities = new Entities.SmartLightEntities())
            {
                var lamps = entities.Lamps.OrderBy(l => l.LampName);
                foreach (var lamp in lamps)
                {
                    returnList.Add(new DTO.LampDTO(lamp));
                }
            }

            return returnList;
        }

        public List<DTO.LampIDState> ToggleLampStates(List<DTO.LampIDState> lampsToUpdate)
        {
            List<DTO.LampIDState> returnedLamps = new List<DTO.LampIDState>();

            foreach (var lamp in lampsToUpdate)
            {
                //TODO: For each in lampsToUpdate, update the state of the lamp and add to returnlist.

                lamp.LampState = Entities.Enumerations.LampState.Off;
                returnedLamps.Add(lamp);
            }

            return returnedLamps;
        }
    }
}
