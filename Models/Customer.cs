using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using febcustomerapp.Models;

namespace febcustomerapp.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        public string customerName { get; set; }

        [Required]
        public string address { get; set; }

        public List<Product> products { get; set; }
    
    }
}

