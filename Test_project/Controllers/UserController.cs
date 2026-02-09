using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Test_project.Models;

namespace Test_project.Controllers
{


    public class UserController : Controller
    {

        private readonly UsersDbContext dbContext;

        public UserController(UsersDbContext DbContext)
        {
            this.dbContext = DbContext;
        }

        [HttpGet]
        public async Task<IActionResult> UserList()
        {
            var users = await dbContext.Users.ToListAsync();
            return View(users);
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            ViewBag.States = new SelectList(dbContext.States, "SName", "SName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserDTO users)
        {
            ViewBag.States = new SelectList(dbContext.States, "SName", "SName");
            if (ModelState.IsValid)
            {
                Users user = new Users
                {
                    Name = users.Name,
                    EmailId = users.EmailId,
                    MobileNo = users.MobileNo,
                    Address = users.Address,
                    Gender = users.Gender,
                    State = users.State,
                    Hobbies = (string.Join(", ", users.Hobbies)).ToString()

                };
                await dbContext.Users.AddAsync(user);
                await dbContext.SaveChangesAsync();
                return RedirectToAction("UserList","User");
            }
            return View();
        }

        [HttpGet]
        public IActionResult UpdateUser(int id)
        {
            ViewBag.States = new SelectList(dbContext.States, "SName", "SName");
            var user = dbContext.Users.Find(id);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(int id,Users user)
        {
            ViewBag.States = new SelectList(dbContext.States, "SName", "SName");
            if (ModelState.IsValid)
            {
                try
                {
                    dbContext.Users.Update(user);
                    await dbContext.SaveChangesAsync();
                    TempData["SuccessMessage"] = "User updated successfully.";
                    return RedirectToAction("UserList", "User");
                }
                catch(DbUpdateConcurrencyException)
                {
                    if (!dbContext.Users.Any(u => u.Id == id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        return RedirectToAction("UserList", "User");
                    }
                }
                
            }
            return RedirectToAction("UserList", "User");
        }
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = dbContext.Users.Find(id);
            if (user != null)
            {
                dbContext.Remove(user);
                await dbContext.SaveChangesAsync(); 
                TempData["SuccessMessage"] = "User deleted successfully.";
                
            }

            return RedirectToAction("UserList", "User");
        }

        [HttpGet]
        public async Task<IActionResult> UserDetails(int id)
        {
            var user = await dbContext.Users.FindAsync(id);
            return View(user);
        }


    }    
}
