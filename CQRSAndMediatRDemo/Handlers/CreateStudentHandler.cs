using CQRSAndMediatRDemo.Commands;
using CQRSAndMediatRDemo.Models;
using CQRSAndMediatRDemo.Repositories;
using MediatR;

namespace CQRSAndMediatRDemo.Handlers
{
    public class CreateStudentHandler : IRequestHandler<CreateStudentCommnad, StudentDetails>
    {
        private readonly IStudentRepository _studentRepository;

        public CreateStudentHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public Task<StudentDetails> Handle(CreateStudentCommnad request, CancellationToken cancellationToken)
        {
            var studentDetails = new StudentDetails()
            {
                StudentName = request.StudentName,
                StudentAddress = request.StudentAddress,
                StudentEmail = request.StudentEmail,
                StudentAge = request.StudentAge
            };

            return _studentRepository.AddStudentsAsync(studentDetails);
        }
    }
}
