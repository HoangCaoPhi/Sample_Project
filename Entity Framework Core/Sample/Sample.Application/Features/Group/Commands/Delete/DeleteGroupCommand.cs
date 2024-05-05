using Demo.Application.Models;
using MediatR;
using Sample.Domain.Interfaces;

namespace Sample.Application.Features.Commands.Create
{
    public class DeleteGroupCommand : IRequest<ServiceResponse>
    {
        public int GroupId;

        public class DeleteGroupCommanddHandler : BaseCqrs<IGroupRepo>, IRequestHandler<DeleteGroupCommand, ServiceResponse>
        {
            public DeleteGroupCommanddHandler(IGroupRepo repo) : base(repo)
            {
            }

            public async Task<ServiceResponse> Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
            {
                ArgumentNullException.ThrowIfNull(request);

                var entity = await _repo.GetByIdAsync(request.GroupId) ?? throw new Exception("Group Id not exits");
                var data = await _repo.DeleteAsync(entity);

                return new ServiceResponse(data);
            }
        }
    }
}
