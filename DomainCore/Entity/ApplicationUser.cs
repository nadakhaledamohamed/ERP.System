

namespace DominCore.Entity
{
    public class ApplicationUser: IdentityUser
    {
        [StringLength(250)]
        public string FullName { get; set; } = "";
        public bool IsActive { get; set; }
        public int StateTypeUser { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }
        public string? ImageUser { get; set; }
        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]

        public Company? Company { get; set; }

        public int BranchId { get; set; }
        [ForeignKey("BranchId")]
        public Branch? Branch { get; set; }

    }
}
