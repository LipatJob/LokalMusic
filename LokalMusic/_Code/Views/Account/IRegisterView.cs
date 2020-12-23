using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LokalMusic._Code.Views.Account
{
    interface IRegisterView
    {
        string Email { get; }
        string Password { get; }
        string ConfirmPassword { get; }

    }
}
