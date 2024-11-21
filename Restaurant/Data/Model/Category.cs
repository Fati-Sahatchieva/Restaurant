using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Data.Model
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Име")]
        [MaxLength(64)]
        public string Name { get; set; }


    }
}
