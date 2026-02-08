using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
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
        public IActionResult Index()
        {
            
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UserList()
        {
            var users = await dbContext.Users.ToListAsync();
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> AddUser()
        {
            ViewBag.States = new SelectList(dbContext.States, "SName", "SName");
            return View();
        }

        [HttpPost]
        public async  Task<IActionResult> AddUser(User user)
        {
            return View();
        }
    }
}
