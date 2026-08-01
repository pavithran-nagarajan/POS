
namespace pos.application.DTOs.Company
{
    public class ResponseCompanyDTO
    {
        public Guid CompanyGuid { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public int CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
    }
}
