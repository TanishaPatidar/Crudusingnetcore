using crudinnetcore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace crudinnetcore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public static List<Employee> datalist = new List<Employee>();
        public static int count = 0;

        public class RequestData
        {
            public Employee save { get; set; }
            public int mid { get; set; }
        }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Create(Employee emp)
        {
            if (ModelState.IsValid)
            {
                count = count + 1;
                emp.id = count;
                if (emp.image != null)
                {
                    emp.image = Path.GetFileName(emp.image);
                }
                datalist.Add(emp);

            }
           
            // return Json(datalist);

            if (emp.dob != null)
                emp.dobStr = emp.dob.ToString("dd-MM-yyyy");

            return Json(emp);
        }


        public JsonResult Delete(int id)
        {
            var std = datalist.FirstOrDefault(e => e.id == id);
            if (std != null)
            {
                datalist.Remove(std);
            }

            //return Json(datalist);
            return Json(std);
        }


        public IActionResult Edit(int id)
        {

            if (ModelState.IsValid)
            {
                var std = datalist.FirstOrDefault(e => e.id == id);

                if (std != null)
                {
                    if (std.dob != null)
                       std.dobStr = std.dob.ToString("yyyy-MM-dd");

                    //      std.dobStr = std.dob.ToString("dd-MM-yyyy");
                   
                }
                return Json(std);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult Edittable(RequestData requestData)
        {

            Employee em = requestData.save;
            int meid = requestData.mid;
            em.id = meid;
            if (ModelState.IsValid)
            {
                var std = datalist.FirstOrDefault(e => e.id == meid);
                if (em.image != null)
                {
                    em.image = Path.GetFileName(em.image);
                }
                if (std != null)
                {
                  
                    datalist.Remove(std);
                    datalist.Add(em);

                  
                }
               
                if (em.dob != null)
                    em.dobStr = em.dob.ToString("dd-MM-yyyy");
                
                return Json(em);
            }
            return Json(null);

        }
        public JsonResult DataShow()
        {
            return Json(datalist);
        }










    }
}
