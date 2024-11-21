using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Data.Model
{
    public class Order
    {
        public Order()
        {
            OrderDetails = new List<OrderDetails>();
        }
        [BindNever]
        public int OrderId { get; set; }
        [Display(Name = "Номер на поръчка")]
        public string OrderNo { get; set; }

        [Required(ErrorMessage = "Моля попълни полето с Име")]
        [Display(Name = "Име")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Моля попълни полето с Фамилия")]
        [Display(Name = "Фамилия")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Моля попълни полето с Адрес")]
        [StringLength(100)]
        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Моля попълни полето с Пощенски код")]
        [Display(Name = "Пощенски код")]
        [StringLength(10, MinimumLength = 4)]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Моля попълни полето с Град")]
        [Display(Name ="Град")]
        [StringLength(50)]
        public string City { get; set; }

        [Required(ErrorMessage = "Моля попълни полето с Област")]
        [Display(Name = "Област")]
        [StringLength(10)]
        public string State { get; set; }

        [Required(ErrorMessage = "Моля попълни полето Държава")]
        [Display(Name = "Държава")]
        [StringLength(50)]
        public string Country { get; set; }

        [Required(ErrorMessage = "Моля попълни полето с Телефон")]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Телефон")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Моля попълни полето с Имейл")]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public double OrderTotal { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderPlaced { get; set; }

        public virtual List<OrderDetails> OrderDetails { get; set; }
    }
}
