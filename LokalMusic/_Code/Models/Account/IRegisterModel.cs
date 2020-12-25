using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Models.Account
{
    public interface IRegisterModel
    {
        string Email { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        string ConfirmPassword { get; set; }
    }
}