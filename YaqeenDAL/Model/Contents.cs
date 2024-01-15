using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YaqeenDAL.Model
{
    // Deprecated
    public enum ContentType
    {
        Category,
        Question,
        Answer,
        BloodDonation,
    }

    public enum Phase
    {
        Draft,
        Published,
    }

    public enum Visibility
    {
        Public,
        Private,
    }

    public class Attachment
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }

    [Index(nameof(Tags), IsUnique = false)]
    [Index(nameof(AuthorUserId), IsUnique = false)]
    [Index(nameof(AssignedTo), IsUnique = false)]
    [Index(nameof(ParentContentId), IsUnique = false)]
    [Index(nameof(Type), IsUnique = false)]
    public class Content : Entity
    {
        [Key]
        public int ContentId { get; set; }
        public int? ParentContentId { get; set; }
        public ContentType Type { get; set; }
        [Column(TypeName = "jsonb")]
        public Dictionary<string, string> Raw { get; set; }
        public string AuthorUserId { get; set; }
        public int? AssignedTo { get; set; }
        public Phase Phase { get; set; }
        [Column(TypeName = "jsonb")]
        public Dictionary<string, string> Tags { get; set; }
        public Visibility Visibility { get; set; }
        [Column(TypeName = "jsonb")]
        public Attachment Attachments { get; set; }

        [ForeignKey(nameof(AuthorUserId))]
        public virtual User Author { get; set; }

        [ForeignKey(nameof(ParentContentId))]
        public virtual Content? ParentContent { get; set; }
        public int? TranslationId { get; set; }

        public virtual Bookmark? Bookmark { get; set; }
        public virtual ICollection<Interest> Interests { get; set; }
    }
}