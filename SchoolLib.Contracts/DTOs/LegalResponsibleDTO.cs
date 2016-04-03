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
    public class LegalResponsibleDTO
    {
        public LegalResponsibleDTO(LegalResponsible responsible)
        {
            this.Id = responsible.Id;
            this.Name = responsible.Name;
            this.Surname = responsible.Surname;
            this.Document = responsible.Document;
            this.FullName = responsible.FullName;
            this.Enabled = responsible.Enabled;
        }

        public List<LegalResponsibleDTO> ToStudentDTO(List<LegalResponsible> legalResponsibles)
        {
            var responsibleEnt = new List<LegalResponsibleDTO>();
            foreach (var responsible in legalResponsibles)
            {
                responsibleEnt.Add(new LegalResponsibleDTO(responsible));
            }
            return responsibleEnt;
        }

        public LegalResponsible ToEntity()
        {
            return ToEntity(this);
        }

        public LegalResponsible ToEntity(LegalResponsibleDTO responsible)
        {
            var legalResponsibleEnt = new LegalResponsible();

            legalResponsibleEnt.Id = responsible.Id;
            legalResponsibleEnt.Name = responsible.Name;
            legalResponsibleEnt.Surname = responsible.Surname;
            legalResponsibleEnt.Document = responsible.Document;
            legalResponsibleEnt.Enabled = responsible.Enabled;

            return legalResponsibleEnt;
        }

        public List<LegalResponsible> ToEntities(List<LegalResponsibleDTO> legalResponsibles)
        {
            var responsibleEnt = new List<LegalResponsible>();
            foreach (var responsible in legalResponsibles)
            {
                responsibleEnt.Add(ToEntity(responsible));
            }
            return responsibleEnt;
        }

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Surname { get; set; }
        [DataMember]
        public string Document { get; set; }
        [DataMember]
        public string FullName { get; set; }
        [DataMember]
        public bool Enabled { get; set; }
    }
}
