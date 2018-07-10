using System.Collections.Generic;
using netCoreWorkshop.Entities;
using System.Linq;

namespace netCoreWorkshop.Business
{
    public class ArticlesService : IArticlesService
    {
        public Article GetOneArticle(int id) => Article.DataSource.Where(m => m.Id == id).FirstOrDefault();

        public List<Article> GetAllArticles() => Article.DataSource;
            
        public Article AddArticle(Article article)
        {
            article.Id = Article.DataSource.Count() + 1;
            Article.DataSource.Add(article);

            return article;
        }

        public void DeleteArticle(int id)
        {
            var article = Article.DataSource.Where(m => m.Id == id).FirstOrDefault();

            Article.DataSource.Remove(article);
        }

        public void EditArticle(Article article)
        {
            var currentArticle = Article.DataSource.Where(m => m.Id == article.Id).FirstOrDefault();

            currentArticle.Title = article.Title;
        }
    }
}