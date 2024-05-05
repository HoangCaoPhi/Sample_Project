using Demo.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sample.Application.Features.Commands.Create;
using Sample.Application.Features.Commands.Update;
using Sample.Application.Features.Queries.GetAll;
using Sample.Application.Features.Queries.GetById;
using Sample.Application.Features.Queries.GetPaging;
using Sample.Application.Models.Request.Group;
using Sample.Application.Models.Request.Paging;

namespace Sample.BussinessApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SampleController : Controller
    {
        private readonly IMediator _mediator;
        public SampleController(IMediator mediator) {
            _mediator = mediator;
        }

        [HttpPost("")]
        public async Task<ServiceResponse> Save([FromBody] SaveGroupRequest request)
        {
            return await _mediator.Send(new CreateGroupCommand()
            {
                SaveGroupRequest = request
            });
        }

        [HttpPut("")]
        public async Task<ServiceResponse> Update([FromBody] UpdateGroupRequest request)
        {
            return await _mediator.Send(new UpdateGroupCommand()
            {
                UpdateGroupRequest = request
            });
        }

        [HttpGet("{groupID}")]
        public async Task<ServiceResponse> GetByID(int groupID)
        {
            return await _mediator.Send(new GetGroupByIdQuery()
            {
                GroupId = groupID
            });
        }

        [HttpGet("all")]
        public async Task<ServiceResponse> Update()
        {
            return await _mediator.Send(new GetAllGroupQuery());
        }

        [HttpGet("paging")]
        public async Task<ServiceResponse> Update([FromQuery] PagingRequest request)
        {
            return await _mediator.Send(new GetGroupPaingQuery()
            {
                PageIndex = request.PageIndex,
                PageSize = request.PageSize
            });
        }

        [HttpDelete("{groupID}")]
        public async Task<ServiceResponse> Delete(int groupID)
        {
            return await _mediator.Send(new DeleteGroupCommand()
            {
                GroupId = groupID
            });
        }
    }
}
