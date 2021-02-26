using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Helpers
{
    public class HelpYaziCreate
    {
        UserManager<AppUser> _userManager;
        IHttpContextAccessor HttpContext;
        public HelpYaziCreate(UserManager<AppUser> userManager, IHttpContextAccessor contextAccessor)
        {
            HttpContext = contextAccessor;
            _userManager = userManager;
        }
        
        public Task<AppUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.HttpContext.User);

    }
}
