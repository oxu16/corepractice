using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using corepractice.Data;
using corepractice.Models;
using corepractice.ViewModels;
using corepractice.Utilities;

namespace corepractice.Controllers
{
    public class UsersController : Controller
    {
        private IUserRepository _userRepository;
        private ProcessPassword _processPassword;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _processPassword = new ProcessPassword();
        }

        public ViewResult Index()
        {
            var model = _userRepository.GetAllUser();
            return View(model);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,Username,Password,Firstname,Lastname,DateOfBirth,Email,Phone,Mobile,GroupIndex")] User user)
        {
            if (ModelState.IsValid)
            {
                user.Password = _processPassword.GetSaltedPasswordHashing(user.Password, 10);
                _userRepository.Add(user);
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _userRepository.GetUser((int)id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            User user = _userRepository.GetUser(id);
            UserEditViewModel userEditViewModel = new UserEditViewModel
            {
                UserId = user.UserId,
                Username = user.Username,
                Password = user.Password,
                DateOfBirth = user.DateOfBirth,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Email = user.Email,
                Phone = user.Phone,
                Mobile = user.Mobile,
                GroupIndex = user.GroupIndex
            };
            return View(userEditViewModel);
        }

        // Through model binding, the action method parameter
        // UserEditViewModel receives the posted edit form data
        [HttpPost]
        public IActionResult Edit(UserEditViewModel model)
        {
            // Check if the provided data is valid, if not rerender the edit view
            // so the user can correct and resubmit the edit form
            if (ModelState.IsValid)
            {
                // Retrieve the user being edited from the database
                User user = _userRepository.GetUser(model.UserId);
                // Update the user object with the data in the model object
                user.Password = _processPassword.GetSaltedPasswordHashing(model.Password, 10);
                user.Firstname = model.Firstname;
                user.Lastname = model.Lastname;
                user.DateOfBirth = model.DateOfBirth;                
                user.Email = model.Email;
                user.Phone = model.Phone;
                user.Mobile = model.Mobile;
                user.GroupIndex = model.GroupIndex;

                // Call update method on the repository service passing it the
                // user object to update the data in the database table
                User updatedUser = _userRepository.Update(user);

                return RedirectToAction("index");
            }

            return View(model);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _userRepository.GetUser((int)id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _userRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            if (_userRepository.GetUser(id) != null)
            {
                return true;
            }
            return false;
        }

        // GET
        [HttpGet]
        public async Task<IActionResult> Search()
        {
            var model = new UserSearchViewModel();
            return View(model);
        }

        // POST
        [HttpPost]
        public async Task<IActionResult> Search(UserSearchViewModel model)
        {
            if (ModelState.IsValid)
            {
                switch (model.Type)
                {
                    case 1:
                        Console.WriteLine(model.Firstname);
                        break;
                    case 2:
                        Console.WriteLine(model.Lastname);
                        break;
                    case 3:
                        Console.WriteLine(model.DateOfBirth);
                        break;
                    case 4:
                        Console.WriteLine(model.Email);
                        break;
                    case 5:
                        Console.WriteLine(model.Phone);
                        break;
                    case 6:
                        Console.WriteLine(model.Mobile);
                        break;
                    default:
                        return NotFound();
                }

                // Call update method on the repository service passing it the
                // user object to update the data in the database table
                // User updatedUser = _userRepository.Update(user);

                return RedirectToAction("index");
            }
            return View(model);
        }

        /*
        private readonly Context _context;

        public UsersController(Context context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _context.User.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,Username,Password,Firstname,Lastname,DateOfBirth,Email,Phone,Mobile,GroupIndex")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,Username,Password,Firstname,Lastname,DateOfBirth,Email,Phone,Mobile,GroupIndex")] User user)
        {
            if (id != user.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.UserId))
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
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.User.FindAsync(id);
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.UserId == id);
        }
    }
    */
    }
}