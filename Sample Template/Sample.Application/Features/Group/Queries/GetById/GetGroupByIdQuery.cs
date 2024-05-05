using Demo.Application.Models;
using MediatR;
using Sample.Application.Common.Utils;
using Sample.Application.Dtos;
using Sample.Domain.Entities;
using Sample.Domain.Interfaces;

namespace Sample.Application.Features.Queries.GetById
{
    public class GetGroupByIdQuery : IRequest<ServiceResponse>
    {
        public int GroupId { get; set; }

        public class GetGroupByIdQueryHandler : BaseCqrs<IGroupRepo>, IRequestHandler<GetGroupByIdQuery, ServiceResponse>
        {
            public GetGroupByIdQueryHandler(IGroupRepo repo) : base(repo)
            {
            }

            public async Task<ServiceResponse> Handle(GetGroupByIdQuery request, CancellationToken cancellationToken)
            {
                ArgumentNullException.ThrowIfNull(request);

                var data = await _repo.GetByIdAsync(request.GroupId);

                if(data is not null)
                {
                    var result = ConvertUtils.Map<Group, GroupDto>(data);
                    return new ServiceResponse(result);
                }
                return new ServiceResponse();
            }
        }
    }
}
