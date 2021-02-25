using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.Concrete
{
    public class SignInIdentityDto
    {
        public string Password { get; set; }
        public string UserName { get; set; }
        public bool RememberMe { get; set; }
    }
}
