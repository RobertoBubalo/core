using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public ViewResult Index()
        {
            var viewResult = View (_employeeRepository.GetAllEmployees ());
            return viewResult;
        }

        public ViewResult Details(int? id)
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel ()
            {
                Employee = _employeeRepository.GetEmployee (id??1),
                PageTitle = "Employee Details"
            };

            return View (homeDetailsViewModel);
        }


    }
}