using Demo.Application.Models;
using MediatR;
using Sample.Domain.Interfaces;

namespace Sample.Application.Features.Queries.GetPaging
{
    public class GetGroupPaingQuery : IRequest<ServiceResponse>
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; } = 10;

        public class GetGroupPaingQueryHandler : BaseCqrs<IGroupRepo>, IRequestHandler<GetGroupPaingQuery, ServiceResponse>
        {
            public GetGroupPaingQueryHandler(IGroupRepo repo) : base(repo)
            {
            }

            public async Task<ServiceResponse> Handle(GetGroupPaingQuery request, CancellationToken cancellationToken)
            {
                ArgumentNullException.ThrowIfNull(request);

                var result = await _repo.GetPagedReponseAsync(request.PageIndex, request.PageSize);

                return new ServiceResponse(result);
            }
        }
    }
}
