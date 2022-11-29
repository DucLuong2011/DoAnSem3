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
        public IActionResult Recharge_bill_datacard(float price, int nspId)
        {
            //var values = _context.values.ToList();
            //var networks = _context.networkServiceProviders.ToList();
            //if (price != 0 && nspId != 0)
            //{
            //    values = _context.values.Where(v => v.price.Equals(price)).Where(v => v.nspId.Equals(nspId))
            //                            .OrderBy(v => v.valueId).ToList();
            //}
            //else if (nspId != 0)
            //{
            //    values = _context.values.Where(v => v.nspId.Equals(nspId))
            //                            .OrderBy(v => v.valueId).ToList();
            //}
            //else if (price != 0)
            //{
            //    values = _context.values.Where(v => v.price.Equals(price))
            //                           .OrderBy(v => v.valueId).ToList();
            //}

            //ViewBag.Values = values;
            //ViewBag.Networks = networks;
            return View();
        }
        //đăng kí dịch vụ không làm phiền
        public IActionResult Recharge_bill_donotdisturb()
        {
            return View();
        }


        public IActionResult Recharge_plans(float price, int nspId)
        {

            //var values = _context.values.ToList();
            //var services = _context.services.ToList();
            //var networks = _context.networkServiceProviders.ToList();
            //if (price != 0 && nspId != 0)
            //{
            //    values = _context.values.Where(v => v.price.Equals(price)).Where(v => v.nspId.Equals(nspId))
            //                            .OrderBy(v => v.valueId).ToList();
            //}
            //else if (nspId != 0)
            //{
            //    values = _context.values.Where(v => v.nspId.Equals(nspId))
            //                            .OrderBy(v => v.valueId).ToList();
            //}
            //else if (price != 0)
            //{
            //    values = _context.values.Where(v => v.price.Equals(price))
            //                           .OrderBy(v => v.valueId).ToList();
            //}

            //ViewBag.Values = values;
            //ViewBag.Networks = networks;
            return View();
        }
    }
}