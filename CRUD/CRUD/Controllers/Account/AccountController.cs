using CRUD.Data;
using CRUD.Models.Account;
using CRUD.Models.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CRUD.Controllers.Account
{
    public class AccountController : Controller
    {
        private readonly myDbContext myContext;

        public AccountController(myDbContext myContext)
        {
            this.myContext = myContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginSignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                var nameProp = myContext.Contacts.Where(x=> x.Username== model.Username).FirstOrDefault();

                if(nameProp != null)
                {
                    bool isValid = (nameProp.Username==model.Username && nameProp.Password==model.Password);

                    if (isValid)
                    {
                        var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, model.Username) }, CookieAuthenticationDefaults.AuthenticationScheme);

                        var principal = new ClaimsPrincipal(identity);
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                        HttpContext.Session.SetString("Username", model.Username);

                        return RedirectToAction("Index","Home");
                    }
                    else
                    {
                        TempData["errorPass"] = "Invalid Password!";
                        return View(model);
                    }
                }
                else
                {
                    TempData["errorName"] = "Username Not Found!";
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            //deleting Cookies and sessions
            var storedCookies = Request.Cookies.Keys;
            foreach(var cookie in storedCookies)
            {
                Response.Cookies.Delete(cookie);
            }
            return RedirectToAction("Login","Account");
        }

        [AcceptVerbs("Post","Get")]
        public IActionResult NameIsExist(string name)
        {
            var userName = myContext.Contacts.Where(x => x.Username == name).SingleOrDefault();
            if (userName != null)
            {
                return Json($"Username {userName} is already in Use!");
            }
            else
            {
                return Json(true);
            }
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(SignupViewModel model)
        {
            if(ModelState.IsValid)
            {
                var newMember = new Contact()
                {
                    Username= model.Username,
                    Phone= model.Phone,
                    Email= model.Email,
                    Password= model.Password,
                };
                myContext.Contacts.Add(newMember);
                myContext.SaveChanges();
                TempData["successMSG"] = "Registered Successfully! Fill Login form to Log In.";
                return RedirectToAction("Login");
            }
            else
            {
                TempData["errorMessage"] = "Empty Form Can't be Submitted!";
                return View();
            }
        }
    }
}
