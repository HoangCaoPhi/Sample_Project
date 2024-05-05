using Microsoft.EntityFrameworkCore;
using Sample.Domain.Entities;
using Sample.Domain.Interfaces;

namespace Sample.Persistence.Repositories
{
    public class CourseRepo : GenericRepository<Course>, ICourseRepo
    {
        private ApplicationDbContext _dbContext;
        public CourseRepo(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Course>> GetAll()
        {
            var data = await _dbContext.Courses
                .Include(c => c.Department)
            .AsSplitQuery()
                .AsNoTracking()
                .ToListAsync();

            return data;
        }

        public static void SaveAnnotatedGraph(DbContext context, object rootEntity)
        {
            context.ChangeTracker.TrackGraph(
                rootEntity,
                n =>
                {
                    var entity = (EntityBase)n.Entry.Entity;
                    n.Entry.State = entity.IsNew
                        ? EntityState.Added
                        : entity.IsChanged
                            ? EntityState.Modified
                            : entity.IsDeleted
                                ? EntityState.Deleted
                                : EntityState.Unchanged;
                });

            context.SaveChanges();
        }
    }
}
