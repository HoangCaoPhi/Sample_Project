using Demo.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sample.Application.Features.Queries.GetAllCouses;

namespace Sample.BussinessApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : Controller
    {
        private readonly IMediator _mediator;
        public CourseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all")]
        public async Task<ServiceResponse> GetAll()
        {
            return new ServiceResponse()
            {
                Data = await _mediator.Send(new GetAllCourseQuery())
            };
        }
    }
}
