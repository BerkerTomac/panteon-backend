using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace Core.Entities
{
    public class User : IdentityUser
    {
        //  Email property is already included in IdentityUser so I didn't add it
    }
}