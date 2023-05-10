

namespace DominCore.Entity
{
    public class Category:BaseEntity
    {
        [StringLength(250)]
        public string CategoryName { get; set; } = string.Empty;
        public string? CategoryImage { get; set; } = string.Empty;
        [StringLength(250)]
        public string? Description  { get; set; }
    }
}
