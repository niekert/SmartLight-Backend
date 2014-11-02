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
            using (SmartLight.Entities.SmartLightEntities entities = new SmartLight.Entities.SmartLightEntities())
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

            using (Entities.SmartLightEntities entities = new Entities.SmartLightEntities())
            {
                foreach (var lampIdState in lampsToUpdate)
                {
                    var lamp = entities.Lamps.Find(lampIdState.LampID);

                    if (lamp != null)
                    {
                        if (lampIdState.LampState == Entities.Enumerations.LampState.On)
                        {
                            ArduinoControl.SwitchLamp(lamp.TurnOnCode);
                        }
                        else
                        {
                            ArduinoControl.SwitchLamp(lamp.TurnOffCode);
                        }
                        returnedLamps.Add(lampIdState);
                        lamp.CurrentState = lampIdState.LampState;
                    }
                    else
                    {
                        DTO.LampIDState newState = new DTO.LampIDState() { LampID = lampIdState.LampID, LampState = Utils.ReverseState(lampIdState.LampState) };
                        lamp.CurrentState = Utils.ReverseState(lampIdState.LampState);
                        returnedLamps.Add(newState);
                    }

                    entities.SaveChanges();
                }

            }

            return returnedLamps;
        }

        public DTO.LampDTO UpdateLamp(DTO.LampDTO lampToUpdate)
        {
            if(lampToUpdate == null)
            {
                throw new ArgumentNullException("LampToUpdate can't be null.");
            }

            using(Entities.SmartLightEntities entities = new Entities.SmartLightEntities())
            {
                Entities.Lamp dbLamp = entities.Lamps.Find(lampToUpdate.Id);

                if(dbLamp == null)
                {
                    throw new ArgumentException("Lamp you are trying to update does not exist in the database.");
                }

                dbLamp.LampName = lampToUpdate.Name;
                dbLamp.TurnOnWhenInRange = lampToUpdate.TurnOnInRange;
                
                if(lampToUpdate.HasTimeLock)
                {
                    Entities.Timelock timeLock = dbLamp.Timelock;
                    if(timeLock == null)
                    {
                        timeLock = new Entities.Timelock() { TimelockId = Guid.NewGuid() };
                        entities.Timelocks.Add(timeLock);
                        dbLamp.Timelock = timeLock;
                    }

                    timeLock.StartTime = TimeSpan.FromSeconds(lampToUpdate.TurnOnSeconds);
                    timeLock.EndTime = TimeSpan.FromSeconds(lampToUpdate.TurnOffSeconds);
                }
                else
                {
                   if(dbLamp.Timelock != null)
                   {
                       dbLamp.Timelock = null;
                   }
                }

                entities.SaveChanges();

                return lampToUpdate;
            }
        }
    }
}
