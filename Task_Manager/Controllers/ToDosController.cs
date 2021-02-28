using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Task_Manager.Models;



namespace Task_Manager.Controllers
{
    public class ToDosController : Controller
    {
        private readonly TaskManagerContext _context;

        public ToDosController(TaskManagerContext context)
        {
            _context = context;
        }
        //get currently logged in user
        public class AccountController : Controller
        {
            private readonly UserManager<IdentityUser> _userManager;

            public AccountController(UserManager<IdentityUser> userManager)
            {
                _userManager = userManager;
            }

            [HttpGet]
            public async Task<string> GetCurrentUserId()
            {
                IdentityUser usr = await GetCurrentUserAsync();
                return usr?.Id;
            }

            private Task<IdentityUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        }

        // GET: ToDos
        public async Task<IActionResult> Index()
        {
                return View(await _context.ToDos.ToListAsync());
        }

        // GET: ToDos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ToDos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Id,TaskDescription,CompletionStatus,DueDate,TaskUser")] ToDos toDo)
        {

            ////AspNetUsers newUser = _context.GetUserAsync(HttpContext.User);
            //string userName = User.Identity.Name;
            // AspNetUsers currentUser = User.Identity.FindByName(userName);
            ////string name = User.Identity.Name;
            //toDo.TaskUser = newUser.UserName;
            ////string userId = AspNetUsers.Id;
            //toDo.TaskUserNavigation = newUser;
            if (ModelState.IsValid)
            {
                _context.ToDos.Add(toDo);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(toDo);
        }

        // GET: ToDos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toDo = await _context.ToDos.FindAsync(id);
            if (toDo == null)
            {
                return NotFound();
            }
            return View(toDo);
        }

        // POST: ToDos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TaskDescription,CompletionStatus,DueDate")] ToDos toDo)
        {
            if (id != toDo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(toDo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToDoExists(toDo.Id))
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
            return View(toDo);
        }

        // GET: ToDos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toDo = await _context.ToDos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (toDo == null)
            {
                return NotFound();
            }

            return View(toDo);
        }

        // POST: ToDos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var toDo = await _context.ToDos.FindAsync(id);
            _context.ToDos.Remove(toDo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ToDoExists(int id)
        {
            return _context.ToDos.Any(e => e.Id == id);
        }
    }
}
