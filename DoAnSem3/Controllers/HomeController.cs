using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DoAnSem3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;
using System.Text;

namespace DoAnSem3.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private List<Customer> cus = new List<Customer>();
        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //var Index = _context.customers.Where(x => x.customerId == HttpContext.Session.GetInt32("LoginCustomerId")).FirstOrDefault();

            //if (Index == null)
            //{
            //    return NotFound();
            //}
            //return View(Index);

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult FreeBack()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FreeBack([Bind("Id,name,email,phone,note")] FreeBack freeBack)
        {
            if (ModelState.IsValid)
            {
                _context.Add(freeBack);
                await _context.SaveChangesAsync();
                ViewBag.success = "Send successfully";
                return RedirectToAction(nameof(FreeBack));
                
            }
            return View(freeBack);
        }

        //Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost] // POST khi submit form
        public IActionResult Login(LoginCustomer model , string password)
        {
            if (!ModelState.IsValid)
            {
                return View(model); // trả về trạng thái lỗi
            }
            else
            {
                var f_password = GetMD5(password);
                // sẽ xử lý logic phần đăng nhập tại đây
                // using Microsoft.AspNetCore.Http;
                var checkAccount = _context.customers.FirstOrDefault(a => a.email == model.email && a.password.Equals(f_password) && a.role == 0);

                if (checkAccount != null)
                {

                    HttpContext.Session.SetString("LoginCustomer", checkAccount.customerName);
                    HttpContext.Session.SetInt32("LoginCustomerId", checkAccount.customerId);
                    return RedirectToAction("Index");

                }
                else
                {
                    ModelState.AddModelError("", "Email account or password is incorrect");
                }
                //return View(model);
            }

            return View();
        }
        //logout
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("LoginCustomer"); // Hủy session với key AdminLogin đã lưu trước đó
            //return RedirectToAction();
            return Redirect("https://localhost:44332/");
        }

        //create
        [HttpGet]
        public IActionResult Regester()
        {
            var phone = _context.networkServiceProviders.ToList();
            ViewBag.PhoneNSP = phone;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Regester([Bind("customerId,customerName,email,phone,phoneNsp,password,totalPrice,status,role")] Customer customer)
        {
            customer.totalPrice = 0;
            if (ModelState.IsValid)
            {
                var check = _context.customers.FirstOrDefault(s => s.email == customer.email);
                if (check == null)
                {
                    customer.password = GetMD5(customer.password);
                    _context.customers.Add(customer);
                    _context.SaveChanges();
                    ViewBag.success = "Sign up successfully";
                    return RedirectToAction(nameof(Login));
                }
                else
                {
                    ViewBag.error = "Email already exists";
                    return View();
                }


            }
            else
            {
                return View(customer);
            }
            //return RedirectToAction("Regester");
        }
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }

    


        // Detai customer

        public IActionResult MyProfile()    
        {
            var User = _context.customers.Where(x => x.customerId == HttpContext.Session.GetInt32("LoginCustomerId")).FirstOrDefault();

            if (User == null)
            {
                return NotFound();
            }
            return View(User);
        }

        public IActionResult OrdersHistory()
        {
        //    var History = _context.orders.Where(x => x.cusId == HttpContext.Session.GetInt32("LoginCustomerId")).FirstOrDefault();

        //    if (History == null)
        //    {
        //        return NotFound();
        //    }
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
