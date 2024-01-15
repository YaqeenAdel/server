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

            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "content_type", new[] { "category", "question", "answer", "blood_donation" });
            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "phase", new[] { "draft", "published" });
            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "user_type", new[] { "patient", "doctor" });
            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "verification_status", new[] { "pending", "more_info_needed", "approved", "rejected" });
            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "visibility", new[] { "public", "private" });
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ContentInterest", b =>
                {
                    b.Property<int>("ContentsContentId")
                        .HasColumnType("integer");

                    b.Property<int>("InterestsInterestId")
                        .HasColumnType("integer");

                    b.HasKey("ContentsContentId", "InterestsInterestId");

                    b.HasIndex("InterestsInterestId");

                    b.ToTable("ContentInterest");
                });

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
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DoctorId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("QuestionId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("AnswerId");

                    b.HasIndex("DoctorId");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("YaqeenDAL.Model.Bookmark", b =>
                {
                    b.Property<int>("BookmarkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("BookmarkId"));

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<int>("ContentId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("BookmarkId");

                    b.HasAlternateKey("UserId", "ContentId");

                    b.HasIndex("ContentId");

                    b.HasIndex("UserId");

                    b.HasIndex("UserId", "ContentId")
                        .IsUnique();

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
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LogoURL")
                        .HasColumnType("text");

                    b.Property<string>("StageName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("TranslationId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

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
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LogoURL")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("TranslationId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("CancerId");

                    b.ToTable("CancerTypes");
                });

            modelBuilder.Entity("YaqeenDAL.Model.Content", b =>
                {
                    b.Property<int>("ContentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ContentId"));

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<int?>("AssignedTo")
                        .HasColumnType("integer");

                    b.Property<Attachment>("Attachments")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.Property<string>("AuthorUserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("ParentContentId")
                        .HasColumnType("integer");

                    b.Property<Phase>("Phase")
                        .HasColumnType("phase");

                    b.Property<Dictionary<string, string>>("Raw")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.Property<Dictionary<string, string>>("Tags")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.Property<int?>("TranslationId")
                        .HasColumnType("integer");

                    b.Property<ContentType>("Type")
                        .HasColumnType("content_type");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Visibility>("Visibility")
                        .HasColumnType("visibility");

                    b.HasKey("ContentId");

                    b.HasIndex("AssignedTo");

                    b.HasIndex("AuthorUserId");

                    b.HasIndex("ParentContentId");

                    b.HasIndex("Tags");

                    b.HasIndex("Type");

                    b.ToTable("Contents");
                });

            modelBuilder.Entity("YaqeenDAL.Model.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CountryId"));

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<string>("AlphaCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("CountryId");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("YaqeenDAL.Model.CountryState", b =>
                {
                    b.Property<int>("CountryStateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CountryStateId"));

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<int>("CountryId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Latitude")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Longitude")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("StateCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("CountryStateId");

                    b.HasIndex("CountryId");

                    b.ToTable("CountryStates");
                });

            modelBuilder.Entity("YaqeenDAL.Model.Doctor", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone");

                    b.Property<string[]>("CredentialsAttachments")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<string>("Degree")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("MedicalField")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("University")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<VerificationStatus>("VerificationStatus")
                        .HasColumnType("verification_status");

                    b.HasKey("UserId");

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
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LogoURL")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("StyleBackgroundColorHex")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("StyleForegroundColorHex")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<UserType>("TargetUserType")
                        .HasColumnType("user_type");

                    b.Property<int?>("TranslationId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

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

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("UserId");

                    b.HasIndex("CancerStageId");

                    b.HasIndex("CancerTypeId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("YaqeenDAL.Model.Photo", b =>
                {
                    b.Property<int>("PhotoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PhotoId"));

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("PhotoURL")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Usage")
                        .HasColumnType("integer");

                    b.HasKey("PhotoId");

                    b.ToTable("Photos");
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
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("QuestionId");

                    b.HasIndex("UserId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("YaqeenDAL.Model.ResourceLocalization", b =>
                {
                    b.Property<int>("TranslationId")
                        .HasColumnType("integer");

                    b.Property<string>("Language")
                        .HasColumnType("text");

                    b.Property<Dictionary<string, string>>("Translation")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.HasKey("TranslationId", "Language");

                    b.ToTable("ResourceLocalizations");
                });

            modelBuilder.Entity("YaqeenDAL.Model.University", b =>
                {
                    b.Property<int>("UniversityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UniversityId"));

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("StateCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("StateName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UniversityName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("UniversityId");

                    b.HasIndex("CountryCode");

                    b.HasIndex("CountryCode", "StateCode");

                    b.ToTable("Universities");
                });

            modelBuilder.Entity("YaqeenDAL.Model.User", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<bool>("AgreedTerms")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Gender")
                        .HasColumnType("text");

                    b.Property<bool>("IsEmailVerified")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MobileNumber")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("UserId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("MobileNumber")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("YaqeenDAL.Model.VerificationStatusEvent", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("EventId"));

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<VerificationStatus>("Status")
                        .HasColumnType("verification_status");

                    b.Property<string>("TargetDoctorUserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("VerifierUserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("EventId");

                    b.HasIndex("TargetDoctorUserId");

                    b.HasIndex("UserId");

                    b.HasIndex("VerifierUserId");

                    b.ToTable("VerificationStatusEvent");
                });

            modelBuilder.Entity("ContentInterest", b =>
                {
                    b.HasOne("YaqeenDAL.Model.Content", null)
                        .WithMany()
                        .HasForeignKey("ContentsContentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YaqeenDAL.Model.Interest", null)
                        .WithMany()
                        .HasForeignKey("InterestsInterestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
                        .WithMany()
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
                    b.HasOne("YaqeenDAL.Model.Content", "Content")
                        .WithOne("Bookmark")
                        .HasForeignKey("YaqeenDAL.Model.Bookmark", "ContentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YaqeenDAL.Model.User", "User")
                        .WithMany("Bookmarks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Content");

                    b.Navigation("User");
                });

            modelBuilder.Entity("YaqeenDAL.Model.Content", b =>
                {
                    b.HasOne("YaqeenDAL.Model.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YaqeenDAL.Model.Content", "ParentContent")
                        .WithMany()
                        .HasForeignKey("ParentContentId");

                    b.Navigation("Author");

                    b.Navigation("ParentContent");
                });

            modelBuilder.Entity("YaqeenDAL.Model.CountryState", b =>
                {
                    b.HasOne("YaqeenDAL.Model.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("YaqeenDAL.Model.Doctor", b =>
                {
                    b.HasOne("YaqeenDAL.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
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
                    b.HasOne("YaqeenDAL.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("YaqeenDAL.Model.VerificationStatusEvent", b =>
                {
                    b.HasOne("YaqeenDAL.Model.Doctor", "TargetDoctor")
                        .WithMany()
                        .HasForeignKey("TargetDoctorUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YaqeenDAL.Model.Doctor", null)
                        .WithMany("VerificationStatusEvents")
                        .HasForeignKey("UserId");

                    b.HasOne("YaqeenDAL.Model.User", "Verifier")
                        .WithMany()
                        .HasForeignKey("VerifierUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TargetDoctor");

                    b.Navigation("Verifier");
                });

            modelBuilder.Entity("YaqeenDAL.Model.Content", b =>
                {
                    b.Navigation("Bookmark");
                });

            modelBuilder.Entity("YaqeenDAL.Model.Doctor", b =>
                {
                    b.Navigation("VerificationStatusEvents");
                });

            modelBuilder.Entity("YaqeenDAL.Model.Question", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("YaqeenDAL.Model.User", b =>
                {
                    b.Navigation("Bookmarks");
                });
#pragma warning restore 612, 618
        }
    }
}
