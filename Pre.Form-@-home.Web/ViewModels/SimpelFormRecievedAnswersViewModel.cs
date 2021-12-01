using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pre.Form___home.Web.ViewModels
{
    public class SimpelFormRecievedAnswersViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }     
        public string LastName { get; set; }
        public string Email { get; set; }      
        public bool Subscribed { get; set; } 
        public string Country { get; set; }
        public string Password { get; set; }
    }
}
