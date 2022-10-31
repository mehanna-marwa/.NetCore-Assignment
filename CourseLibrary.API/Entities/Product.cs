using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Products.API.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        public string ImgURL { get; set; }

        [Required]
        [MaxLength(50)]
        public int CateogryID { get; set; }

        [ForeignKey(nameof(CateogryID))]
        public virtual Category Category { get; set; } = null!;

    }
}
