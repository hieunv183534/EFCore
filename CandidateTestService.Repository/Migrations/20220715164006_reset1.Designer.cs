﻿// <auto-generated />
using System;
using CandidateTestService.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CandidateTestService.Repository.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20220715164006_reset1")]
    partial class reset1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CandidateTestService.Core.Entities.Account", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<string>("Address")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("Date");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("FullName")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("Password")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Phone")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Role")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("UserName")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Account");
                });

            modelBuilder.Entity("CandidateTestService.Core.Entities.Question", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<string>("AnswerText")
                        .HasColumnType("TEXT");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<string>("ContentJSON")
                        .HasColumnType("TEXT");

                    b.Property<string>("ContentText")
                        .HasColumnType("varchar(300)")
                        .HasMaxLength(300);

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("CandidateTestService.Core.Entities.QuestionSection", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime");

                    b.Property<byte[]>("QuestionId")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.Property<byte[]>("SectionId")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.HasIndex("SectionId");

                    b.ToTable("QuestionSections");
                });

            modelBuilder.Entity("CandidateTestService.Core.Entities.Section", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("SectionName")
                        .HasColumnType("text");

                    b.Property<byte[]>("TestId")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.HasKey("Id");

                    b.HasIndex("TestId");

                    b.ToTable("Section");
                });

            modelBuilder.Entity("CandidateTestService.Core.Entities.Test", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("TestCode")
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("TestName")
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("TestCode")
                        .IsUnique();

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("CandidateTestService.Core.Entities.TestAccount", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<byte[]>("AccountId")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime");

                    b.Property<byte[]>("TestId")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("TestId");

                    b.ToTable("TestAccounts");
                });

            modelBuilder.Entity("CandidateTestService.Core.Entities.TestResult", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<byte[]>("AccountId")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime");

                    b.Property<int>("SoCauDung")
                        .HasColumnType("int");

                    b.Property<int>("SoCauSai")
                        .HasColumnType("int");

                    b.Property<int>("SoCauTuLuan")
                        .HasColumnType("int");

                    b.Property<string>("TestAnswerJSON")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("TestResults");
                });

            modelBuilder.Entity("CandidateTestService.Core.Entities.TokenAccount", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("Token")
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TokenAccounts");
                });

            modelBuilder.Entity("CandidateTestService.Core.Entities.QuestionSection", b =>
                {
                    b.HasOne("CandidateTestService.Core.Entities.Question", "Question")
                        .WithMany("QuestionSections")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CandidateTestService.Core.Entities.Section", "Section")
                        .WithMany("QuestionSections")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CandidateTestService.Core.Entities.Section", b =>
                {
                    b.HasOne("CandidateTestService.Core.Entities.Test", "Test")
                        .WithMany("Sections")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CandidateTestService.Core.Entities.TestAccount", b =>
                {
                    b.HasOne("CandidateTestService.Core.Entities.Account", "Account")
                        .WithMany("TestAccounts")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CandidateTestService.Core.Entities.Test", "Test")
                        .WithMany("TestAccounts")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CandidateTestService.Core.Entities.TestResult", b =>
                {
                    b.HasOne("CandidateTestService.Core.Entities.Account", null)
                        .WithMany("TestResults")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}