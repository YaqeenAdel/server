using System.ComponentModel.DataAnnotations.Schema;

namespace YaqeenDAL.Model
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public bool AgreedTerms { get; set; }
        public bool? Gender { get; set; }
        public string IdpUserIdentifier { get; set; }  // This attribute will contains required informations came from Auth0  
        public bool IsEmailVerified { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }


        public ICollection<VerificationCode> VerificationCodes { get; set; }

        // Navigation Properties
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
    }

    public class Patient : Entity
    {
        public int UserId { get; set; }
        public int AgeGroup { get; set; }

        public ICollection<PatientAreaofInterest> AreaofInterests { get; set; }
        public ICollection<Question> Questions { get; set; }
        public ICollection<Bookmark> Bookmarks { get; set; }

        // Navigation Property
        public User User { get; set; }
        public CancerType CancerType { get; set; }
        public CancerStage? CancerStage { get; set; }

    }

    public class Doctor : Entity
    {
        public int UserId { get; set; }
        public string University { get; set; }
        public string Degree { get; set; }
        public string MedicalField { get; set; }
        public bool IsVerified { get; set; }  //verfication as adoctor from his certifications 
        public ICollection<DoctorAreaofInterest> AreaofInterests { get; set; }
        public ICollection<Answer> Answers { get; set; }
        public ICollection<Bookmark> Bookmarks { get; set; }

        // Navigation Property
        public User User { get; set; }
    }

    public class CancerType : AuditableEntity
    {
        [ForeignKey("Patient")]

        public int CancerId { get; set; }

        public string CancerTypeName { get; set; }

        // Navigation Property
        public Patient Patient { get; set; }

    }
    public class CancerStage : AuditableEntity
    {

        public int StageId { get; set; }

        public string StageName { get; set; }

        // Navigation Property
        public Patient? Patient { get; set; }
    }

    public class AreaofInterest : AuditableEntity
    {
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public string Logo { get; set; }

        // Navigation Properties
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }

    }
    public class PatientAreaofInterest
    {
        public int UserId { get; set; }
        public Patient Patient { get; set; }

        public int AreaId { get; set; }

        // Navigation Property

        public AreaofInterest AreaofInterest { get; set; }
    }

    public class DoctorAreaofInterest
    {
        public int UserId { get; set; }
        public Doctor Doctor { get; set; }

        public int AreaId { get; set; }
        public AreaofInterest AreaofInterest { get; set; }
    }

    public class Question : AuditableEntity
    {
        public int PatientId { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public ICollection<Answer> Answers { get; set; }

        // Navigation Property
        public Patient Patient { get; set; }
    }

    public class Answer : AuditableEntity
    {
        public int AnswerId { get; set; }
        public int DoctorId { get; set; }
        public int QuestionId { get; set; }
        public string Content { get; set; }

        // Navigation Properties
        public Doctor Doctor { get; set; }
        public Question Question { get; set; }
    }

    public class Article : AuditableEntity
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Category { get; set; }
        public ICollection<Bookmark> Bookmarks { get; set; }
    }

    public class Bookmark : AuditableEntity
    {
        public int BookmarkId { get; set; }
        public int UserId { get; set; }
        public int? ArticleId { get; set; }
        public string Type { get; set; } // Can be "Question" or "Article"

        // Navigation Properties
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public Article Article { get; set; }
    }

    public class VerificationCode : Entity
    {
        public int UserId { get; set; }
        public string Code { get; set; }
        public DateTime ExpirationDate { get; set; }

        // Navigation Property
        public User User { get; set; }
    }

}