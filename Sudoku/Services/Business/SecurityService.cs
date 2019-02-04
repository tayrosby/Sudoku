using Sudoku.Models;
using Sudoku.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sudoku.Services.Business
{
    public class SecurityService
    {
        public bool Authenticate(UserModel user)
        {
            UserDAO service = new UserDAO();
            return service.FindByUser(user);
        }

        public bool Register(UserModel user)
        {
            UserDAO service = new UserDAO();
            return service.Create(user);
        }

    }
}