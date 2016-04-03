using SchoolLib.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLib.Data
{
    public class SchoolLibDbContext : DbContext
    {
        public SchoolLibDbContext() : base("name = default")
        {
            Database.SetInitializer(new MyInitializer());
        }

        public DbSet<Concept> Concepts { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<FamilyRelative> FamilyRelatives { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<ConceptsByCourse> ConceptsByCourses { get; set; }
        public DbSet<LegalResponsible> LegalResponsibles { get; set; }
        public DbSet<Scholarship> Scholarships { get; set; }
        public DbSet<ScholarshipAssignment> ScholarshipAssignments { get; set; }
        public DbSet<RelativesScholarship> RelativesScholarships { get; set; }
        public DbSet<PaymentReceipt> PaymentReceipts { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PartialPayment> PartialPayments { get; set; }
        public DbSet<TariffsBook> TariffsBooks { get; set; }






        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //TODO: REMOVE IN CASCADE.
            modelBuilder.Entity<Student>().HasOptional(a => a.FamilyRelatives).WithOptionalDependent().WillCascadeOnDelete(true);


            //modelBuilder.Entity<Blog>().HasKey(b => b.Id).Property(b => b.Title).HasMaxLength(20);
            //modelBuilder.Entity<Blog>().Property(b => b.BloggerName).IsRequired();

            //modelBuilder.Entity<User>().Property(e => e.CreationDate).HasColumnType("datetime2");

            //base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Inicializa la base de datos con valores por defecto.
        /// </summary>
        public class MyInitializer : DropCreateDatabaseIfModelChanges<SchoolLibDbContext>
        {
            protected override void Seed(SchoolLibDbContext context)
            {
                var admin = new User { UserName = "Admin", Name = "Admin", Surname = "Admin" };
                context.Users.Add(admin);
                base.Seed(context);

                var responsible = new LegalResponsible { Name = "Nicolas", Surname = "Garcia", Document = "11.111.111", User = admin };
                context.LegalResponsibles.Add(responsible);
                base.Seed(context);

                //var family = new FamilyRelative {Enabled = true , Responsible = responsible };
                //context.FamilyRelatives.Add(family);
                //base.Seed(context);

                new List<Concept>
                {
                    new Concept { Name = "Enseñanza Programatica", Import = (decimal) 10.00, AnuallyPayment = false , User = admin, ValidTo = DateTime.Now.AddMonths(12)},
                    new Concept { Name = "Enseñanza Extra-Programatica", Import = (decimal) 9.00, AnuallyPayment = false , User = admin,ValidTo = DateTime.Now.AddMonths(12)},
                    new Concept { Name = "Seguimiento Escolar", Import = (decimal) 9.00, AnuallyPayment = true , User = admin,ValidTo = DateTime.Now.AddMonths(12)},
                    new Concept { Name = "Mantenimiento Servicio Educativo", Import = (decimal) 9.00, AnuallyPayment = true , User = admin, ValidTo = DateTime.Now.AddMonths(12)},
                     new Concept { Name = "Campo de deportes", Import = (decimal) 9.00, AnuallyPayment = true , User = admin, ValidTo = DateTime.Now.AddMonths(12)},
                      new Concept { Name = "Matricula", Import = (decimal) 9.00, AnuallyPayment = true , User = admin, ValidTo = DateTime.Now.AddMonths(12)}
                }.ForEach(b => context.Concepts.Add(b));
                base.Seed(context);


            }
        }
    }
}
