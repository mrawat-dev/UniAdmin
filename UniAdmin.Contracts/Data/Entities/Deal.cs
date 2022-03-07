namespace UniAdmin.Contracts.Data.Entities
{
    public class Deal : BaseEntity
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
    }
}