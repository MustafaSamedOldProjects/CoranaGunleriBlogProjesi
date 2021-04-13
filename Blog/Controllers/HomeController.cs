using AutoMapper;
using Bussiness.Interfaces;
using DTOs.Concrete;
using DTOs.Concrete.YaziDtoS;
using Entities.Concrete;
using Entities.StringInfos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Controllers
{

    public class HomeController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly IYaziService _yaziService;
        private readonly ITagService _tagService;
        private readonly IAppUserService _appUserService;

        public HomeController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IMapper mapper, IYaziService yaziService, ITagService tagService, IAppUserService appUserService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _yaziService = yaziService;
            _tagService = tagService;
            _appUserService = appUserService;
        }
        public IActionResult Index()
        {
            return View(new SignInIdentityDto());
        }
        [HttpPost]
        public async Task<IActionResult> Index(SignInIdentityDto signIn)
        {
            if (ModelState.IsValid)
            {
                var identityResult = await _signInManager.PasswordSignInAsync(signIn.UserName, signIn.Password, signIn.RememberMe, true);
                TempData["sharedData"] = JsonConvert.SerializeObject(signIn);
                if (identityResult.IsLockedOut)
                {
                    var gelen = await _userManager.GetLockoutEndDateAsync(await _userManager.FindByNameAsync(signIn.UserName));

                    var kısıtlananSure = gelen.Value;

                    var kalandakika = kısıtlananSure.Minute - DateTime.Now.Minute;

                    ModelState.AddModelError("", $"3 kere yanlış deneme yaptığınız için hesabınız {kalandakika} kadar kilitlenmiştir");

                    return View("Index", signIn);
                }
                if (identityResult.IsNotAllowed)
                {
                    ModelState.AddModelError("", "Email adresinizi lütfen doğrulayınız.");
                    return View("Index", signIn);
                }
                if (identityResult.Succeeded)
                {
                    //if (_userManager.GetRolesAsync(_mapper.Map<AppUser>(signIn)).Result.Contains(RoleNames.Admin.ToString()))
                    //{
                    //    return RedirectToAction("Index", "Admin");
                    //}
                    //else if (_userManager.GetRolesAsync(_mapper.Map<AppUser>(signIn)).Result.Contains(RoleNames.Moderator.ToString()))
                    //{
                    //    return RedirectToAction("Index", "Moderator");
                    //}
                    //else if (_userManager.GetRolesAsync(_mapper.Map<AppUser>(signIn)).Result.Contains(RoleNames.Validator.ToString()))
                    //{
                    //    return RedirectToAction("Index", "Validator");
                    //}
                    //else if (_userManager.GetRolesAsync(_mapper.Map<AppUser>(signIn)).Result.Contains(RoleNames.Writer.ToString()))
                    //{
                    //    return RedirectToAction("Index", "Writer");
                    //}
                    //else if (_userManager.GetRolesAsync(_mapper.Map<AppUser>(signIn)).Result.Contains(RoleNames.Member.ToString()))
                    //{
                    //    return RedirectToAction("Index", "Member");
                    //}
                    return RedirectToAction("TempAction");
                }
                ModelState.AddModelError("", "Böyle bir kullanıcı yok veya şifrenizi yanlış giriyorsunuz.");
            }
            return View(signIn);
        }

        public IActionResult KayitOl()
        {
            return View(new SignUpIdentityDto());
        }
        [HttpPost]
        public async Task<IActionResult> KayitOl(SignUpIdentityDto signUp)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    Email = signUp.Email,
                    UserName = signUp.UserName
                };
                var result = await _userManager.CreateAsync(user, signUp.Password);
                await _userManager.AddToRoleAsync(user, RoleNames.Member.ToString());
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(signUp);
        }
        public async Task<IActionResult> LogOut()
        {
            //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var user = await _userManager.FindByIdAsync(userId);
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
        [Authorize(Roles ="Admin,Member, Moderator,Validator,Writer")]
        public IActionResult TempAction()
        {
            var signIn =  JsonConvert.DeserializeObject<SignInIdentityDto>(TempData["sharedData"].ToString());
            if (_userManager.GetRolesAsync(_mapper.Map<AppUser>(signIn)).Result.Contains(RoleNames.Admin.ToString()))
            {
                return RedirectToAction("Index", "Admin");
            }
            else if (_userManager.GetRolesAsync(_mapper.Map<AppUser>(signIn)).Result.Contains(RoleNames.Moderator.ToString()))
            {
                return RedirectToAction("Index", "Moderator");
            }
            else if (_userManager.GetRolesAsync(_mapper.Map<AppUser>(signIn)).Result.Contains(RoleNames.Validator.ToString()))
            {
                return RedirectToAction("Index", "Validator");
            }
            else if (_userManager.GetRolesAsync(_mapper.Map<AppUser>(signIn)).Result.Contains(RoleNames.Writer.ToString()))
            {
                return RedirectToAction("Index", "Writer");
            }
            else if (_userManager.GetRolesAsync(_mapper.Map<AppUser>(signIn)).Result.Contains(RoleNames.Member.ToString()))
            {
                return RedirectToAction("Index", "Member");
            }
            return RedirectToAction("Index");
        }
        public IActionResult AnaSayfa()
        {
            // buradan kullanıcı isterse tag'e göre , isterse konuya göre, isterse yazara göre arayabilelecek search kutusundan
            // yazının başlığı,tag'i, konusunu, yazarı görünecek.
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
    }
}
