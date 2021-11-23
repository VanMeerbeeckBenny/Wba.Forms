using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pre.Form___home.Web.ViewModels;

namespace Pre.Form___home.Web.Controllers
{
    public class FormController : Controller
    {
        public IActionResult Index()
        {
            SimpelFormViewModel simpelFormVm = new SimpelFormViewModel();
            simpelFormVm.Subscribed = true;
            return View(simpelFormVm);
        }
        [HttpPost]
        public IActionResult Index(SimpelFormViewModel simpelFormVm)
        {
            if (ModelState.IsValid) return RedirectToAction("RecieveFormData", simpelFormVm);
            else return View(simpelFormVm);
        }
       
        public IActionResult RecieveFormData(SimpelFormViewModel simpelFormVm)
        {
            return View(simpelFormVm);            
        }
    }
}
