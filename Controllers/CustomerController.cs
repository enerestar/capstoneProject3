using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using febcustomerapp.Models;
using System.ComponentModel.DataAnnotations;
using febcustomerapp.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace febcustomerapp.Controllers
{
    [EnableCors("MyPolicy")]
    public class CustomerController : Controller
    {

        int i = 0;
        public IActionResult AddScreen()
        {
            // set session in view tracking
            // configure session in startup.cs
            if(HttpContext.Session.GetInt32("variablei") != null)
            {
                i = (int)HttpContext.Session.GetInt32("variablei");
            }
            i++;
            // send to browser to store in cookies
            HttpContext.Session.SetInt32("variablei", i);
            return View("CustomerAdd", new CustomerViewModel());
        }
        public IActionResult Search(string customerName) //execute search
        {
            //CustomerDBContext custDbContext = new CustomerDBContext();
            //List<Customer> custs = (from temp in custDbContext.Customers
            //where temp.customerName == customerName
            //    select temp).ToList<Customer>();
            //return View("DisplayCustomer", custs); //add to db

            return View("DisplayCustomer");
        }
        public IActionResult SearchScreen() //display search screen
        {
            return View("DisplayCustomer");
        }
        // GET: /<controller>/
        public IActionResult Add([FromBody] Customer obj)
        {
            // validation
            var context = new ValidationContext(obj, null, null);
            var errorRes = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(obj, context, errorRes, true);
            if (isValid)
            {
                //CustomerDBContext cust = new CustomerDBContext();
                //cust.Customers.Add(obj);
                //cust.SaveChanges();
                //List<Customer> custs = cust.Customers.ToList<Customer>();
                //return View("DisplayCustomer", custs); //add to db
                return View("DisplayCustomer"); //add to db
                //return StatusCode(StatusCodes.Status200OK, custs);
            }
            else
            {
                CustomerViewModel custvm = new CustomerViewModel();
                custvm.customer = obj;
                custvm.errors = errorRes;
                //return View("CustomerAdd", errorRes);
                return StatusCode(StatusCodes.Status500InternalServerError, errorRes);

            }
        }
    }
}
