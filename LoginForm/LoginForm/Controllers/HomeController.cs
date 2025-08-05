using System.Diagnostics;
using LoginForm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace LoginForm.Controllers
{
    

    public class HomeController : Controller
    {
        private readonly MyDbContext context;

        public HomeController(MyDbContext context)
        {
            this.context = context;
        }
        [Route("")]        
        
        public IActionResult Index()
        {

            return View();
        }


        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(UserTbl usr)
        {
            if (ModelState.IsValid)
            {
                var existingUser = context.UserTbls.FirstOrDefault(u => u.Email == usr.Email);
                if (existingUser != null)
                {
                    ModelState.AddModelError("Email", "Email already registered");
                    return View(usr);
                }

                context.UserTbls.Add(usr);
                context.SaveChanges();

                return RedirectToAction("Login");
            }

            return View(usr);
        }

        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                return RedirectToAction("Dashboard");

            }
            return View();
        }
        [HttpPost]
        public IActionResult Login(UserTbl user)
        {
            var usr = context.UserTbls.Where(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault();
            if (usr != null) {
                HttpContext.Session.SetString("UserSession", usr.Email);
                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.message = "Login Failed";
            }
                return View();
        }

        

        public IActionResult Dashboard()
        {
           if(HttpContext.Session.GetString("UserSession") != null)
            {
                ViewBag.Mysession = HttpContext.Session.GetString("UserSession").ToString();
            }
            else
            {
                return RedirectToAction("Login");
            }
                return View();
        }
        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                HttpContext.Session.Remove("UserSession");
               
            }
            return RedirectToAction("Login");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
