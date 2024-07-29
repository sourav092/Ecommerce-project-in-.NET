using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecomm_Project_11.Model
{
    public class Product
    {
        public int Id { get; set; }
        [Required] 
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        [Range(1,1000)]
        public int ListPrice { get; set; }
        [Required]
        [Range (1,1000)]
        public int Price { get; set; }
        [Required]
        [Range (1,1000)]
        public int Price50 { get; set; }
        [Required]
        [Range (1,1000)]
        public int Price100 { get; set;}
        [Display(Name ="Image Url")]
        public string ImageUrl { get; set; }
        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public category category { get; set; }
        [Required]
        [Display(Name ="Cover Type")]
        public int CoverTypeId { get; set; }
        public CoverType CoverType { get; set; }

    }
}
