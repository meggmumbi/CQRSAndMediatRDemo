using CQRSAndMediatRDemo.Models;

namespace CQRSAndMediatRDemo.Repositories
{
    public interface IStudentRepository
    {
        public Task<StudentDetails> AddStudentsAsync(StudentDetails studentDetails);
        public Task<int> UpdateStudentsAsync(StudentDetails studentDetails);
        public Task<int> DeleteStudentsAsync(int id);
        public Task<StudentDetails> GetStudentByIdAsync(int id);
        public Task<List<StudentDetails>> GetAllStudentsAsync();
    }
}
