using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LokalMusic._Code.Models.Account
{
    public interface ISettingsModel
    {
        string Username { get; set; }
        string Email { get; set; }
        string OldPassword { get; }
    }
}
