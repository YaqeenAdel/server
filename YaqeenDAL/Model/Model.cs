using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Core;
using System.ComponentModel.DataAnnotations;

namespace YaqeenDAL.Model
{
    public class User : Entity
    {
        [Key]
        public int UserId { get; set; } // This attribute will contains required informations came from Auth0  
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        [Index(IsUnique = true)]
        public string? MobileNumber { get; set; }

        [Required]
        [Index(IsUnique = true)]
        public string Email { get; set; }
        public bool AgreedTerms { get; set; }
        public string? Gender { get; set; }
        public bool IsEmailVerified { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }

        // Navigation Properties
        [ForeignKey("UserId")]
        public virtual Patient Patient { get; set; }
        [ForeignKey("UserId")]
        public virtual Doctor Doctor { get; set; }
        public virtual ICollection<AreaofInterest> AreaofInterests { get; set; }
    }

    public class Patient : Entity
    {
        [Key]
        public int UserId { get; set; }
        public int AgeGroup { get; set; }

        public int CancerTypeId { get; set; }

        [ForeignKey("CancerStage")]
        public int CancerStageId { get; set; }

        public ICollection<PatientAreaofInterest> AreaofInterests { get; set; }
        public ICollection<Question> Questions { get; set; }
        public ICollection<Bookmark> Bookmarks { get; set; }

        // Navigation Property
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        [ForeignKey("CancerId")]
        public virtual CancerType? CancerType { get; set; }
        [ForeignKey("StageId")]
        public virtual CancerStage? CancerStage { get; set; }
    }

    public class Doctor : Entity
    {
        [Key]
        public int UserId { get; set; }
        public string University { get; set; }
        public string Degree { get; set; }
        public string MedicalField { get; set; }
        public VerificationStatus VerificationStatus { get; set; }
        
        // Navigation Property
        [ForeignKey("AnswerId")]
        public virtual ICollection<Answer> Answers { get; set; }
        [ForeignKey("BookmarkId")]
        public virtual ICollection<Bookmark> Bookmarks { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }

    public class CancerType : AuditableEntity
    {
        [Key]
        public int CancerId { get; set; }
        public string CancerTypeName { get; set; }
    }

    public class CancerStage : AuditableEntity
    {
        [Key]
        public int StageId { get; set; }
        public string StageName { get; set; }
    }

    public class AreaofInterest : AuditableEntity
    {
        [Key]
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public string Logo { get; set; }

        [ForeignKey("UserId")]
        public virtual ICollection<User> Users { get; set; }
    }

    public class Question : AuditableEntity
    {
        [Key]
        public int QuestionId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        
        // Navigation Property
        public virtual ICollection<Answer> Answers { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }

    public class Answer : AuditableEntity
    {
        [Key]
        public int AnswerId { get; set; }
        public int DoctorId { get; set; }
        public int QuestionId { get; set; }
        public string Content { get; set; }

        // Navigation Properties
        [ForeignKey("DoctorId")]
        public virtual Doctor Doctor { get; set; }
        public virtual Question Question { get; set; }
    }

    public class Article : AuditableEntity
    {
        [Key]
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Category { get; set; }
        public virtual ICollection<Bookmark> Bookmarks { get; set; }
    }

    public class Bookmark : AuditableEntity
    {
        [Key]
        public int BookmarkId { get; set; }
        public int UserId { get; set; }
        public int? ArticleId { get; set; }
        public string Type { get; set; } // Can be "Question" or "Article"

        // Navigation Properties
        [ForeignKey("UserId")]
        public virtual Patient Patient { get; set; }
        [ForeignKey("UserId")]
        public virtual Doctor Doctor { get; set; }
        public virtual Article Article { get; set; }
    }

    public class VerificationStatus 
    {
        public int VerifierUserId { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
        public string Notes { get; set; }

        [ForeignKey("VerifierUserId")]
        public virtual User Verifier { get; set; }
    }
}