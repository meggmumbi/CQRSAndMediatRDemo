using CQRSAndMediatRDemo.Commands;
using CQRSAndMediatRDemo.Repositories;
using MediatR;

namespace CQRSAndMediatRDemo.Handlers
{
    public class DeleteStudentHandler : IRequestHandler<DeleteStudentCommand, int>
    {
        private readonly IStudentRepository _studentRepository;

        public DeleteStudentHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }   

        public async Task<int> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var studentDetails = _studentRepository.GetStudentByIdAsync(request.Id);
            if (studentDetails == null)
                return default;

            return await _studentRepository.DeleteStudentsAsync(studentDetails.Id);
        }
    }
}
