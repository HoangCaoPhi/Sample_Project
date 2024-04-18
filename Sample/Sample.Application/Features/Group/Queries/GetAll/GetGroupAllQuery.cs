using Demo.Application.Models;
using MediatR;
using Sample.Application.Common.Utils;
using Sample.Application.Dtos;
using Sample.Domain.Interfaces;

namespace Sample.Application.Features.Queries.GetAll
{
    public class GetAllGroupQuery : IRequest<ServiceResponse>
    {
        public class GetAllGroupQueryHandler : BaseCqrs<IGroupRepo>, IRequestHandler<GetAllGroupQuery, ServiceResponse>
        {
            public GetAllGroupQueryHandler(IGroupRepo repo) : base(repo)
            {
            }

            public async Task<ServiceResponse> Handle(GetAllGroupQuery request, CancellationToken cancellationToken)
            {
                ArgumentNullException.ThrowIfNull(request);

                var data = await _repo.GetAllAsync();

                if (data is not null)
                {
                    var result = ConvertUtils.MapListObject<GroupDto> (data);
                    return new ServiceResponse(result);
                }
                return new ServiceResponse();
            }
        }
    }
}
