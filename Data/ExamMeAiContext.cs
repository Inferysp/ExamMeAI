using ExamMeAI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ExamMeAI.Data
{
    public class ExamMeAiContext : DbContext
    {
        public ExamMeAiContext(DbContextOptions<ExamMeAiContext> options) : base(options)
        { }


        public DbSet<Question> Question { get; set; }
        public DbSet<Title> Title { get; set; }
        public DbSet<Domain> Domain { get; set; }

    }
}
