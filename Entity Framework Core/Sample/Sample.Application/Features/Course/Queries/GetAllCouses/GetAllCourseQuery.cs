using MediatR;
using Sample.Domain.Entities;
using Sample.Domain.Interfaces;

namespace Sample.Application.Features.Queries.GetAllCouses
{
    public class GetAllCourseQuery : IRequest<List<Course>>
    {
        public class GetAllCourseQueryHanlder : IRequestHandler<GetAllCourseQuery, List<Course>>
        {
            private ICourseRepo _repo;

            public GetAllCourseQueryHanlder(ICourseRepo repo)
            {
                _repo = repo;
            }

            public async Task<List<Course>> Handle(GetAllCourseQuery request, CancellationToken cancellationToken)
            {
                return await _repo.GetAll();
            }
        }
    }
}
