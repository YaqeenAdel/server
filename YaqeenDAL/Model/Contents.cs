using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YaqeenDAL.Model
{
    public enum ContentType {
        Category,
        Question,
        Answer,
    }

    public enum Phase {
        Draft,
        Published,
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
        [Timestamp]
        public byte[] CreatedAt { get; set; }
        [Timestamp]
        public byte[]? UpdatedAt { get; set; }
        [Timestamp]
        public byte[]? DeletedAt { get; set; }
        [Column(TypeName = "jsonb")]
        public Dictionary<string, string> Raw { get; set; }
        public string AuthorUserId { get; set; }
        public int? AssignedTo { get; set; }
        public Phase Phase { get; set; }
        public string[] Tags { get; set; }

        [ForeignKey(nameof(AuthorUserId))]
        public virtual User Author { get; set; }

        [ForeignKey(nameof(ParentContentId))]
        public virtual Content? ParentContent { get; set; }
    }
}