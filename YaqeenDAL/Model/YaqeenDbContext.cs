using Microsoft.EntityFrameworkCore;

namespace YaqeenDAL.Model
{
    public class YaqeenDbContext : DbContext
    {
        public YaqeenDbContext(DbContextOptions<YaqeenDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<CancerType> CancerTypes { get; set; }
        public DbSet<CancerStage> CancerStages { get; set; }
        public DbSet<AreaofInterest> AreaofInterests { get; set; }
        public DbSet<PatientAreaofInterest> PatientAreaofInterests { get; set; }
        public DbSet<DoctorAreaofInterest> DoctorAreaofInterests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Bookmark> Bookmarks { get; set; }
        public DbSet<VerificationCode> VerificationCodes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the primary keys
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<Patient>().HasKey(p => p.Id);
            modelBuilder.Entity<Doctor>().HasKey(d => d.Id);
            modelBuilder.Entity<CancerStage>().HasKey(d => d.StageId);
            modelBuilder.Entity<CancerType>().HasKey(d => d.CancerId);
            modelBuilder.Entity<AreaofInterest>().HasKey(d => d.AreaId);

            modelBuilder.Entity<Question>().HasKey(q => q.Id);
            modelBuilder.Entity<Answer>().HasKey(a => a.AnswerId);
            modelBuilder.Entity<Article>().HasKey(a => a.ArticleId);
            modelBuilder.Entity<Bookmark>().HasKey(b => b.BookmarkId);
            modelBuilder.Entity<VerificationCode>().HasKey(v => v.Id);


            // Define relationships
            modelBuilder.Entity<User>()
                .HasOne(u => u.Patient)
                .WithOne(p => p.User)
                .HasForeignKey<Patient>(p => p.UserId);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Doctor)
                .WithOne(d => d.User)
                .HasForeignKey<Doctor>(d => d.UserId);

            modelBuilder.Entity<Patient>()
                .HasMany(p => p.Questions)
                .WithOne(q => q.Patient)
                .HasForeignKey(q => q.PatientId);

            modelBuilder.Entity<Patient>()
                .HasMany(p => p.Bookmarks)
                .WithOne(b => b.Patient)
                .HasForeignKey(b => b.UserId);

            modelBuilder.Entity<Doctor>()
                .HasMany(d => d.Answers)
                .WithOne(a => a.Doctor)
                .HasForeignKey(a => a.DoctorId);

            modelBuilder.Entity<Doctor>()
                .HasMany(d => d.Bookmarks)
                .WithOne(b => b.Doctor)
                .HasForeignKey(b => b.UserId);

            modelBuilder.Entity<Question>()
                .HasMany(q => q.Answers)
                .WithOne(a => a.Question)
                .HasForeignKey(a => a.QuestionId);

            modelBuilder.Entity<Article>()
                .HasMany(a => a.Bookmarks)
                .WithOne(b => b.Article)
                .HasForeignKey(b => b.ArticleId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.VerificationCodes)
                .WithOne(v => v.User)
                .HasForeignKey(v => v.UserId);

            modelBuilder.Entity<Patient>()
            .HasOne(cs => cs.CancerStage)
            .WithOne(p => p.Patient)
            .HasForeignKey<CancerStage>(p => p.StageId)
             .IsRequired(false);

            modelBuilder.Entity<Patient>()
            .HasOne(ct => ct.CancerType)
            .WithOne(p => p.Patient)
            .HasForeignKey<CancerType>(p => p.CancerId);

            modelBuilder.Entity<PatientAreaofInterest>()
                .HasKey(pa => new { pa.UserId, pa.AreaId });

            modelBuilder.Entity<DoctorAreaofInterest>()
                .HasKey(da => new { da.UserId, da.AreaId });

        }
    }
}