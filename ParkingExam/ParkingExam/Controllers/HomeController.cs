using Microsoft.AspNetCore.Mvc;
using ParkingExam.Data;
using ParkingExam.Models;
using ParkingExam.Services;
using System;
using System.Diagnostics;

namespace ParkingExam.Controllers
{
    public class HomeController : Controller
    {
        private readonly IParkingService parkingService;

        public HomeController(IParkingService parkingService)
        {
            this.parkingService = parkingService;
        }

        public IActionResult Index()
        {
            return View(this.parkingService.GetCars());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Location()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddCar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveCar(Car car)
        {
            this.parkingService.AddCar(car);
            return RedirectToAction("Index");
        }

         public IActionResult GetCar(int id)
        {
            var car = this.parkingService.GetById(id);
            return View(car);
        }

        public IActionResult EditCar(Car carToEdit)
        {
            this.parkingService.EditCar(carToEdit);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteCar(int id)
        {
            this.parkingService.DeleteCar(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ContentResult AjaxMethod(string name)
        {
            string currentDateTime = string.Format("Hello {0}.\nCurrent DateTime: {1}", name, DateTime.Now.ToString());
            return Content(currentDateTime);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}