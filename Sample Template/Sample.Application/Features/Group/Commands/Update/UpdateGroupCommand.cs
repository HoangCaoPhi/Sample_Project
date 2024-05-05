using Demo.Application.Models;
using MediatR;
using Sample.Application.Models.Request.Group;
using Sample.Domain.Interfaces;

namespace Sample.Application.Features.Commands.Update
{
    public class UpdateGroupCommand : IRequest<ServiceResponse>
    {
        public UpdateGroupRequest UpdateGroupRequest;

        public class UpdateGroupCommandHandler : BaseCqrs<IGroupRepo>, IRequestHandler<UpdateGroupCommand, ServiceResponse>
        {
            public UpdateGroupCommandHandler(IGroupRepo repo) : base(repo)
            {
            }

            public async Task<ServiceResponse> Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
            {
                ArgumentNullException.ThrowIfNull(request);

                var entity = await _repo.GetByIdAsync(request.UpdateGroupRequest.GroupId) ?? throw new Exception("Group Id not exits");
                entity.GroupName = request.UpdateGroupRequest.GroupName;
                entity.Description = request.UpdateGroupRequest.Description;
                entity.GroupTypeEnum = request.UpdateGroupRequest.GroupTypeEnum;

                bool result = await _repo.UpdateAsync(entity);
                return new ServiceResponse(result);
            }
        }
    }
}
