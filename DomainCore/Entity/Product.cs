

namespace DominCore.Entity
{
    public class Product:BaseEntity
    {
        [StringLength(150)]
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }


        /// <summary>
        /// 3 relations between product and classses 
        /// </summary>
        //three relation ship between brand category AND unit
        public int BrandID { get; set; }
        [ForeignKey("BradId")]
        public Branch? Brand { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }


        public int UnitId { get; set; }
        [ForeignKey("UnitId")]
        public Unit? Unit { get; set; }
    }
}
