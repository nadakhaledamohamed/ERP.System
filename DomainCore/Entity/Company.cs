

namespace DominCore.Entity
{
    public class Company
    {
        public int Id { get; set; }

        [StringLength(250)]
        public string CompanyName { get; set; } = "";
        public string Activity { get; set; } = "";

        [StringLength(100)]
        public string TaxNumber { get; set; } = "";

        [StringLength(100)]
        public string PhoneNumber { get; set; } = "";
        [StringLength(100)]
        public string TelNumber { get; set; } = "";

        [EmailAddress]
        public string Email { get; set; } = "";
        public string Logo { get; set; } = "";

        [StringLength(250)]
        public string Address { get; set; } = "";
        public bool CurrentState { get; set; }
        public DateTime CreatedOn { get; set; }

        [StringLength(100)]
        public string? CreatedUserId { get; set; } = string.Empty;
        public DateTime UpdatedOn { get; set; }
        public string? UpdatedUserId { get; set; } = string.Empty;
        public DateTime DeletedOn { get; set; }

        [StringLength(100)]
        public string? DeletedUserId { get; set; } = string.Empty;

    }
}
