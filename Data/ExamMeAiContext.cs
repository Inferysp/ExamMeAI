using ExamMeAI.Models;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ExamMeAI.Data
{
    public class ExamMeAiContext : DbContext
    {
        public ExamMeAiContext(DbContextOptions<ExamMeAiContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        public DbSet<Questions> Questions { get; set; }
        public DbSet<Title> Title { get; set; }
        public DbSet<Domain> Domain { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Exams> Exams { get; set; }

        public DbSet<UserActivity> UserActivity { get; set; }
    }
}
