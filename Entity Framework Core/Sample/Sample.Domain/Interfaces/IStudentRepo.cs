using Sample.Domain.Entities;

namespace Sample.Domain.Interfaces
{
    public interface IStudentRepo
    {
        Task<int> Save(Student student);

        Task<Student> GetById(int id);
    }
}
