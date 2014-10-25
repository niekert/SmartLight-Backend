using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SmartLight.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ILampService
    {
        /// <summary>
        /// Get all the existing lamps on the server.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebGet(UriTemplate = "/Lamps")]
        List<DTO.LampDTO> GetLamps();

        [OperationContract]
        List<DTO.LampIDState> ToggleLampStates(List<DTO.LampIDState> lampsToUpdate);
    }
}
