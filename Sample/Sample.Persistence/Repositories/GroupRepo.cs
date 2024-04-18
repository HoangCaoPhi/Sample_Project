using Sample.Domain.Entities;
using Sample.Domain.Interfaces;

namespace Sample.Persistence.Repositories
{
    public class GroupRepo : GenericRepository<Group>, IGroupRepo
    {
        public GroupRepo(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
