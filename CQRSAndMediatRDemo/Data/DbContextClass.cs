using CQRSAndMediatRDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRSAndMediatRDemo.Data
{
    public class DbContextClass : DbContext
    {
        protected readonly IConfiguration _configuration;

        public DbContextClass(IConfiguration configuration) 
        {
            _configuration = configuration;
        
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }


        DbSet<StudentDetails> Students { get; set; }


    }
}
