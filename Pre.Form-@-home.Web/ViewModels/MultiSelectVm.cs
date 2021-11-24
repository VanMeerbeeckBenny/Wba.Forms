using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pre.Form___home.Web.ViewModels
{
    public class MultiSelectVm
    {
        [Display(Name ="Select your favorite languages")]

        public IEnumerable<int> SelectedLanguagesIds { get; set; }

        public List<SelectListItem> Languages { get; set; }

    }
}
