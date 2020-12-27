using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Models.Account
{
    public interface ILoginModel
    {
        string Email { get; set; }
        string Password { get; set; }
    }
}