

namespace DominCore.Entity
{
    public class Unit:BaseEntity
    {
        [StringLength(150)]
        public string UnitName { get; set; } = string.Empty;
        public decimal QuantityUnit { get; set; }
    }
}
