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

        public IActionResult Orders(int cusId)
        {
            var order = _context.orders.Include(o => o.Product).Where(o => o.customerId.Equals(cusId)).ToList();
            ViewBag.Order = order;
            return View();
        }


        public IActionResult Update_Orders(Payment payment, int cusId, int price)
        {
            Order order = new Order()
            {
                nameCustomer = payment.NameCustomer,
                nameService = payment.svName,
                numberPhone = payment.PhoneNumber,
                transactionId = payment.TransactionId,
                productId = payment.ProductId,
                customerId = cusId,
                status = true
            };
            _context.Add(order);

            var cus = _context.customers.Find(cusId);
            cus.totalPrice = cus.totalPrice - price;
            _context.Update(cus);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
            
        }
             

        public IActionResult Payment(int id, string phoneNumber, int check , int cusId)
        {
            Payment payment = new Payment();
            Random r = new Random();
            int num = r.Next();
            var cus = _context.customers.Where(c => c.phone.Contains(phoneNumber)).FirstOrDefault();

            if (check == 0)
            {
                var callTuner = _context.products.Find(id);
                var sv = _context.services.Find(callTuner.svId);
                var nsp = _context.networkServiceProviders.Find(callTuner.nspId);
                payment.TransactionId = num;
                payment.ProductId = id;
                payment.Name = callTuner.productName;
                payment.NameCustomer = cus.customerName;
                payment.PhoneNumber = phoneNumber;
                payment.Description = callTuner.description;
                payment.Price = callTuner.price;
                payment.svName = sv.svName;
                payment.nspName = nsp.nspName;
                ViewBag.Payment = payment;
            }
            else
            {
                var vl = _context.products.Find(id);
                var sv = _context.services.Find(vl.svId);
                var nsp = _context.networkServiceProviders.Find(vl.nspId);
                payment.TransactionId = num;
                payment.ProductId = id;
                payment.Name = vl.productName;
                payment.NameCustomer = cus.customerName;
                payment.PhoneNumber = phoneNumber;
                payment.Description = vl.description;
                payment.Price = vl.price;
                payment.svName = sv.svName;
                payment.nspName = nsp.nspName;
                ViewBag.Payment = payment;
            }


            ViewBag.PhoneNumber = phoneNumber;
            ViewBag.Num = num;
            return View();
        }
    }
}