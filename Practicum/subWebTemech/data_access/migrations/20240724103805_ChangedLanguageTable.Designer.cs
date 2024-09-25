﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using subWebTemech.Models;

#nullable disable

namespace subWebTemech.data_access.migrations
{
    [DbContext(typeof(subWebTemechDbContext))]
    [Migration("20240724103805_ChangedLanguageTable")]
    partial class ChangedLanguageTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("subWebTemech.Models.AnswerSimulation", b =>
                {
                    b.Property<int>("AnswerSimulationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AnswerSimulationID"), 1L, 1);

                    b.Property<string>("AnswerText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InterviewSimulationID")
                        .HasColumnType("int");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("bit");

                    b.Property<string>("Links")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuestionSimulationID")
                        .HasColumnType("int");

                    b.HasKey("AnswerSimulationID");

                    b.HasIndex("InterviewSimulationID");

                    b.HasIndex("QuestionSimulationID");

                    b.ToTable("AnswerSimulation");
                });

            modelBuilder.Entity("subWebTemech.Models.Category", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("subWebTemech.Models.CategoryProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategorySubCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("UserProfileID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategorySubCategoryId");

                    b.HasIndex("UserProfileID");

                    b.ToTable("CategoryProfile");
                });

            modelBuilder.Entity("subWebTemech.Models.CategorySubCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("SubCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SubCategoryId");

                    b.ToTable("CategorySubCategory");
                });

            modelBuilder.Entity("subWebTemech.Models.CV", b =>
                {
                    b.Property<int>("CVId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CVId"), 1L, 1);

                    b.Property<int>("AmountOfCV")
                        .HasColumnType("int");

                    b.Property<bool>("Favorite")
                        .HasColumnType("bit");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RatingValue")
                        .HasColumnType("int");

                    b.Property<DateTime>("UploadDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CVId");

                    b.HasIndex("UserId");

                    b.ToTable("CV");
                });

            modelBuilder.Entity("subWebTemech.Models.ExperienceLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("experienceLevels");
                });

            modelBuilder.Entity("subWebTemech.Models.Interview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("InterviewDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Interview");
                });

            modelBuilder.Entity("subWebTemech.Models.InterviewSimulation", b =>
                {
                    b.Property<int>("InterviewSimulationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InterviewSimulationID"), 1L, 1);

                    b.Property<DateTime>("InterviewSimulationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("InterviewSimulationID");

                    b.HasIndex("UserID");

                    b.ToTable("InterviewSimulation");
                });

            modelBuilder.Entity("subWebTemech.Models.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExperienceLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PostedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserProfileID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserProfileID");

                    b.ToTable("job");
                });

            modelBuilder.Entity("subWebTemech.Models.JobSubCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("categorySubCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("jobId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("categorySubCategoryId");

                    b.HasIndex("jobId");

                    b.ToTable("JobSubCategory");
                });

            modelBuilder.Entity("subWebTemech.Models.JobSudmitted", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("jobID")
                        .HasColumnType("int");

                    b.Property<int>("userIdId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("userIdId");

                    b.ToTable("JobSudmitted");
                });

            modelBuilder.Entity("subWebTemech.Models.JobType", b =>
                {
                    b.Property<int>("JobTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JobTypeId"), 1L, 1);

                    b.Property<string>("JobTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("JobTypeId");

                    b.ToTable("JobType");
                });

            modelBuilder.Entity("subWebTemech.Models.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("languages");
                });

            modelBuilder.Entity("subWebTemech.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("locations");
                });

            modelBuilder.Entity("subWebTemech.Models.QuestionsAndAnswers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CountApproves")
                        .HasColumnType("int");

                    b.Property<int>("CountViewes")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("QuestionsAndAnswers");
                });

            modelBuilder.Entity("subWebTemech.Models.QuestionSimulation", b =>
                {
                    b.Property<int>("QuestionSimulationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuestionSimulationID"), 1L, 1);

                    b.Property<string>("Hint")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuestionText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("interviewSimulationID")
                        .HasColumnType("int");

                    b.HasKey("QuestionSimulationID");

                    b.ToTable("QuestionSimulation");
                });

            modelBuilder.Entity("subWebTemech.Models.Sharing", b =>
                {
                    b.Property<int>("SharingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SharingId"), 1L, 1);

                    b.Property<int>("CVId")
                        .HasColumnType("int");

                    b.Property<string>("ShareMethod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SharingId");

                    b.HasIndex("CVId");

                    b.ToTable("sharings");
                });

            modelBuilder.Entity("subWebTemech.Models.SubCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SubCategory");
                });

            modelBuilder.Entity("subWebTemech.Models.TranslateCV", b =>
                {
                    b.Property<int>("TranslateCVId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TranslateCVId"), 1L, 1);

                    b.Property<int>("CVId")
                        .HasColumnType("int");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.HasKey("TranslateCVId");

                    b.HasIndex("CVId");

                    b.HasIndex("LanguageId");

                    b.ToTable("TranslateCV");
                });

            modelBuilder.Entity("subWebTemech.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsGoogleAccount")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("subWebTemech.Models.UserProfile", b =>
                {
                    b.Property<int>("UserProfileID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserProfileID"), 1L, 1);

                    b.Property<string>("ExperienceLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("UserProfileID");

                    b.HasIndex("UserID");

                    b.ToTable("UserProfile");
                });

            modelBuilder.Entity("subWebTemech.Models.AnswerSimulation", b =>
                {
                    b.HasOne("subWebTemech.Models.InterviewSimulation", "InterviewSimulation")
                        .WithMany()
                        .HasForeignKey("InterviewSimulationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("subWebTemech.Models.QuestionSimulation", "QuestionSimulation")
                        .WithMany()
                        .HasForeignKey("QuestionSimulationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InterviewSimulation");

                    b.Navigation("QuestionSimulation");
                });

            modelBuilder.Entity("subWebTemech.Models.CategoryProfile", b =>
                {
                    b.HasOne("subWebTemech.Models.CategorySubCategory", "CategorySubCategory")
                        .WithMany("CategoryProfile")
                        .HasForeignKey("CategorySubCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("subWebTemech.Models.UserProfile", "UserProfile")
                        .WithMany("CategoryProfiles")
                        .HasForeignKey("UserProfileID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategorySubCategory");

                    b.Navigation("UserProfile");
                });

            modelBuilder.Entity("subWebTemech.Models.CategorySubCategory", b =>
                {
                    b.HasOne("subWebTemech.Models.Category", "Category")
                        .WithMany("categorySubCategorys")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("subWebTemech.Models.SubCategory", "SubCategory")
                        .WithMany("CategorySubCategorys")
                        .HasForeignKey("SubCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("SubCategory");
                });

            modelBuilder.Entity("subWebTemech.Models.CV", b =>
                {
                    b.HasOne("subWebTemech.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("subWebTemech.Models.Interview", b =>
                {
                    b.HasOne("subWebTemech.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("subWebTemech.Models.InterviewSimulation", b =>
                {
                    b.HasOne("subWebTemech.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("subWebTemech.Models.Job", b =>
                {
                    b.HasOne("subWebTemech.Models.UserProfile", "UserProfile")
                        .WithMany("Jobs")
                        .HasForeignKey("UserProfileID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserProfile");
                });

            modelBuilder.Entity("subWebTemech.Models.JobSubCategory", b =>
                {
                    b.HasOne("subWebTemech.Models.CategorySubCategory", "CategorySubCategory")
                        .WithMany("JobSubCategorys")
                        .HasForeignKey("categorySubCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("subWebTemech.Models.Job", "Job")
                        .WithMany("JobSubCategorys")
                        .HasForeignKey("jobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategorySubCategory");

                    b.Navigation("Job");
                });

            modelBuilder.Entity("subWebTemech.Models.JobSudmitted", b =>
                {
                    b.HasOne("subWebTemech.Models.User", "userId")
                        .WithMany()
                        .HasForeignKey("userIdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("userId");
                });

            modelBuilder.Entity("subWebTemech.Models.Sharing", b =>
                {
                    b.HasOne("subWebTemech.Models.CV", "CV")
                        .WithMany("SharingCV")
                        .HasForeignKey("CVId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CV");
                });

            modelBuilder.Entity("subWebTemech.Models.TranslateCV", b =>
                {
                    b.HasOne("subWebTemech.Models.CV", "CV")
                        .WithMany("TransCV")
                        .HasForeignKey("CVId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("subWebTemech.Models.Language", "Language")
                        .WithMany("TranslateCVs")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CV");

                    b.Navigation("Language");
                });

            modelBuilder.Entity("subWebTemech.Models.UserProfile", b =>
                {
                    b.HasOne("subWebTemech.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("subWebTemech.Models.Category", b =>
                {
                    b.Navigation("categorySubCategorys");
                });

            modelBuilder.Entity("subWebTemech.Models.CategorySubCategory", b =>
                {
                    b.Navigation("CategoryProfile");

                    b.Navigation("JobSubCategorys");
                });

            modelBuilder.Entity("subWebTemech.Models.CV", b =>
                {
                    b.Navigation("SharingCV");

                    b.Navigation("TransCV");
                });

            modelBuilder.Entity("subWebTemech.Models.Job", b =>
                {
                    b.Navigation("JobSubCategorys");
                });

            modelBuilder.Entity("subWebTemech.Models.Language", b =>
                {
                    b.Navigation("TranslateCVs");
                });

            modelBuilder.Entity("subWebTemech.Models.SubCategory", b =>
                {
                    b.Navigation("CategorySubCategorys");
                });

            modelBuilder.Entity("subWebTemech.Models.UserProfile", b =>
                {
                    b.Navigation("CategoryProfiles");

                    b.Navigation("Jobs");
                });
#pragma warning restore 612, 618
        }
    }
}
