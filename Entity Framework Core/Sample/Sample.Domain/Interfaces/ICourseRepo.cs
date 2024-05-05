using Sample.Domain.Entities;

namespace Sample.Domain.Interfaces
{
    public interface ICourseRepo : IGenericRepository<Course>
    {
        Task<List<Course>> GetAll();
    }
}
