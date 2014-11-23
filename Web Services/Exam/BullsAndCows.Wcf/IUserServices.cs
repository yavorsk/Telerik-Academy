using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using BullsAndCows.Wcf.DataModels;

namespace BullsAndCows.Wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUserServices" in both code and config file together.
    [ServiceContract]
    public interface IUserServices
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "users")]
        IEnumerable<UserDataModels> GetUsers();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "users/{id}")]
        object GetUserDetails(string id);
    }
}
