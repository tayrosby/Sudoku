using Sudoku.Models;
using Sudoku.Services.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sudoku.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View("Register");
        }

        [HttpPost]
        public ActionResult Register(UserModel model)
        {
            SecurityService service = new SecurityService();
            bool pass = service.Register(model);

            if (pass == true)
            {
                return View("Login");
            }
            else
            {
                return View("RegisterFailed");
            }

        }
    }
}