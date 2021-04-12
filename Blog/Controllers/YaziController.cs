using AutoMapper;
using Bussiness.Interfaces;
using Data.Interfaces;
using DTOs.Concrete.YaziDtoS;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    public class YaziController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IYaziService _yaziService;
        public YaziController(IYaziService yaziService, IMapper mapper)
        {
            _mapper = mapper;
            _yaziService = yaziService;
        }
        public IActionResult Index()
        {
            List<YaziListDto> a;
            if (_yaziService.GetAll().Result.Count>1)
            {
                a = _mapper.Map<List<YaziListDto>>(_yaziService.GetAll().Result);
                
            }
            else
            {
                a = new List<YaziListDto>() { 
                new YaziListDto(){ 
                    Baslik = "İlk yazınızı yazdığınızda bu mesaj kalkacaktır.",
                    BeklemeDurumu = "İlk yazınızı yazdığınızda bu mesaj kalkacaktır."
                }
                };
            }
            return View(a);
        }
    }
}
