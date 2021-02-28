using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Task_Manager.Data;
using Task_Manager.Models;
using Microsoft.AspNetCore.Identity;

namespace Task_Manager.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult TaskList()
        //{
        //    return View();
        //}

        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Create(TaskList job)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _taskDB.TaskList.Add(job);
        //        _taskDB.SaveChanges();
        //        return RedirectToAction("TaskList");
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
