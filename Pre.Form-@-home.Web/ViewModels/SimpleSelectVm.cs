using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pre.Form___home.Web.ViewModels
{
    public class SimpleSelectVm
    {
        [Display(Name = "Pick a country")]
        public int SelectCountryId { get; set; }
        public List<SelectListItem> Countries { get; set; }
    }
}
