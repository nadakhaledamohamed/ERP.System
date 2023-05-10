

namespace DominCore.Entity
{
    public class Employee:BaseEntity
    {
        [StringLength(150)]
        public string EmployeeName { get; set; } = string.Empty;

        public int DepartmentId { get; set; }
        [ForeignKey(nameof(DepartmentId))]
        public  Department? Department { get; set; }
    }
}
