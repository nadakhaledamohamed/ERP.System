

namespace DominCore.Entity
{
    public class Department:BaseEntity
    {
        [StringLength(150)]
        public string DepartmentName { get; set; } = string.Empty;
        
    }
}
