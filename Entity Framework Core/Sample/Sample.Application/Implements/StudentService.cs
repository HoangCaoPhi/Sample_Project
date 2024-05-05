using Sample.Application.Interfaces;
using Sample.Domain.Entities;
using Sample.Domain.Interfaces;

namespace Sample.Application.Implements
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepo _studentRepo;
        public StudentService(IStudentRepo studentRepo) {
            _studentRepo = studentRepo;
        }
        public async Task<Student> GetById(int id)
        {
            return await _studentRepo.GetById(id);
        }

        public async Task<int> Save(Student student)
        {
            return await _studentRepo.Save(student);
        }
    }
}
