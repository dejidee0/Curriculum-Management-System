namespace CMS.DATA.Entities
{
    public class Stack : BaseEntity
    {
        public string? StackName { get; set; }
        public ICollection<UserStack> User { get; set; }
    }
}