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
            using(Entities.SmartLightEntities entities = new Entities.SmartLightEntities())
            {
                var lamps = entities.Lamps;
                foreach (var lamp in lamps)
                {
                    returnList.Add(new DTO.LampDTO(lamp));
                }
            }

            return returnList;
        }

        public bool TurnOnLampsInRange()
        {
            throw new NotImplementedException();
        }
    }
}
