using AutoMapper;
using Bussiness.Interfaces;
using DTOs.Concrete.YaziDtoS;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Helpers;
using Entities.StringInfos;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace Blog.Controllers
{
    [Authorize( Roles = "Writer,Admin,Moderator,Validator,Member")]
    public class WriterController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IYaziService _yaziService;
        private readonly IYaziKategoriService _yaziKategoriService;
        private readonly IYaziYorumService _yaziYorumService;
        private readonly IKategoriService _kategoriService;
        private readonly ITagService _tagService;
        private readonly UserManager<AppUser> _userManager;
        private readonly HttpContext httpContext;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _contextAccessor;
        public WriterController(
            IYaziService yaziService,
            IYaziKategoriService yaziKategoriService,
            IYaziYorumService yaziYorumService,
            IKategoriService kategoriService,
            ITagService tagService,
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IWebHostEnvironment webHostEnvironment,
            IHttpContextAccessor contextAccessor,
        IMapper mapper)
        {
            _yaziKategoriService = yaziKategoriService;
            _yaziYorumService = yaziYorumService;
            _contextAccessor = contextAccessor;
            _webHostEnvironment = webHostEnvironment;
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
            _yaziService = yaziService;
            _tagService = tagService;
            _kategoriService = kategoriService;
        }
        public IActionResult Index()
        {
            return View(_mapper.Map<List<YaziListDto>>(_yaziService.GetAll().Result));
        }
        public IActionResult Create()
        {
            YaziCreateDto yaziCreateDto = new YaziCreateDto();
            yaziCreateDto.Kategoris = _kategoriService.GetAll().Result;
            yaziCreateDto.Tags = _tagService.GetAll().Result;

            return View(yaziCreateDto);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] YaziCreateDto yaziCreateDto, [FromForm] IFormFile GorunurResmi)
        {
            if (ModelState.IsValid)
            {
                if (User.Identity.IsAuthenticated)
                {
                    var claimsPrincipal = await _signInManager.CreateUserPrincipalAsync(_userManager.Users.FirstOrDefault());
                    var claims = claimsPrincipal.Claims.ToList();

                    var HelpYaziCreate = new HelpYaziCreate(_userManager,_contextAccessor);
                    var user = await HelpYaziCreate.GetCurrentUserAsync();


                    //var kategoris = new List<Kategori>();
                    //foreach (var item in yaziCreateDto.Kategoris)
                    //{
                    //    kategoris.Add(new Kategori() { 
                    //    Id = item.Id
                    //    }); ;
                    //}

                    var yazikategoris = new List<YaziKategori>();
                    foreach (var item in yaziCreateDto.Kategoris)
                    {
                        yazikategoris.Add(new YaziKategori()
                        {
                            KategoriId = item.Id
                        });
                    }

                    var tags= new List<YaziTag>();
                    foreach (var item in yaziCreateDto.Tags)
                    {
                        tags.Add(new YaziTag()
                        {
                            TagId = item.Id
                        });
                    }

                    var fileBytes = new byte[] { };
                    var a = GorunurResmi;
                    using (var ms = new MemoryStream())
                    {
                        a.CopyTo(ms);
                        fileBytes = ms.ToArray();
                        // act on the Base64 data
                    }

                    //byte[] p1 = null;
                    //using (var fs1 = yaziCreateDto.GorunurResmi.OpenReadStream())
                    //using (var ms1 = new MemoryStream())
                    //{
                    //    fs1.CopyTo(ms1);
                    //    p1 = ms1.ToArray();
                    //}
                    var path = _webHostEnvironment.WebRootPath + @"AnaKlasor/Yazilar"+ new Guid();
                    var yazi = new Yazi()
                    {
                        AppUser = new AppUser()
                        {
                            Id = user.Id
                        },
                        BeklemeDurumu = OnayDurumlari.OnayBekliyor.ToString(),
                        YaziKategoris = _yaziKategoriService.GetYaziKategoris(new int[] { 
                        yaziCreateDto.KategoriId
                        }).Result,
                        YaziTags = tags,
                        YazıldıgıTarih = DateTime.Now,
                        GorunurResmi = fileBytes,
                        Location = path,
                        YaziYorums = 
                        
                    };

                    await _yaziService.Add(yazi);
                    return RedirectToAction("Index");
                 }
            }

            //_yaziService.Add(new Entities.Concrete.Yazi() { 
            //Location = yaziCreateDto.Location,
            //    GorunurResmi = yaziCreateDto.GorunurResmi,
            //     = yaziCreateDto.Tag,
            //    YazıldıgıTarih = yaziCreateDto.YazıldıgıTarih,
            //    Location = yaziCreateDto.,
            //})

            YaziCreateDto viev = new YaziCreateDto();
            viev.Kategoris = _kategoriService.GetAll().Result;
            viev.Tags = _tagService.GetAll().Result;

            return View(viev);
        }
    }
}
