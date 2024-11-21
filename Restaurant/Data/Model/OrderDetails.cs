using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Restaurant.Data.Model
{
    public class OrderDetails
    {
        public int Id { get; set; }
        [Display(Name = "Поръчка")]
        public int OrderId { get; set; }
        [Display(Name = "Продукт")]
        public int ProductId { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }


        

    }
}
