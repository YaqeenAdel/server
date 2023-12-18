using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Npgsql;

namespace YaqeenDAL.Model
{
    public class YaqeenDbContextFactory : IDesignTimeDbContextFactory<YaqeenDbContext>
    {
        public static string ConvertToEfString(string postgresConnectionString)
        {
            if (postgresConnectionString == null) {
                return "";
            }

            // Split the PostgreSQL connection string into its individual components.
            var postgresConnectionStringComponents = postgresConnectionString.Split(':', '/', '@');

            // Create a new EF string.
            var efString = new StringBuilder();

            // Add the host component to the EF string.
            efString.Append($"Host={postgresConnectionStringComponents[5]};");

            // Add the username component to the EF string.
            efString.Append($"Username={postgresConnectionStringComponents[3]};");

            // Add the password component to the EF string.
            efString.Append($"Password={postgresConnectionStringComponents[4]};");

            // Add the database component to the EF string.
            efString.Append($"Database={postgresConnectionStringComponents[6]};");

            return efString.ToString();
        }
        
        public YaqeenDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<YaqeenDbContext>();
            string connectionString = Environment.GetEnvironmentVariable("NEON_CONNECTION_STRING");
            optionsBuilder.UseNpgsql(ConvertToEfString(connectionString));

            // Call UseNodaTime() when building your data source:
            // var dataSourceBuilder = new NpgsqlDataSourceBuilder(ConvertToEfString(connectionString));
            // dataSourceBuilder.MapEnum<VerificationStatus>();
            // var dataSource = dataSourceBuilder.Build();

            // builder.Services.AddDbContext<YaqeenDbContext>(options => options.UseNpgsql(dataSource));

            NpgsqlConnection.GlobalTypeMapper.MapEnum<VerificationStatus>();
            NpgsqlConnection.GlobalTypeMapper.MapEnum<UserType>();
            NpgsqlConnection.GlobalTypeMapper.MapEnum<Phase>();
            NpgsqlConnection.GlobalTypeMapper.MapEnum<Visibility>();
            NpgsqlConnection.GlobalTypeMapper.MapEnum<ContentType>();
            return new YaqeenDbContext(optionsBuilder.Options);
        }
    }

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
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Bookmark> Bookmarks { get; set; }
        public DbSet<Photo> Photos { get; set;}
        public DbSet<Country> Countries { get; set; }
        public DbSet<CountryState> CountryStates { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<Content> Contents { get; set; }
     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the primary keys
            // modelBuilder.Entity<User>().HasKey(u => u.Id);
            // modelBuilder.Entity<Patient>().HasKey(p => p.Id);
            // modelBuilder.Entity<Doctor>().HasKey(d => d.Id);
            // modelBuilder.Entity<CancerStage>().HasKey(d => d.StageId);
            // modelBuilder.Entity<CancerType>().HasKey(d => d.CancerId);
            // modelBuilder.Entity<AreaofInterest>().HasKey(d => d.AreaId);

            // modelBuilder.Entity<Question>().HasKey(q => q.Id);
            // modelBuilder.Entity<Answer>().HasKey(a => a.AnswerId);
            // modelBuilder.Entity<Article>().HasKey(a => a.ArticleId);
            // modelBuilder.Entity<Bookmark>().HasKey(b => b.BookmarkId);

            // Define relationships
            // modelBuilder.Entity<User>()
            //     .HasOne(u => u.Patient)
            //     .WithOne(p => p.User)
            //     .HasForeignKey<Patient>(p => p.UserId);

            // modelBuilder.Entity<User>()
            //     .HasOne(u => u.Doctor)
            //     .WithOne(d => d.User)
            //     .HasForeignKey<Doctor>(d => d.UserId);

            // modelBuilder.Entity<Patient>()
            //     .HasMany(p => p.Questions)
            //     .WithOne(q => q.Patient)
            //     .HasForeignKey(q => q.PatientId);

            // modelBuilder.Entity<Patient>()
            //     .HasMany(p => p.Bookmarks)
            //     .WithOne(b => b.Patient)
            //     .HasForeignKey(b => b.UserId);

            // modelBuilder.Entity<Doctor>()
            //     .HasMany(d => d.Answers)
            //     .WithOne(a => a.Doctor)
            //     .HasForeignKey(a => a.DoctorId);

            // modelBuilder.Entity<Doctor>()
            //     .HasMany(d => d.Bookmarks)
            //     .WithOne(b => b.Doctor)
            //     .HasForeignKey(b => b.UserId);

            // modelBuilder.Entity<Question>()
            //     .HasMany(q => q.Answers)
            //     .WithOne(a => a.Question)
            //     .HasForeignKey(a => a.QuestionId);

            // modelBuilder.Entity<Article>()
            //     .HasMany(a => a.Bookmarks)
            //     .WithOne(b => b.Article)
            //     .HasForeignKey(b => b.ArticleId);

            // modelBuilder.Entity<User>()
            //     .HasMany(u => u.VerificationCodes)
            //     .WithOne(v => v.User)
            //     .HasForeignKey(v => v.UserId);

            // modelBuilder.Entity<Patient>()
            // .HasOne(cs => cs.CancerStage)
            // .WithOne(p => p.Patient)
            // .HasForeignKey<CancerStage>(p => p.StageId)
            //  .IsRequired(false);

            // modelBuilder.Entity<Patient>()
            // .HasOne(ct => ct.CancerType)
            // .WithOne(p => p.Patient)
            // .HasForeignKey<CancerType>(p => p.CancerId);

            // modelBuilder.Entity<PatientAreaofInterest>()
            //     .HasKey(pa => new { pa.UserId, pa.AreaId });

            // modelBuilder.Entity<DoctorAreaofInterest>()
            //     .HasKey(da => new { da.UserId, da.AreaId });

            // modelBuilder.Entity<Doctor>()
            //    .OwnsOne(r => r.VerificationStatus);
            modelBuilder.HasPostgresEnum<VerificationStatus>();
            modelBuilder.HasPostgresEnum<UserType>();
            // modelBuilder.Entity<Doctor>()  
            //     .Property(b => b.VerificationStatus)
            //     .HasDefaultValue(VerificationStatus.Approved); 
        }
    }
}
