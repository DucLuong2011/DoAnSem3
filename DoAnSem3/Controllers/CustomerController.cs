using DoAnSem3.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;


namespace DoAnSem3.Controllers
{
    public class CustomerController : Controller
    {
        private readonly AppDbContext _context;
        public CustomerController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Orders(string name,float price , string Phone , string description , int svId, int cusId)
        {
            //Order order = new Order()
            //{
            //    name = name,
            //    price = price,
            //    numberPhone = Phone,
            //    description = description,
            //    svId = svId,
            //    cusId = cusId,
            //    status = true
            //};
            //_context.Add(order);
            //_context.SaveChanges();
            //ViewBag.Order = order;
            return View();
        }
             

        public IActionResult Payment(int id, string phoneNumber, int check)
        {
            Payment payment = new Payment();
            Random r = new Random();
            int num = r.Next();
            
            //if (check == 0)
            //{
                var callTuner = _context.products.Find(id);
                var sv = _context.services.Find(callTuner.svId);
                var nsp = _context.networkServiceProviders.Find(callTuner.nspId);
                payment.TransactionId = num;
                payment.Name = callTuner.productName;
                payment.PhoneNumber = phoneNumber;
                payment.Description = callTuner.description;
                payment.Price = callTuner.price;
                payment.svName = sv.svName;
                payment.nspName = nsp.nspName;
                ViewBag.Payment = payment;
            //}
            //else
            //{
            //    var vl = _context.values.Find(id);
            //    payment.TransactionId = num;
            //    payment.Name = vl.valueName;
            //    payment.PhoneNumber = phoneNumber;
            //    payment.Description = vl.description;
            //    payment.Price = vl.price;
            //    ViewBag.Payment = payment;
            //}


            ViewBag.PhoneNumber = phoneNumber;
            ViewBag.Num = num;
            return View();
        }
    }
}