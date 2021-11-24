using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pre.Form___home.Web.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Pre.Form___home.Web.Controllers
{
    public class SelectController : Controller
    {
        public IActionResult Index()
        {
            AllSelectsVm selectsVm = new AllSelectsVm();
            var optGroup = new List<SelectListGroup>
            {
                new SelectListGroup{Name = "Europe"},
                new SelectListGroup{Name = "Asia"},
                new SelectListGroup{Name="Afrika"}
            };

            selectsVm.GroupSelect = new SimpleSelectVm
            {
                SelectCountryId = 1,
                Countries = new List<SelectListItem>
                {
                    new SelectListItem{Value = "0" , Text = "<== Select a country ==>"},
                    new SelectListItem{Value = "1", Text = "Belgium",Group = optGroup[0]},
                    new SelectListItem{Value = "2", Text = "Germany",Group = optGroup[0]},
                    new SelectListItem{Value = "2", Text = "Italy",Group = optGroup[0]},
                    new SelectListItem{Value = "2", Text = "Spain",Group = optGroup[0]},
                    new SelectListItem{Value = "2", Text = "India",Group = optGroup[1]},
                    new SelectListItem{Value = "2", Text = "China",Group = optGroup[1]},
                    new SelectListItem{Value = "2", Text = "North-Korea",Group = optGroup[1]},
                    new SelectListItem{Value = "2", Text = "Niger",Group = optGroup[2]},
                    new SelectListItem{Value = "2", Text = "Sudan",Group = optGroup[2]},
                    new SelectListItem{Value = "2", Text = "Algeria",Group = optGroup[2]},
                    new SelectListItem{Value = "2", Text = "Kenya",Group = optGroup[2]}
                }
            };

            selectsVm.SimpleSelect = new SimpleSelectVm
            {
                SelectCountryId = 1,
                Countries = new List<SelectListItem>
                {
                    new SelectListItem{Value = "0" , Text = "<== Select a country ==>"},
                    new SelectListItem{Value = "1", Text = "Belgium"},
                    new SelectListItem{Value = "2", Text = "Germany"},
                    new SelectListItem{Value = "2", Text = "Italy"},
                    new SelectListItem{Value = "2", Text = "Spain"}               
                }
            };

            selectsVm.MultiSelect = new MultiSelectVm
            {
                SelectedLanguagesIds = new List<int> { 1, 3 },
                Languages = new List<SelectListItem>
                {
                    new SelectListItem {Value ="0" ,Text ="<==Select several Languages==>" },
                    new SelectListItem {Value ="1" ,Text ="c#" },
                    new SelectListItem {Value ="2" ,Text ="c++" },
                    new SelectListItem {Value ="3" ,Text ="JS" },
                    new SelectListItem {Value ="4" ,Text ="PHP" },
                    new SelectListItem {Value ="5" ,Text ="MS-SQL" }
                }
            };

            return View(selectsVm);
        }
    }
}
