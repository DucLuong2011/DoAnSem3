using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using DoAnSem3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;

namespace DoAnSem3.Controllers
{
    public class ServiceController : Controller
    {
        private readonly AppDbContext _context; 

        public ServiceController(AppDbContext context)
        {
            _context = context;
        }

        //Nạp tiền vào accout
        public IActionResult Recharge_bill_online_recharge()
        {
            return View();
        }

        // POST: Admin/Bankings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Recharge_bill_online_recharge([Bind("bankId,bankName,rechange,status,createAt,cusId")] Banking banking)
        {
            banking.status = false;
            if (ModelState.IsValid)
            {
                _context.Add(banking);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index","Home");
            }
            return View(banking);
        }


        //Đăng kí nhạc chờ
        public IActionResult Recharge_bill_calltunes(string name, float price1, float price2)
        {
            var callTuners = _context.products.Where(c => c.svId.Equals(1)).ToList();
            if (!String.IsNullOrEmpty(name))
            {
                callTuners = _context.products.Where(c => c.productName.Contains(name)).OrderBy(c => c.productName).ToList();
            }

            //if (price1 != 0 && price2 != 0)
            //{
            //    callTuners = _context.products.Where(c => c.price >= price1 && c.price <= price2).OrderBy(c => c.price).ToList();
            //}


            ViewBag.CallTuners = callTuners;
            return View();
        }
        //nạp thẻ điện thạoi
        public IActionResult Recharge_bill_datacard(string phone)
        {
            var cus = _context.customers.FirstOrDefault();
            var values = _context.products.Where(c => c.svId.Equals(4)).ToList();
            if (!string.IsNullOrEmpty(phone))
            {
                cus = _context.customers.Where(c => c.phone.Equals(phone)).FirstOrDefault();
                values = _context.products.Where(c => c.svId.Equals(4))
                                          .Where(c => c.nspId.Equals(cus.phoneNsp)).ToList();
                ViewBag.Phone = phone;
            }

            //if (price != 0)
            //{
            //    values = _context.products.Where(v => v.price.Equals(price)).Where(c => c.svId.Equals(4))
            //                            .OrderBy(v => v.productId).ToList();
            //}

            ViewBag.Customer = cus;
            ViewBag.Values = values;
            
            return View();
        }


    }
}