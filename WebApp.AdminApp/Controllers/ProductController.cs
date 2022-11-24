﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System;
using WebApp.AdminApp.Services;
using WebApp.ViewModels.Catalog.Products;
using WebApp.Utilities.Constants;

namespace WebApp.AdminApp.Controllers
{
    public class ProductController : BaseController
    {

        private readonly IProductApiClient _productApiClient;
        private readonly IConfiguration _configuration;
       
        public ProductController(IProductApiClient productApiClient, IConfiguration configuration) 
        { 
            _productApiClient = productApiClient;
            _configuration = configuration;           
        }
        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 10)
        {
            var languageid = HttpContext.Session.GetString(SystemConstant.AppSettings.DefaultLanguageId);
            var request = new GetManageProductPagingRequest()
            {
                Keyword = keyword,
                PageSize = pageSize,
                PageIndex = pageIndex,
                LanguageId = languageid
            };
            var data = await _productApiClient.GetPagings(request);

            ViewBag.Keyword = keyword;
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] ProductCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _productApiClient.Create(request);
            if (result)
            {
                TempData["result"] = "Thêm mới sản phẩm thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Thêm sản phẩm thất bại");
            return View(request);
        }
    }
}
