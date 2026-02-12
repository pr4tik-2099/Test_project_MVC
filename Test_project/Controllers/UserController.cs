using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
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
            try
            {
                var users = await dbContext.Users.ToListAsync();
                return View(users);
            }
            catch (Exception)
            {
                throw new Exception("Error");
            }            
            
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
            try
            {
                if (ModelState.IsValid)
                {
                    var mobile_no_Exist = (from i in dbContext.Users where i.MobileNo == users.MobileNo select i).Count();
                    var Email_Exist = (from i in dbContext.Users where i.EmailId == users.EmailId select i).Count();
                    if (mobile_no_Exist > 0)
                    {
                        TempData["Message"] = "Mobile Number already Exist";
                    }
                    else if (Email_Exist > 0)
                    {
                        TempData["Message"] = "Email already Exist";
                    }
                    else
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
                        TempData["SuccessMessage"] = "User Added successfully.";
                        return RedirectToAction("UserList", "User");
                    }

                }

            }
            catch (Exception)
            {
                throw new Exception("Error"); 
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
                    if (!dbContext.Users.Any(u => u.Id == id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        dbContext.Users.Update(user);
                        await dbContext.SaveChangesAsync();
                        TempData["SuccessMessage"] = "User updated successfully.";
                        return RedirectToAction("UserList", "User");
                    }
                    
                }
                catch(Exception)
                {
                    throw new Exception("Error");

                    
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
