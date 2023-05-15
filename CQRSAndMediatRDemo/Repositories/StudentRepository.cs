using CQRSAndMediatRDemo.Data;
using CQRSAndMediatRDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRSAndMediatRDemo.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DbContextClass _contextClass;

        public StudentRepository(DbContextClass contextClass)
        {
            _contextClass = contextClass;
        }

        public async Task<StudentDetails> AddStudentsAsync(StudentDetails studentDetails)
        {
            var result = await _contextClass.Students.AddAsync(studentDetails);
            await _contextClass.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> DeleteStudentsAsync(int id)
        {
            var filteredStudent = await _contextClass.Students.Where(x => x.Id == id).FirstOrDefaultAsync();
            _contextClass.Remove(filteredStudent);

            return await _contextClass.SaveChangesAsync();

        }

        public async Task<List<StudentDetails>> GetAllStudentsAsync()
        {
            return await _contextClass.Students.ToListAsync();
        }

        public async Task<StudentDetails> GetStudentByIdAsync(int id)
        {
            return await _contextClass.Students.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> UpdateStudentsAsync(StudentDetails studentDetails)
        {
            _contextClass.Students.Update(studentDetails);
            return await _contextClass.SaveChangesAsync();
        }
    }
}
