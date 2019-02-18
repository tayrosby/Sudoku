﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sudoku.Models
{
    public class UserModel
    {
        [Required]
        [DisplayName("First Name")]
        [StringLength(20, MinimumLength = 3)]
        [DefaultValue("")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        [StringLength(20, MinimumLength = 3)]
        [DefaultValue("")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("User Name")]
        [StringLength(20, MinimumLength = 3)]
        [DefaultValue("")]
        public string Username { get; set; }

        [Required]
        [DisplayName("Password")]
        [StringLength(20, MinimumLength = 4)]
        [DefaultValue("")]
        public string Password { get; set; }
    }
}