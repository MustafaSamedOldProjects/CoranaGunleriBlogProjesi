using AutoMapper;
using Bussiness.Interfaces;
using DTOs.Concrete;
using DTOs.Concrete.AppUserDtoS;
using DTOs.Concrete.YaziDtoS;
using Entities.Concrete;
using Entities.StringInfos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Controllers
{

    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        //1: KULLANICIARA ROLLER ATAYABİLECEK.
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly IYaziService _yaziService;
        private readonly ITagService _tagService;
        private readonly IAppUserService _appUserService;
        private readonly IAppRoleService _appRoleService;
        private readonly IGenericService<Yazi> _genericService;
        private readonly IGenericService<AppRole> _genericServiceR;
        private readonly IApplicationUserRoleService _applicationUserRoleService;

        public AdminController(IGenericService<AppRole> genericServiceR, IApplicationUserRoleService applicationUserRoleService, IAppRoleService appRoleService, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IMapper mapper, IYaziService yaziService, ITagService tagService, IAppUserService appUserService, IGenericService<Yazi> genericService)
        { 

            _genericServiceR =genericServiceR;
            _applicationUserRoleService = applicationUserRoleService;
            _userManager = userManager;
            _roleManager = roleManager;
            _appRoleService = appRoleService;
            _genericService = genericService;
            _mapper = mapper;
            _yaziService = yaziService;
            _tagService = tagService;
            _appUserService = appUserService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> RolAta()
        {

            /*
             1: Kullanıcılar listelenecek. Ve Rol ataması yapılabilecek bir drop down menuden.
             */
            /*
             * önce kullanıcıları getir kullanıcılara karşılık gelen rolu getir.
             * ve rolleri ayrı olarak al ve dto da birleştirip yolla
             * */

            var roller = _genericServiceR.GetAll().Result;

            var bu =  await _appUserService.GetAllUsers();
            List<TempDto> tempDtos = new List<TempDto>();
            var denemes = new List<deneme>();
            foreach (var item in bu)
            {
                denemes.Add(new deneme() { 
                AppUserId = item.Id,
                appRoles = roller,
                roller = _userManager.GetRolesAsync(item).Result.ToList(),
                UserNama = item.UserName
            });
               

            }
            //foreach (var item in bu)
            //{
            //    var role = await _applicationUserRoleService.GetirUserIdyKarşılıkGelenRoleIdYiAsync(item.Id);
            //    foreach (var item2 in role.ApplicationUserRoles)
            //    {
            //        var i = item2;
            //    }
            //    var rolename = _genericServiceR.GetById(role.ApplicationUserRoles.FirstOrDefault().RoleId).Result;
                
            //    tempDtos.Add(new TempDto() { 
            //    UId = item.Id,
            //    UName = item.UserName,
            //    RId= role.RoleId,
            //    Urole = rolename.Name,
            //    appRoles = roller.Result
            //    });
            //}


            return View(denemes);
            //return View();
        }
        [HttpPost]
        public async Task<IActionResult> RolAta(int uid,  int rid, [FromForm] GetAllUsersDtoHelper gelen)
        {
            //1:User bulup rolünü update ediceksin.
            var roller = new List<string>() {
            RoleNames.Admin,
            RoleNames.Member,
            RoleNames.Moderator,
            RoleNames.Validator,
            RoleNames.Writer
            };
            var user = _userManager.FindByIdAsync(uid.ToString()).Result;
            var getuserdefaultRole = await _userManager.GetRolesAsync(user);
            var getirRole = _appRoleService.GetRoleById(rid);
            await _userManager.RemoveFromRolesAsync(user, roller);
            await _userManager.RemoveFromRoleAsync(user, getuserdefaultRole[0]);
            await _userManager.AddToRoleAsync(user,getirRole.Result.Name);
            //_genericServiceAppUSER.UpdateUserRole(gelen.appUsers.Id,gelen.appRoles.Id);
            return RedirectToAction("Temp2");
        }
        public IActionResult Onaylanmayanlar()
        {
            List<YaziDetailstDto> list = new List<YaziDetailstDto>();
            foreach (var item in _yaziService.GetAll().Result)
            {
                List<AppUser> users = new List<AppUser>();
                foreach (var us in _appUserService.GetUsersByYaziId(item.Id).Result)
                {
                    users.Add(us);
                }
                list.Add(new YaziDetailstDto()
                {
                    AppUser = users,
                    Baslik = item.Baslik,
                    YazıldıgıTarih = item.YazıldıgıTarih,
                    Kategori = _yaziService.GetYaziKategoris(item.Id).Result,
                    Tag = _tagService.GetirTagsByYaziId(item.Id).Result,
                    BeklemeDurumu = item.BeklemeDurumu,
                    Id = item.Id
                });
            }
            return View(list);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _genericService.Delete(_yaziService.GetById(id).Result);
            return RedirectToAction("Temp");
        }
        public IActionResult Temp()
        {
            return RedirectToAction("Onaylanmayanlar");

        }
        public IActionResult Temp2()
        {
            return RedirectToAction("RolAta");

        }
    }
}
