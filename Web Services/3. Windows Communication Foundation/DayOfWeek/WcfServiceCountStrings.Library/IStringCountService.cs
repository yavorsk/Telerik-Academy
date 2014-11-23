using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceCountStrings.Library
{
    [ServiceContract]
    public interface IStringCountService
    {
        [OperationContract]
        int CountSubstringsInString(string text, string substring);
    }
}
