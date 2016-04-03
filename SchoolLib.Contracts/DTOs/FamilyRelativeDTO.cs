using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using SchoolLib.Data;

namespace SchoolLib.Contracts
{
    [DataContract]
    public class FamilyRelativeDTO
    {
        public FamilyRelativeDTO(FamilyRelative familyRelative)
        {
            this.Id = familyRelative.Id;
            this.Responsible = new LegalResponsibleDTO(familyRelative.Responsible);
            this.Student = new StudentDTO(familyRelative.Student);
            this.Enabled = familyRelative.Enabled;
        }

        public List<FamilyRelativeDTO> ToCourseDTO(List<FamilyRelative> familyRelatives)
        {
            var familyRelativeEnt = new List<FamilyRelativeDTO>();
            foreach (var familyRelative in familyRelatives)
            {
                familyRelativeEnt.Add(new FamilyRelativeDTO(familyRelative));
            }
            return familyRelativeEnt;
        }

        public FamilyRelative ToEntity()
        {
            return ToEntity(this);

        }
        public FamilyRelative ToEntity(FamilyRelativeDTO familyRelative)
        {
            var familyRelativeEnt = new FamilyRelative();

            familyRelativeEnt.Id = familyRelative.Id;
            familyRelativeEnt.Enabled = familyRelative.Enabled;
            familyRelativeEnt.Responsible = familyRelative.Responsible.ToEntity();
            familyRelativeEnt.Student = familyRelative.Student.ToEntity();
            return familyRelativeEnt;
        }

        public List<FamilyRelative> ToEntities(List<FamilyRelativeDTO> familyRelatives)
        {
            var familyRelativeEnt = new List<FamilyRelative>();
            foreach (var familyRelative in familyRelatives)
            {
                familyRelativeEnt.Add(ToEntity(familyRelative));
            }
            return familyRelativeEnt;
        }

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public StudentDTO Student { get; set; }
        [DataMember]
        public LegalResponsibleDTO Responsible { get; set; }
        [DataMember]
        public bool Enabled { get; set; }
    }
}
