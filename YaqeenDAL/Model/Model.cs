using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YaqeenDAL.Model
{
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(MobileNumber), IsUnique = true)]
    public class User : Entity
    {
        [Key]
        public string UserId { get; set; } // This attribute will contains required informations came from Auth0  
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string? MobileNumber { get; set; }

        [Required]
        public string Email { get; set; }
        public bool AgreedTerms { get; set; }
        public string? Gender { get; set; }
        public bool IsEmailVerified { get; set; }

        // // Navigation Properties
        // [ForeignKey("UserId")]
        // public virtual Patient Patient { get; set; }
        // [ForeignKey("UserId")]
        // public virtual Doctor Doctor { get; set; }
        public virtual ICollection<Interest> Interests { get; set; }
    }

    public class Patient : Entity
    {
        [Key]
        public string UserId { get; set; }
        public int AgeGroup { get; set; }

        public int CancerTypeId { get; set; }

        [ForeignKey("CancerStage")]
        public int CancerStageId { get; set; }

        public ICollection<Question> Questions { get; set; }
        public ICollection<Bookmark> Bookmarks { get; set; }

        // Navigation Property
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        [ForeignKey("CancerTypeId")]
        public virtual CancerType? CancerType { get; set; }
        [ForeignKey("CancerStageId")]
        public virtual CancerStage? CancerStage { get; set; }
    }

    public enum VerificationStatus {
        Pending,
        Approved,
        Rejected,
        MoreInfoNeeded
    }

    public class Doctor : Entity
    {
        [Key]
        public string UserId { get; set; }
        public string University { get; set; }
        public string Degree { get; set; }
        public string MedicalField { get; set; }
        public string[] CredentialsAttachments { get; set; }
        [Column(TypeName = "verification_status")]
        public VerificationStatus VerificationStatus { get; set; }
        
        [ForeignKey("UserId")]
        public virtual ICollection<VerificationStatusEvent>? VerificationStatusEvents { get; set; }
        
        // Navigation Property
        public virtual ICollection<Answer>? Answers { get; set; }
        public virtual ICollection<Bookmark>? Bookmarks { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }

    public class Question : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuestionId { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        
        // Navigation Property
        public virtual ICollection<Answer> Answers { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }

    public class Answer : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnswerId { get; set; }
        public string DoctorId { get; set; }
        public int QuestionId { get; set; }
        public string Content { get; set; }

        // Navigation Properties
        [ForeignKey("DoctorId")]
        public virtual Doctor Doctor { get; set; }
        public virtual Question Question { get; set; }
    }

    public class Article : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Category { get; set; }
        public virtual ICollection<Bookmark> Bookmarks { get; set; }
    }

    public class Bookmark : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookmarkId { get; set; }
        public string UserId { get; set; }
        public int? ArticleId { get; set; }
        public string Type { get; set; } // Can be "Question" or "Article"

        // Navigation Properties
        [ForeignKey("UserId")]
        public virtual Patient Patient { get; set; }
        [ForeignKey("UserId")]
        public virtual Doctor Doctor { get; set; }
        public virtual Article Article { get; set; }
    }

    public class VerificationStatusEvent : Entity
    {
        [Key]
        public string TargetDoctorUserId { get; set; }
        public string VerifierUserId { get; set; }
        public string Notes { get; set; }

        [ForeignKey("VerifierUserId")]
        public virtual User Verifier { get; set; }
        [ForeignKey("TargetDoctorUserId")]
        public virtual Doctor TargetDoctor { get; set; }
    }

    // Resources:

    public class Photo : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PhotoId { get; set; }
        public string PhotoURL { get; set; }
        public int Usage { get; set; } // 0: Welcome guide
    }

    public class CancerType : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CancerId { get; set; }
        public string CancerTypeName { get; set; }
        public string LogoURL { get; set; }

        public virtual ICollection<ResourceLocalization> Translations { get; set; }
    }

    public class CancerStage : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StageId { get; set; }
        public string StageName { get; set; }
        public string? LogoURL { get; set; }
        public virtual ICollection<ResourceLocalization> Translations { get; set; }
    }

    public enum UserType {
        Patient,
        Doctor
    }

    public class Interest : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InterestId { get; set; }
        public string Name { get; set; }
        public string LogoURL { get; set; }
        public UserType TargetUserType { get; set; }

        public virtual ICollection<ResourceLocalization> Translations { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }

    public class ResourceLocalization
    {
        [Key]
        public int TranslationId { get; set; }
        public string Language { get; set; }

        [Column(TypeName = "jsonb")]
        public Dictionary<string, string> Translation { get; set; }
    }
    
    public class Country : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CountryId { get; set; }
        public string Name { get; set; } 
        public string AlphaCode { get; set; }
    }
    
    //country state
    public class CountryState: Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CountryStateId { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public string StateCode { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
               
        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }
    }
    //university
    [Index(nameof(CountryCode))]
    [Index(nameof(CountryCode), nameof(StateCode))]
    public class University: Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UniversityId { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public string StateCode { get; set; } 
        public string StateName { get; set; } 
        public string UniversityName { get; set; } 
    }

}
