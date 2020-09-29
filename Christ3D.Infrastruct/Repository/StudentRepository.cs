using Christ3D.Domain.Interfaces;
using Christ3D.Domain.Models;
using Christ3D.Infrastruct.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Christ3D.Infrastruct.Repository
{
    /// <summary>
    /// Student仓储，领域对象
    /// </summary>
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(StudyContext context)
            : base(context)
        {
        }
        //对特例接口进行实现
        public Student GetByEmail(string email)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Email == email);
        }
    }
}

