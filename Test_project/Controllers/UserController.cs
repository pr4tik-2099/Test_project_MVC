using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public IActionResult UserList()
        {
            var users = dbContext.Users.ToList();
            return View(users);
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            ViewBag.States = new SelectList(dbContext.States, "SName", "SName");
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(User user)
        {
            return View();
        }
    }
}
