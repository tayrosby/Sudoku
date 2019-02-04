using Sudoku.Models;
using Sudoku.Services.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sudoku.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(UserModel model)
        {
            SecurityService service = new SecurityService();
            bool pass = service.Authenticate(model);

            if (pass == true)
            {
                return View("LoginPassed", model);
            }
            else
            {
                return View("LoginFailed");
            }

        }
    }
}