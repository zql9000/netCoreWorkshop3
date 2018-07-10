using System.Collections.Generic;
using netCoreWorkshop.Entities;

namespace netCoreWorkshop.Business
{
    public interface IArticlesService
    {
        Article GetOneArticle(int id);

        List<Article> GetAllArticles();

        Article AddArticle(Article article);

        void DeleteArticle(int id);

        void EditArticle(Article article);
    }
}