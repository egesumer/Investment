public abstract class BaseEntity
{
    public Guid Id { get; set; } 
    public bool IsDeleted { get; set; } = false;
    public DateTime CreationDate { get; set; }
    public DateTime? ModifiedDate { get; set; }

}