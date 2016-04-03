using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using SchoolLib.Data;


namespace SchoolLib.Contracts
{
    [ServiceContract]
    public interface IStudentService
    {
        [OperationContract]
        List<StudentDTO> GetStudents();
    }
}
