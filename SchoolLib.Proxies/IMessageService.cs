using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace SchoolLib.Client.Contracts
{
    [ServiceContract]
    public interface IMessageService
    {
        [OperationContract]
        void ShowMessage(string message);
    }
}
