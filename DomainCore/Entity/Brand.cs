

namespace DominCore.Entity
{
    public class Brand:BaseEntity
    {
        [StringLength(250)]
        public string BrandName { get; set; } = string.Empty;
        public string? BrandImage { get; set; } = string.Empty;
        
    }
}
