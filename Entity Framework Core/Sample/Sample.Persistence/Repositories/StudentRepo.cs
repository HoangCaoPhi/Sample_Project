using Microsoft.EntityFrameworkCore;
using Sample.Domain.Entities;
using Sample.Domain.Interfaces;

namespace Sample.Persistence.Repositories
{
    public class StudentRepo : IStudentRepo
    {
        private readonly ApplicationDbContext _context;
        public StudentRepo(ApplicationDbContext context) {
            _context = context;
        }
        public async Task<Student> GetById(int id)
        {

            var student = await _context.Students
                .Include(s => s.Enrollments)
                .ThenInclude(e => e.Course)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            return student is null ? throw new Exception("Not found") : student;
        }

        public async Task<int> Update(Student student)
        {
            return 0;
        }

        public Task<int> Save(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
