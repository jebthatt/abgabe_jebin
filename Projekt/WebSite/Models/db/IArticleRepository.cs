using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.Models; 

namespace WebSite.Models.db
{
    interface IArticleRepository
    {
        void Open();
        void Close();

        List<Article> GetAllArticles(Kategorien kategorien);
        Article GetArticleByID(int id);
        void InsertArticle(Article articleToInsert);
    }
}
