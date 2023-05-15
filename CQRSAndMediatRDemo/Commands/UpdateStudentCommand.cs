using MediatR;

namespace CQRSAndMediatRDemo.Commands
{
    public class UpdateStudentCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public string StudentAddress { get; set; }
        public int StudenAge { get; set; }

        public UpdateStudentCommand(int id, string studentName, string studentEmail, string studentAddress, int studenAge)
        {
            Id= id;
            StudentName = studentName;
            StudentEmail = studentEmail;
            StudentAddress = studentAddress;
            StudenAge = studenAge;
        }
    }
}
