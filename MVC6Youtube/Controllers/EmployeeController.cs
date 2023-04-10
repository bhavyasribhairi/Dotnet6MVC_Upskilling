using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC6Youtube.Data;
using MVC6Youtube.Models;
using MVC6Youtube.ViewModel;

namespace MVC6Youtube.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly MVC6YoutubeDbContext _mvc6YoutubeDbContext;
        public EmployeeController(MVC6YoutubeDbContext mVC6YoutubeDbContext)
        {
            _mvc6YoutubeDbContext = mVC6YoutubeDbContext;

        }

        public MVC6YoutubeDbContext MVC6YoutubeDbContext { get; }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {

            Employee employee = await _mvc6YoutubeDbContext.Employees.FirstOrDefaultAsync
                 (Eid => Eid.EmployeeId == id);
            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(AddEmployeeViewModel employeeViewModel)
        {

            var config = new MapperConfiguration(item =>
            item.CreateMap<AddEmployeeViewModel, Employee>());
            var mapper = new Mapper(config);
            Employee employee = mapper.Map<AddEmployeeViewModel, Employee>(employeeViewModel);
            _mvc6YoutubeDbContext.Employees.Update(employee);
            _mvc6YoutubeDbContext.SaveChanges();
            return RedirectToAction("Details");

            //var viewModel = new Employee()
            //{
            //    EmployeeId = employeeViewModel.EmployeeId,
            //    EmployeeName = employeeViewModel.EmployeeName,
            //    EmployeeAge = employeeViewModel.EmployeeAge,
            //    Phone= employeeViewModel.Phone,
            //    Designation = employeeViewModel.Designation,

            //};
            //_mvc6YoutubeDbContext.Employees.Update(viewModel);
            //_mvc6YoutubeDbContext.SaveChanges();

        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddEmployeeViewModel employeeViewModel)
        {

            Employee employee = new Employee()
            {
                EmployeeId = Guid.NewGuid(),
                EmployeeAge = employeeViewModel.EmployeeAge,
                EmployeeName = employeeViewModel.EmployeeName,
                Designation = employeeViewModel.Designation,
                Phone = employeeViewModel.Phone

            };
            _mvc6YoutubeDbContext.Employees.Add(employee);
            _mvc6YoutubeDbContext.SaveChanges();


            return RedirectToAction("Details");
        }


        public IActionResult Details()
        {
            List<Employee> employees = _mvc6YoutubeDbContext.Employees.ToList();
            return View(employees);
        }


        public IActionResult Delete(Guid id)
        {
            Employee employee = _mvc6YoutubeDbContext.Employees.FirstOrDefault(eid => eid.EmployeeId == id);
            _mvc6YoutubeDbContext.Employees.Remove(employee);
            _mvc6YoutubeDbContext.SaveChanges();
            return RedirectToAction("Details", employee);
        }





    }
}
