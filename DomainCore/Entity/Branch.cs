

namespace DominCore.Entity
{
    public class Branch
    {
        public int Id { get; set; }

        [StringLength(250)]
        public string BranchName { get; set; } = string.Empty;

        [EmailAddress]
        public string Email { get; set; } = string.Empty;



        [StringLength(250)]
        public string Address { get; set; } = string.Empty;

        [StringLength(100)]
        public string PhoneNumber { get; set; } = string.Empty;
        
        public bool CurrentState { get; set; }
        public DateTime CreatedOn { get; set; }

        [StringLength(100)]
        public string? CreatedUserId { get; set; } = string.Empty;
        public DateTime UpdatedOn { get; set; }

        [StringLength(100)]
        public string? UpdatedUserId { get; set; } = string.Empty;
        public DateTime DeletedOn { get; set; }

        [StringLength(100)]
        public string? DeletedUserId { get; set; } = string.Empty;

        public int CompanyId { get; set; }

        [ForeignKey("CompanyId")]

        public Company? Company { get; set; }
    }
}
