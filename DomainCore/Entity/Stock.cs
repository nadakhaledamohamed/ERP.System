

namespace DominCore.Entity
{
    public class Stock   ///mch m7tag n3mlo inheritance from base entity 3lshan product already by inherit 
    {
        public int StockId { get; set; }

        /// 
        ///relation ships between stock and other classes  
        /// 
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }

        public int StoreId { get; set; }
        [ForeignKey("StoreId")]
        public Store? Store { get; set; }

        public int Quantity { get; set; }






    }
}
