using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace subWebTemech.Models
{
    public class subWebTemechDbContext : DbContext
    {
        public subWebTemechDbContext(DbContextOptions<subWebTemechDbContext> options) : base(options)
        { }
        public DbSet<User> users { get; set; }
        public DbSet<Location> locations { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<SubCategory> SubCategory { get; set; }
        public DbSet<CategorySubCategory> CategorySubCategory { get; set; }
        public DbSet<JobType> JobType { get; set; }
        public DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<Job> job { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<AnswerSimulation> AnswerSimulations { get; set; }
        public DbSet<QuestionSimulation> QuestionSimulations { get; set; }
        public DbSet<InterviewSimulation> InterviewSimulations { get; set; }
        public DbSet<QuestionAnswer> QuestionAnswer { get; set; }
        public DbSet<Job> Job { get; set; }
        public DbSet<CV> cVs { get; set; }



    }
}
