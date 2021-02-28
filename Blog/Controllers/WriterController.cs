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
using System.Net.Http.Headers;
using Mvc.Helpers;

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
        private readonly KaydetHelp kaydetHelp;
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
            kaydetHelp = new KaydetHelp(webHostEnvironment);
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
            _yaziService = yaziService;
            _tagService = tagService;
            _kategoriService = kategoriService;
        }
        public IActionResult Index()
        {
            List<YaziListDto> list = new List<YaziListDto>();
            string folder = Environment.CurrentDirectory;

            foreach (var item in _yaziService.GetAll().Result)
            {
                string readText = System.IO.File.ReadAllText(folder +item.Location);

                list.Add(new YaziListDto()
                {
                    AppUser = item.AppUser,
                    BeklemeDurumu = item.BeklemeDurumu,
                    Location = readText,
                    YazıldıgıTarih = item.YazıldıgıTarih,
                    Kategori = _yaziService.GetYaziKategoris(item.Id).Result,
                    Tag = _tagService.GetirTagsByYaziId(item.Id).Result,
                    GorunurResmi =item.GorunurResmi

                });
            }
            return View(list);
            //return View(_mapper.Map<List<YaziListDto>>(_yaziService.GetAll().Result));
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
            if (ModelState.IsValid && GorunurResmi != null)
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
                    foreach (var item in yaziCreateDto.KategoriId)
                    {
                        yazikategoris.Add(new YaziKategori()
                        {
                            KategoriId = item
                        });
                    }

                    var tags= new List<YaziTag>();
                    foreach (var item in yaziCreateDto.TagId)
                    {
                        tags.Add(new YaziTag()
                        {
                            TagId = item
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
                    var tagids = new List<int>();
                    foreach (var item in yaziCreateDto.TagId)
                    {
                        tagids.Add(item);
                    }
                    var kategorids = new List<int>();
                    foreach (var item in yaziCreateDto.KategoriId)
                    {
                        kategorids.Add(item);
                    }
                    var path = @"/wwwroot/AnaKlasor/Yazilar/"+ Guid.NewGuid()+".txt";
                    
                    string folder = Environment.CurrentDirectory;
                   
                    string fullPath = folder + path;
                    string[] authors = {"Mahesh Chand", "Allen O'Neill", "David McCarter",
"Raj Kumar", "Dhananjay Kumar"};
                  
                    System.IO.File.WriteAllText(fullPath,yaziCreateDto.Body);
                    var yazi = new Yazi()
                    {
                        AppUserId = user.Id,
                        BeklemeDurumu = OnayDurumlari.OnayBekliyor.ToString(),
                        YaziKategoris = yazikategoris,
                        YaziTags = tags,
                        YazıldıgıTarih = DateTime.Now,
                        GorunurResmi = fileBytes,
                        Location = path
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
            viev.GorunurResmi = yaziCreateDto.GorunurResmi;
            viev.Kategoris = _kategoriService.GetAll().Result;
            viev.Tags = _tagService.GetAll().Result;
            viev.Body = yaziCreateDto.Body;

            return View(viev);
        }
        public async Task<JsonResult> KaydetImage(List<IFormFile> file)
        {
            foreach (IFormFile source in file)
            {
                string filename = ContentDispositionHeaderValue.Parse(source.ContentDisposition).FileName.Trim('"');

                filename = kaydetHelp.EnsureCorrectFilename(filename);
                //var a = System.IO.File.Create(kaydetHelp.GetPathAndFilename(filename));
                using (FileStream output = System.IO.File.Create(kaydetHelp.GetPathAndFilename(filename)))
                {
                    await source.CopyToAsync(output);
                }
                return Json(new { location = Url.Content("~/AnaKlasor/Resimler/" + filename) });
            }
            return Json("Yüklendi");

        }
    }
}
