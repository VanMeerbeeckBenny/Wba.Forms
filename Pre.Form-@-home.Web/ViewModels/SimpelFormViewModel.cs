using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pre.Form___home.Web.ViewModels
{
    public class SimpelFormViewModel
    {
        [Required(ErrorMessage = "Gelieve {0} in te vullen")]
        [Display(Name = "Voornaam")]
        [MaxLength(50,ErrorMessage ="{0} mag nier langer zijn dan {1}")]
        [MinLength(2,ErrorMessage ="{0} moet groter zijn dan {1} charakters")]
        public string FirstName { get; set; }
        [Required(ErrorMessage ="Gelieve {0} in te vullen")]
        [Display(Name = "Achternaam")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Gelieve {0} in te vullen")]
        [EmailAddress(ErrorMessage = "Gelieve een geldig {0} mee te geven")]
        [Display(Name ="E-mail")]
        public string Email { get; set; }
        [Display(Name ="Subscribe me")]
        public bool Subscribed { get; set; }
        
        public SimpleSelectVm SelectItem { get; set; }
    }
}
