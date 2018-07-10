using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using netCoreWorkshop.Entities;
using netCoreWorkshop.Business;

namespace netCoreWorkshop.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly IArticlesService articlesService;
                
        public ArticlesController(IArticlesService articlesService)
        {
            this.articlesService = articlesService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(articlesService.GetAllArticles());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Article article)
        {
            if (ModelState.IsValid)
            {
                articlesService.AddArticle(article);
                return RedirectToAction("Index");
            }

            return View(article);
        }
    }
}