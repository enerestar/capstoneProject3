using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using febcustomerapp.ViewModel;
using febcustomerapp.Models;
using febcustomerapp.DbContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace febcustomerapp.Controllers
{
    [Route("api/[controller]")]
    public class CustomerApiController : Controller
    {
        //CustomerDBContext db = null;

        public CustomerApiController(
            //CustomerDBContext _customerDBContext,
            IConfiguration configuration)
        {
            //customerDBContext = _customerDBContext;
            string conn = configuration["ConnString"];
        }

        // GET api/values
        public IActionResult Get()
        {
            ////search
            //List<Customer> custs = customerDBContext.Customers.ToList<Customer>();
            //return custs;

            List<Customer> custs = new List<Customer>();
            return StatusCode(StatusCodes.Status200OK, custs);
        }
        // GET: api/values/custname
        [HttpGet("{id}")]
        public IActionResult Get(string customerName)
        {
            // search with customer
            //List<Customer> custs = (from temp in customerDBContext.Customers
            //                        where temp.customerName == customerName
            //                        select temp).ToList<Customer>();
            //return custs;

            List<Customer> custs = new List<Customer>();
            return StatusCode(StatusCodes.Status200OK, custs);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Customer obj)
        {
            // validation
            var context = new ValidationContext(obj);
            var errorRes = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(obj, context, errorRes, true);
            if (isValid)
            {
                //customerDBContext.Customers.Add(obj);
                //customerDBContext.SaveChanges();
                //List<Customer> custs = customerDBContext.Customers.ToList<Customer>();


                //List<Customer> custs = customerDBContext.Customers
                //                                        .Include(p => p.products)
                //                                       .ToList<Customer>();

                List<Customer> custs = new List<Customer>();
                return StatusCode(StatusCodes.Status200OK, custs);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, errorRes);

            }


        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //Customer cust = customerDBContext.Customer
            //    .Include(p => p.products)
            //    .FirstOrDefault(XmlConfigurationExtensions => XmlConfigurationExtensions.Id == id);

            //foreach (var product in cust.products)
            //{
            //    customerDBContext.Products.Remove(product);

            //}
            //customerDBContext.Customers.Remove(cust);
            //customerDBContext.SaveChanges();
        }
    }
}
