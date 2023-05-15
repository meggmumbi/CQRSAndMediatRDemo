using CQRSAndMediatRDemo.Models;
using MediatR;

namespace CQRSAndMediatRDemo.Commands
{
    public class CreateStudentCommnad : IRequest<StudentDetails>
    {
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public string StudentAddress { get; set; }
        public int StudentAge { get; set; }

        public CreateStudentCommnad(string studentName,string studentEmail, string studentAddress, int studentAge) 
        {
            StudentName = studentName;
            StudentEmail = studentEmail;
            StudentAddress = studentAddress;
            StudentAge = studentAge;
                 
        
        }
    }
}
