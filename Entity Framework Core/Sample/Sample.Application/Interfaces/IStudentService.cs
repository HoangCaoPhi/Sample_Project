using Sample.Domain.Entities;

namespace Sample.Application.Interfaces
{
    public interface IStudentService
    {
        Task<int> Save(Student student);

        Task<Student> GetById(int id);
    }
}
