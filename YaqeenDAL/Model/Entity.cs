namespace YaqeenDAL.Model
{
    public class Entity
    {
        public int Id { get; set; }
        public bool Active { get; set; }
    }

    public class AuditableEntity : Entity
    {
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}