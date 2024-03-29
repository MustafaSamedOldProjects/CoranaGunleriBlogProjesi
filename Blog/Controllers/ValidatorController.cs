﻿using AutoMapper;
using Bussiness.Interfaces;
using DTOs.Concrete.YaziDtoS;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    [Authorize(Roles = "Admin,Moderator,Validator")]
    public class ValidatorController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IYaziService _yaziService;
        private readonly ITagService _tagService;
        private readonly IAppUserService _appUserService;

        public ValidatorController(IMapper mapper, IYaziService yaziService, ITagService tagService, IAppUserService appUserService)
        {
            _mapper = mapper;
            _yaziService = yaziService;
            _tagService = tagService;
            _appUserService = appUserService;
        }
        public IActionResult Index()
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
        public IActionResult Onayla(int id) 
        {
            _yaziService.Onaylar(id);
            return RedirectToAction("Temp");
        }

        public IActionResult Temp() 
        { 
            return RedirectToAction("Index");
            
        }
        //1: FARKLI ONAY DURUMLARI İÇİNDE YAPMAYI UNUTMA MESELA ONAYLANMADI GİBİ VS..
        [HttpPost]
        public IActionResult Onaylama(int id)
        {
            _yaziService.Onaylama(id);
            return RedirectToAction("Temp");
        }
    }
}
