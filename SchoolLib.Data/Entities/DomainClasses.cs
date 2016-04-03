using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SchoolLib.Core;

namespace SchoolLib.Data
{
    /// <summary>
    /// Usuarios
    /// </summary>
    public class User
    {
        public User()
        {
            CreatedOn = DateTime.Now;
            LastUpdate = DateTime.Now;
            LastLogin = DateTime.Now;
            Enabled = true;
        }

        [Key]
        public int Id { get; set; }
        [Required, MaxLength(250)]
        public string Name { get; set; }
        [Required, MaxLength(250)]
        public string Surname { get; set; }
        [Required, MaxLength(50)]
        public string UserName { get; set; }
        public List<Rol> Rol { get; set; }
        [Required]
        public DateTime LastLogin { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public DateTime LastUpdate { get; set; }
        [Required]
        public bool Enabled { get; set; }
    }

    public class Rol
    {
        public Rol()
        {
            Enabled = true;
        }
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(250)]
        public string Name { get; set; }
        [Required]
        public bool Enabled { get; set; }
    }

    /// <summary>
    /// Conceptos
    /// </summary>
    public class Concept : IIdentifiableEntity
    {
        public Concept()
        {
            CreatedOn = DateTime.Now;
            LastUpdate = DateTime.Now;
            ValidFrom = DateTime.Now;
            Enabled = true;
        }
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(250)]
        public string Name { get; set; }
        [Required]
        public decimal Import { get; set; }
        [Required]
        public bool AnuallyPayment { get; set; }
        [Required]
        public User User { get; set; }
        [Required]
        public DateTime? CreatedOn { get; set; }
        [Required]
        public DateTime? LastUpdate { get; set; }
        [Required]
        public bool Enabled { get; set; }
        [Required]
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public int EntityId
        {
            get { return Id; }
            set { Id = value; }
        }
    }

    /// <summary>
    /// Cursos
    /// </summary>
    public class Course : IIdentifiableEntity
    {
        public Course()
        {
            Enabled = true;
        }
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(250)]
        public string Name { get; set; }
        [Required]
        public bool Enabled { get; set; }
        public int EntityId
        {
            get { return Id; }
            set { Id = value; }
        }
    }

    /// <summary>
    /// Conceptos por curso
    /// </summary>
    public class ConceptsByCourse : IIdentifiableEntity
    {
        public ConceptsByCourse()
        {
            CreatedOn = DateTime.Now;
            LastUpdate = DateTime.Now;
        }
        [Key]
        public int Id { get; set; }
        public Course Course { get; set; }
        public Concept Concept { get; set; }
        [Required]
        public User User { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public DateTime LastUpdate { get; set; }
        public int EntityId
        {
            get { return Id; }
            set { Id = value; }
        }
    }

    /// <summary>
    /// Alumnos
    /// </summary>
    public class Student : IIdentifiableEntity
    {
        public Student()
        {
            //FamilyRelatives = new List<FamilyRelative>();
            CreatedOn = DateTime.Now;
            LastUpdate = DateTime.Now;
            Enabled = true;
        }
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(250)]
        public string Name { get; set; }
        [Required, MaxLength(250)]
        public string Surname { get; set; }
        [Required]
        public string Document { get; set; }
        public Course Course { get; set; }
        public ICollection<FamilyRelative> FamilyRelatives { get; set; }
        [Required]
        public User User { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public DateTime LastUpdate { get; set; }
        [NotMapped]
        public string FullName
        {
            get { return $"{Surname}, {Name}"; }
        }
        [Required]
        public bool Enabled { get; set; }
        public int EntityId
        {
            get { return Id; }
            set { Id = value; }
        }
    }

    /// <summary>
    /// Familia
    /// </summary>
    public class FamilyRelative : IIdentifiableEntity
    {
        public FamilyRelative()
        {
            Enabled = true;
        }
        [Key]
        public int Id { get; set; }
        public Student Student { get; set; }
        public LegalResponsible Responsible { get; set; }
        [Required]
        public bool Enabled { get; set; }
        public int EntityId
        {
            get { return Id; }
            set { Id = value; }
        }
    }

    /// <summary>
    /// Responsable de familia
    /// </summary>
    public class LegalResponsible : IIdentifiableEntity
    {
        public LegalResponsible()
        {
            CreatedOn = DateTime.Now;
            LastUpdate = DateTime.Now;
            Enabled = true;
        }
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(250)]
        public string Name { get; set; }
        [Required, MaxLength(250)]
        public string Surname { get; set; }
        [Required]
        public string Document { get; set; }
        [Required]
        public User User { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public DateTime LastUpdate { get; set; }
        [NotMapped]
        public string FullName
        {
            get { return $"{Surname}, {Name}"; }
        }
        [Required]
        public bool Enabled { get; set; }
        public int EntityId
        {
            get { return Id; }
            set { Id = value; }
        }

    }

    /// <summary>
    /// Becas
    /// </summary>
    public class Scholarship : IIdentifiableEntity
    {
        public Scholarship()
        {
            CreatedOn = DateTime.Now;
            LastUpdate = DateTime.Now;
            Enabled = true;
        }
        [Key]
        public int Id { get; set; }
        public Concept Concept { get; set; }
        [Required]
        public decimal Percentage { get; set; }
        [Required]
        public User User { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public DateTime LastUpdate { get; set; }
        [Required]
        public bool Enabled { get; set; }
        [Required]
        public string Description { get; set; }
        public int EntityId
        {
            get { return Id; }
            set { Id = value; }
        }
    }

    /// <summary>
    /// Becados
    /// </summary>
    public class ScholarshipAssignment : IIdentifiableEntity
    {
        public ScholarshipAssignment()
        {
            CreatedOn = DateTime.Now;
            LastUpdate = DateTime.Now;
            Enabled = true;
        }
        [Key]
        public int Id { get; set; }
        public Student Student { get; set; }
        public Scholarship Scholarship { get; set; }
        [Required]
        public User User { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public DateTime LastUpdate { get; set; }
        [Required]
        public bool Enabled { get; set; }
        [Required]
        public string Description { get; set; }
        public int EntityId
        {
            get { return Id; }
            set { Id = value; }
        }

    }

    /// <summary>
    /// Becados por familia
    /// </summary>
    public class RelativesScholarship : IIdentifiableEntity
    {
        public RelativesScholarship()
        {
            CreatedOn = DateTime.Now;
            LastUpdate = DateTime.Now;
        }
        [Key]
        public int Id { get; set; }
        public FamilyRelative FamilyRelative { get; set; }
        [Required]
        public User User { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public DateTime LastUpdate { get; set; }
        public int EntityId
        {
            get { return Id; }
            set { Id = value; }
        }

    }

    /// <summary>
    /// Recibos
    /// </summary>
    public class PaymentReceipt : IIdentifiableEntity
    {
        public PaymentReceipt()
        {
            CreatedOn = DateTime.Now;
            LastUpdate = DateTime.Now;
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public decimal Import { get; set; }
        [Required]
        public Int32 Number { get; set; }
        [Required]
        public User User { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public DateTime LastUpdate { get; set; }
        public Payment Payment { get; set; }
        public PartialPayment PartialPayment { get; set; }
        public int EntityId
        {
            get { return Id; }
            set { Id = value; }
        }

    }

    /// <summary>
    /// Pagos
    /// </summary>
    public class Payment : IIdentifiableEntity
    {
        public Payment()
        {
            CreatedOn = DateTime.Now;
            LastUpdate = DateTime.Now;
        }
        [Key]
        public int Id { get; set; }
        public Student Student { get; set; }
        public int CurrentYear { get; set; }
        public decimal January { get; set; }
        public decimal February { get; set; }
        public decimal March { get; set; }
        public decimal April { get; set; }
        public decimal May { get; set; }
        public decimal June { get; set; }
        public decimal July { get; set; }
        public decimal August { get; set; }
        public decimal September { get; set; }
        public decimal October { get; set; }
        public decimal Nomvember { get; set; }
        public decimal December { get; set; }
        [Required]
        public User User { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public DateTime LastUpdate { get; set; }
        public int EntityId
        {
            get { return Id; }
            set { Id = value; }
        }
    }

    /// <summary>
    /// Pagos parciales
    /// </summary>
    public class PartialPayment : IIdentifiableEntity
    {
        public PartialPayment()
        {
            CreatedOn = DateTime.Now;
            LastUpdate = DateTime.Now;
        }
        [Key]
        public int Id { get; set; }
        public Student Student { get; set; }
        public int CurrentYear { get; set; }
        public decimal January { get; set; }
        public decimal February { get; set; }
        public decimal March { get; set; }
        public decimal April { get; set; }
        public decimal May { get; set; }
        public decimal June { get; set; }
        public decimal July { get; set; }
        public decimal August { get; set; }
        public decimal September { get; set; }
        public decimal October { get; set; }
        public decimal Nomvember { get; set; }
        public decimal December { get; set; }
        [Required]
        public User User { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public DateTime LastUpdate { get; set; }
        public int EntityId
        {
            get { return Id; }
            set { Id = value; }
        }
    }

    /// <summary>
    /// Libro de aranceles
    /// </summary>
    public class TariffsBook : IIdentifiableEntity
    {
        public TariffsBook()
        {
            CreatedOn = DateTime.Now;
            LastUpdate = DateTime.Now;
        }
        [Key]
        public int Id { get; set; }
        public Student Student { get; set; }
        public int CurrentYear { get; set; }
        public string January { get; set; }
        public string February { get; set; }
        public string March { get; set; }
        public string April { get; set; }
        public string May { get; set; }
        public string June { get; set; }
        public string July { get; set; }
        public string August { get; set; }
        public string September { get; set; }
        public string October { get; set; }
        public string Nomvember { get; set; }
        public string December { get; set; }
        [Required]
        public User User { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public DateTime LastUpdate { get; set; }
        public int EntityId
        {
            get { return Id; }
            set { Id = value; }
        }

    }

}
