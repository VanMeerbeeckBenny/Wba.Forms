using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pre.Form___home.Core;
using Pre.Form___home.Web.Data;
using Pre.Form___home.Web.ViewModels;

namespace Pre.Form___home.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserContext _context;

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

        public UsersController(UserContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            UsersIndexViewModel users = new UsersIndexViewModel();
            
            foreach (var user in _context.users)
            {
                users.Users.Add(new SimpelFormRecievedAnswersViewModel
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Password = user.Password,
                    Email = user.Email,
                    Country = user.Country,
                    Subscribed = (bool)user.IsSubscribed
                });                      
            }
            return View(users);
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            SimpelFormViewModel simpelFormVm = new SimpelFormViewModel();
            simpelFormVm.SelectItem = countrys;
            simpelFormVm.Subscribed = true;
            return View(simpelFormVm);
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SimpelFormViewModel simpelFormVm)
        {
            User user = new User
            {
                FirstName = simpelFormVm.FirstName,
                LastName = simpelFormVm.LastName,
                Password = simpelFormVm.Password,
                Email = simpelFormVm.Email,
                Country = countrys.Countries[simpelFormVm.SelectItem.SelectCountryId].Text,
                IsSubscribed = simpelFormVm.Subscribed
            };
            
            if (ModelState.IsValid)
            {
                user.Id = Guid.NewGuid();
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            simpelFormVm.SelectItem.Countries = countrys.Countries; //als iets fout gaat komt de listbox leeg terug
                                                                    //daarom wordt deze terug gevuld alvoren terug te sturen
            return View(simpelFormVm);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.users.FindAsync(id);
            UserEditViewModel simpelFormVM = new()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,                
                Email = user.Email,
                SelectItem = countrys,
                Subscribed = (bool)user.IsSubscribed
            };

            simpelFormVM.SelectItem.SelectCountryId = countrys.Countries.FindIndex(x=> x.Text == user.Country);
            if (user == null)
            {
                return NotFound();
            }
            return View(simpelFormVM);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, UserEditViewModel UserEditVM)
        {
            if (id != UserEditVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                User foundUser = _context.users.Single(x => x.Id == UserEditVM.Id);
                string userPassword = foundUser.Password;
                _context.Entry(foundUser).State = EntityState.Detached;

                User user = new User
                {
                    Id = id,
                    FirstName = UserEditVM.FirstName,
                    LastName = UserEditVM.LastName,
                    Password = userPassword,
                    Email = UserEditVM.Email,
                    Country = countrys.Countries[UserEditVM.SelectItem.SelectCountryId].Text,
                    IsSubscribed = UserEditVM.Subscribed
                };
                
                
                try
                {                    
                    
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            UserEditViewModel simpelFormView = new UserEditViewModel
            {
               
                FirstName = UserEditVM.FirstName,
                LastName = UserEditVM.LastName,                
                Email = UserEditVM.Email,
                SelectItem = new SimpleSelectVm
                {
                    Countries = countrys.Countries,
                    SelectCountryId = UserEditVM.SelectItem.SelectCountryId
                },
                Subscribed = UserEditVM.Subscribed
            };
            return View(simpelFormView);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var user = await _context.users.FindAsync(id);
            _context.users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(Guid id)
        {
            return _context.users.Any(e => e.Id == id);
        }
    }
}
