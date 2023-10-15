﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using YaqeenDAL.Model;

#nullable disable

namespace YaqeenDAL.Migrations
{
    [DbContext(typeof(YaqeenDbContext))]
    partial class YaqeenDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("InterestUser", b =>
                {
                    b.Property<int>("InterestsInterestId")
                        .HasColumnType("integer");

                    b.Property<string>("UsersUserId")
                        .HasColumnType("text");

                    b.HasKey("InterestsInterestId", "UsersUserId");

                    b.HasIndex("UsersUserId");

                    b.ToTable("InterestUser");
                });

            modelBuilder.Entity("YaqeenDAL.Model.Answer", b =>
                {
                    b.Property<int>("AnswerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AnswerId"));

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DoctorId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("QuestionId")
                        .HasColumnType("integer");

                    b.HasKey("AnswerId");

                    b.HasIndex("DoctorId");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("YaqeenDAL.Model.Article", b =>
                {
                    b.Property<int>("ArticleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ArticleId"));

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ArticleId");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("YaqeenDAL.Model.Bookmark", b =>
                {
                    b.Property<int>("BookmarkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("BookmarkId"));

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<int?>("ArticleId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("BookmarkId");

                    b.HasIndex("ArticleId");

                    b.HasIndex("UserId");

                    b.ToTable("Bookmarks");
                });

            modelBuilder.Entity("YaqeenDAL.Model.CancerStage", b =>
                {
                    b.Property<int>("StageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("StageId"));

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LogoURL")
                        .HasColumnType("text");

                    b.Property<string>("StageName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("StageId");

                    b.ToTable("CancerStages");
                });

            modelBuilder.Entity("YaqeenDAL.Model.CancerType", b =>
                {
                    b.Property<int>("CancerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CancerId"));

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<string>("CancerTypeName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LogoURL")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CancerId");

                    b.ToTable("CancerTypes");
                });

            modelBuilder.Entity("YaqeenDAL.Model.Doctor", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<string>("Degree")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("MedicalField")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("University")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("VerificationStatusId")
                        .HasColumnType("integer");

                    b.HasKey("UserId");

                    b.HasIndex("VerificationStatusId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("YaqeenDAL.Model.Interest", b =>
                {
                    b.Property<int>("InterestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("InterestId"));

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LogoURL")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TargetUserType")
                        .HasColumnType("integer");

                    b.HasKey("InterestId");

                    b.ToTable("Interests");
                });

            modelBuilder.Entity("YaqeenDAL.Model.Patient", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<int>("AgeGroup")
                        .HasColumnType("integer");

                    b.Property<int>("CancerStageId")
                        .HasColumnType("integer");

                    b.Property<int>("CancerTypeId")
                        .HasColumnType("integer");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.HasKey("UserId");

                    b.HasIndex("CancerStageId");

                    b.HasIndex("CancerTypeId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("YaqeenDAL.Model.Question", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("QuestionId"));

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("PatientUserId")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("QuestionId");

                    b.HasIndex("PatientUserId");

                    b.HasIndex("UserId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("YaqeenDAL.Model.ResourceLocalization", b =>
                {
                    b.Property<int>("TranslationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TranslationId"));

                    b.Property<int?>("CancerStageStageId")
                        .HasColumnType("integer");

                    b.Property<int?>("CancerTypeCancerId")
                        .HasColumnType("integer");

                    b.Property<int?>("InterestId")
                        .HasColumnType("integer");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Dictionary<string, string>>("Translation")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.HasKey("TranslationId");

                    b.HasIndex("CancerStageStageId");

                    b.HasIndex("CancerTypeCancerId");

                    b.HasIndex("InterestId");

                    b.ToTable("ResourceLocalization");
                });

            modelBuilder.Entity("YaqeenDAL.Model.User", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<bool>("AgreedTerms")
                        .HasColumnType("boolean");

                    b.Property<byte[]>("DeletedAt")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("bytea");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Gender")
                        .HasColumnType("text");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<bool>("IsEmailVerified")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MobileNumber")
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("MobileNumber")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("YaqeenDAL.Model.VerificationStatus", b =>
                {
                    b.Property<int>("VerificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("VerificationId"));

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("bytea");

                    b.Property<string>("TargetDoctorUserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("VerifierUserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("VerificationId");

                    b.HasIndex("TargetDoctorUserId");

                    b.HasIndex("VerifierUserId");

                    b.ToTable("VerificationStatus");
                });

            modelBuilder.Entity("InterestUser", b =>
                {
                    b.HasOne("YaqeenDAL.Model.Interest", null)
                        .WithMany()
                        .HasForeignKey("InterestsInterestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YaqeenDAL.Model.User", null)
                        .WithMany()
                        .HasForeignKey("UsersUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("YaqeenDAL.Model.Answer", b =>
                {
                    b.HasOne("YaqeenDAL.Model.Doctor", "Doctor")
                        .WithMany("Answers")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YaqeenDAL.Model.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("YaqeenDAL.Model.Bookmark", b =>
                {
                    b.HasOne("YaqeenDAL.Model.Article", "Article")
                        .WithMany("Bookmarks")
                        .HasForeignKey("ArticleId");

                    b.HasOne("YaqeenDAL.Model.Doctor", "Doctor")
                        .WithMany("Bookmarks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YaqeenDAL.Model.Patient", "Patient")
                        .WithMany("Bookmarks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("YaqeenDAL.Model.Doctor", b =>
                {
                    b.HasOne("YaqeenDAL.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YaqeenDAL.Model.VerificationStatus", "VerificationStatus")
                        .WithMany()
                        .HasForeignKey("VerificationStatusId");

                    b.Navigation("User");

                    b.Navigation("VerificationStatus");
                });

            modelBuilder.Entity("YaqeenDAL.Model.Patient", b =>
                {
                    b.HasOne("YaqeenDAL.Model.CancerStage", "CancerStage")
                        .WithMany()
                        .HasForeignKey("CancerStageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YaqeenDAL.Model.CancerType", "CancerType")
                        .WithMany()
                        .HasForeignKey("CancerTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YaqeenDAL.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CancerStage");

                    b.Navigation("CancerType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("YaqeenDAL.Model.Question", b =>
                {
                    b.HasOne("YaqeenDAL.Model.Patient", null)
                        .WithMany("Questions")
                        .HasForeignKey("PatientUserId");

                    b.HasOne("YaqeenDAL.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("YaqeenDAL.Model.ResourceLocalization", b =>
                {
                    b.HasOne("YaqeenDAL.Model.CancerStage", null)
                        .WithMany("Translations")
                        .HasForeignKey("CancerStageStageId");

                    b.HasOne("YaqeenDAL.Model.CancerType", null)
                        .WithMany("Translations")
                        .HasForeignKey("CancerTypeCancerId");

                    b.HasOne("YaqeenDAL.Model.Interest", null)
                        .WithMany("Translations")
                        .HasForeignKey("InterestId");
                });

            modelBuilder.Entity("YaqeenDAL.Model.VerificationStatus", b =>
                {
                    b.HasOne("YaqeenDAL.Model.Doctor", "TargetDoctor")
                        .WithMany()
                        .HasForeignKey("TargetDoctorUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YaqeenDAL.Model.User", "Verifier")
                        .WithMany()
                        .HasForeignKey("VerifierUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TargetDoctor");

                    b.Navigation("Verifier");
                });

            modelBuilder.Entity("YaqeenDAL.Model.Article", b =>
                {
                    b.Navigation("Bookmarks");
                });

            modelBuilder.Entity("YaqeenDAL.Model.CancerStage", b =>
                {
                    b.Navigation("Translations");
                });

            modelBuilder.Entity("YaqeenDAL.Model.CancerType", b =>
                {
                    b.Navigation("Translations");
                });

            modelBuilder.Entity("YaqeenDAL.Model.Doctor", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("Bookmarks");
                });

            modelBuilder.Entity("YaqeenDAL.Model.Interest", b =>
                {
                    b.Navigation("Translations");
                });

            modelBuilder.Entity("YaqeenDAL.Model.Patient", b =>
                {
                    b.Navigation("Bookmarks");

                    b.Navigation("Questions");
                });

            modelBuilder.Entity("YaqeenDAL.Model.Question", b =>
                {
                    b.Navigation("Answers");
                });
#pragma warning restore 612, 618
        }
    }
}
