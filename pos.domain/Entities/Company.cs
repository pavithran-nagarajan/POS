
namespace pos.domain.Entities
{
    public class Company
    {
        public int CompanyId { get; set; }
        public Guid CompanyGuid { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
