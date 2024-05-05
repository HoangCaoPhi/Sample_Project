using Demo.Application.Models;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Sample.Application.Common.Utils;
using Sample.Application.Models.Request.Group;
using Sample.Domain.Entities;
using Sample.Domain.Interfaces;

namespace Sample.Application.Features.Commands.Create
{
    public class CreateGroupCommand : IRequest<ServiceResponse>
    {
        public SaveGroupRequest SaveGroupRequest;

        public class CreateGroupCommandHandler : BaseCqrs<IGroupRepo>, IRequestHandler<CreateGroupCommand, ServiceResponse>
        {
            public CreateGroupCommandHandler(IGroupRepo repo) : base(repo)
            {
            }

            public async Task<ServiceResponse> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
            {
                ArgumentNullException.ThrowIfNull(request);

                var entity = ConvertUtils.Map<SaveGroupRequest, Group>(request.SaveGroupRequest);
                var data = await _repo.SaveAsync(entity);
                return new ServiceResponse(data);
            }
        }
    }
}
