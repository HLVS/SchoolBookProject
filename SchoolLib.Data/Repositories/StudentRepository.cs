using System;
using System.Linq.Expressions;
using SchoolLib.Core;
using System.Data.Entity;

namespace SchoolLib.Data
{
    public class StudentRepository : DataRepositoryBase<Student, SchoolLibDbContext>, IStudentRepository
    {
        protected override DbSet<Student> DbSet(SchoolLibDbContext entityContext)
        {
            return entityContext.Students;
        }

        protected override Expression<Func<Student, bool>> IdentifierPredicate(SchoolLibDbContext entityContext, int id)
        {
            return (e => e.Id == id);
        }
    }
}
