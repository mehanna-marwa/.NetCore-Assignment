using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Products.API.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }


        

    }
}
