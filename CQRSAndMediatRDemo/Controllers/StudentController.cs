using CQRSAndMediatRDemo.Commands;
using CQRSAndMediatRDemo.Models;
using CQRSAndMediatRDemo.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSAndMediatRDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly IMediator _mediator;

        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("studentId")]
        public async Task<StudentDetails> GetStudentByIdAsync(int studentId)
        {
            var studentDetails = await _mediator.Send(new GetStudentByIdQuery() { Id = studentId });
            return studentDetails;
        }

        [HttpGet]
        public async Task<List<StudentDetails>> GetStudentListAsync()
        {
            var studentDetails = await _mediator.Send(new GetStudentListQuery());

            return studentDetails;
        }

        [HttpPost]
        public async Task<StudentDetails> AddstudentAsync(StudentDetails studentDetails)
        {
            var studentDetail = await _mediator.Send(new CreateStudentCommnad(
                studentDetails.StudentName,
                studentDetails.StudentEmail,
                studentDetails.StudentAddress,
                studentDetails.StudentAge

                ));

            return studentDetail;
        }

        [HttpPut]
        public async Task<int> UpdateStudentsAsync(StudentDetails studentDetails)
        {
            var isStudentDetailUpdated = await _mediator.Send(new UpdateStudentCommand(
                studentDetails.Id,
                studentDetails.StudentName,
                studentDetails.StudentEmail,
                studentDetails.StudentAddress,
                studentDetails.StudentAge
                ));

            return isStudentDetailUpdated;

        }
    }
}
