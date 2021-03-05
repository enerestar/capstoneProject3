using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using febcustomerapp.Models;
using System.Linq;
using System.Threading.Tasks;

namespace febcustomerapp.ViewModel
{
    public class CustomerViewModel
    {
        public CustomerViewModel()
        {
            customer = new Customer();
            errors = new List<ValidationResult>();
        }

        public Customer customer { get; set; }
        public List<ValidationResult> errors { get; set; }
    }
}
