using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Data.Model
{
    public class Product
    {
        public int Id { get; set; }

        [Display(Name = "Снимка")]
        public string Image{ get; set; }
        
        [Required(ErrorMessage ="Попълнето полето с Име")]
        [Display(Name = "Име")]
        [StringLength(20)]
        public string Name { get; set; }
        [Required(ErrorMessage ="Попълнете полето с Описание")]
        [Display(Name = "Описание")]
        [StringLength(255)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Изберете категория" )]
        [Display(Name = "Категория")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [Required(ErrorMessage ="Попълнете полето с Цена")]
        [Display(Name = "Цена")]
        public decimal Price { get; set; }

    }
}

