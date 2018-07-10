using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using netCoreWorkshop.Entities;
using netCoreWorkshop.Business;

namespace netCoreWorkshop.API
{
    [Route("/api/articles")]
    public class ArticlesApiController : Controller
    {
        private readonly IArticlesService articlesService;

        public ArticlesApiController(IArticlesService articlesService)
        {
            this.articlesService = articlesService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(articlesService.GetOneArticle(id));
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(articlesService.GetAllArticles());
        }

        [HttpPost]
        public IActionResult Create([FromBody]Article article)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            articlesService.AddArticle(article);

            return CreatedAtAction(nameof(Create), new { id = article.Title }, article);
        }

        
        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody]Article article)
        {
            if (id != article.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            articlesService.EditArticle(article);
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            articlesService.DeleteArticle(id);

            return NoContent();
        }
    }
}