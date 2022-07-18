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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Test>()
                        .HasIndex(u => u.TestCode)
                        .IsUnique();
            builder.Entity<Account>()
                        .HasIndex(u => u.UserName)
                        .IsUnique();

            builder.Entity<Test>()
                .HasMany(t => t.Sections)
                .WithOne(s => s.Test)
                .HasForeignKey(s => s.TestId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Section>()
                .HasMany(s => s.QuestionSections)
                .WithOne(qs => qs.Section)
                .HasForeignKey(qs => qs.SectionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Test>()
                .HasMany(t => t.TestAccounts)
                .WithOne(ta => ta.Test)
                .HasForeignKey(ta => ta.TestId)
                .OnDelete(DeleteBehavior.Cascade);
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
