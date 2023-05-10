

namespace DominCore.Entity
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool CurrentState { get; set; }
        public DateTime CreatedOn { get; set; }
        [StringLength(100)]
        public string CreatedUserId { get; set; }=string.Empty;
        public DateTime UpdatedOn { get; set; }
        [StringLength(100)]
        public string UpdatedUserId { get; set; } = string.Empty;
        public DateTime DeletedOn { get; set; }
        [StringLength(100)]
        public string DeletedUserId { get; set; } = string.Empty;

        public int BranchId { get; set; }
        [ForeignKey("BranchId")]

        public Branch? Branch { get; set; }

    }
    }

