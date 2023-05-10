

namespace DominCore.Entity
{
    public class Store:BaseEntity
    {
        [StringLength(250)]
        public string StoreName { get; set; } = string.Empty;

        [StringLength(100)]
        public string PhoneNumber { get; set; } = string.Empty;

        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [StringLength(250)]
        public string Address { get; set; }=string.Empty;
        public int AdministratorId { get; set; }
        [ForeignKey(nameof(AdministratorId))]
        public Employee? Employee { get; set; }

    }
}
