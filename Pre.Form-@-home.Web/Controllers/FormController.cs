using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pre.Form___home.Web.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Pre.Form___home.Web.Controllers
{
    public class FormController : Controller
    {
        SimpleSelectVm countrys = new SimpleSelectVm
        {
            SelectCountryId = 1,
            Countries = new List<SelectListItem>
                {
                    new SelectListItem{Value = "0", Text = "==Pick a Country=="},
                    new SelectListItem{Value = "1",Text ="Belgium"},
                    new SelectListItem{Value= "2",Text = "Nederland"},
                    new SelectListItem{Value = "3",Text="Duitsland"}
                }
        };
        public IActionResult Index()
        {
            SimpelFormViewModel simpelFormVm = new SimpelFormViewModel();
            simpelFormVm.SelectItem = countrys;
            simpelFormVm.Subscribed = true;
            return View(simpelFormVm);
        }
        [HttpPost]
        public IActionResult Index(SimpelFormViewModel simpelFormVm)
        {
            if (ModelState.IsValid)
            {
                var RecievedAnswersvm = new SimpelFormRecievedAnswersViewModel 
                { 
                    FirstName = simpelFormVm.FirstName,
                    LastName = simpelFormVm.LastName,
                    Country = countrys.Countries[simpelFormVm.SelectItem.SelectCountryId].Text,
                    Email = simpelFormVm.Email,
                    Password = simpelFormVm.Password,
                    Subscribed = simpelFormVm.Subscribed
                };
                return RedirectToAction("RecieveFormData", RecievedAnswersvm);
            }             
            else return View(simpelFormVm);
        }
       
        public IActionResult RecieveFormData(SimpelFormRecievedAnswersViewModel simpelFormVm)
        {
            return View(simpelFormVm);            
        }
    }
}
