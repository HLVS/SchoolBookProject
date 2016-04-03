using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using SchoolLib.Contracts;

namespace SchoolLib.Proxies
{
    public class StudentClient : ClientBase<IStudentService>, IStudentService
    {
        public StudentClient(string endpointName)
            : base(endpointName)
        {            
        }

        public StudentClient(Binding binding, EndpointAddress address)
            : base(binding, address)
        {            
        }

        public List<StudentDTO> GetStudents()
        {
           return Channel.GetStudents();

        }

        //public ZipCodeData GetZipInfo(string zip)
        //{
        //    return Channel.GetZipInfo(zip);
        //}

        //public IEnumerable<string> GetStates(bool primaryOnly)
        //{
        //    return Channel.GetStates(primaryOnly);
        //}

        //public IEnumerable<ZipCodeData> GetZips(string state)
        //{
        //    return Channel.GetZips(state);
        //}

        //public IEnumerable<ZipCodeData> GetZips(string zip, int range)
        //{
        //    return Channel.GetZips(zip, range);
        //}
    }
}
