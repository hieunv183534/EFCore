using CandidateTestService.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CandidateTestService.Repository
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<QuestionSection> QuestionSections { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<TestResult> TestResults { get; set; }
        public DbSet<TokenAccount> TokenAccounts { get; set; }
        public DbSet<TestAccount> TestAccounts { get; set; }

    }
}
