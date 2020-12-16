using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PC03_Program.Data;
using PC03_Program.Models;

namespace PC03_Program.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly WebAppContext _context;
        private int year;
        private int month;

        public HomeController( WebAppContext context)
        {
            _context= context;
        }

        public IActionResult Index()
        {
            
           DateTime today = DateTime.Now;
           var expire = today.AddDays(-7);
            Console.WriteLine(expire);          
            //BETWEEN x => x.fecha == today AND x.fecha<= expire
           var productos = _context.Productos.Where(x => x.fecha >=expire && x.fecha<=today).ToList();


            return View(productos);
        }
        
        public IActionResult Producto()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Producto(Producto p)
        {
            if(ModelState.IsValid){
                 _context.Add(p);
                 _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(p);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
