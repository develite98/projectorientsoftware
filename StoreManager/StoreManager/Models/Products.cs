using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManager.Models
{
    public class Products
    {

        public int productID { get; set; }

        [Required(ErrorMessage = "Please enter name of product")]
        [MinLength(20, ErrorMessage ="Too short name")]
        public string productName { get; set; }

        public string productImage1 { get; set; }
        public string productImage2 { get; set; }

        [Required(ErrorMessage = "Please enter description for this product")]
        [MinLength(50, ErrorMessage ="Too short description")]
        public string productDescription { get; set; }

        [Required(ErrorMessage = "Please enter price")]
        public decimal productPrice { get; set; }

        public int productQuantity { get; set; }


    }
}
