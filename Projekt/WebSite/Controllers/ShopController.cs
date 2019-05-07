using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.Models.db;
using WebSite.Models; 

namespace WebSite.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        [HttpGet]
        public ActionResult Earrings()
        {
            ArticleRepositoryDB articleRepositoryDB = new ArticleRepositoryDB();
            List<Article> articles = new List<Article>(); 
            try
            {
                articleRepositoryDB.Open();
                Kategorien kategorien = Kategorien.Ohrring;
                articles = articleRepositoryDB.GetAllArticles(kategorien);
            }
            catch(Exception)
            {
                throw;
            }
            finally { articleRepositoryDB.Close();  }
            return View(articles);
        }
        public ActionResult Necklaces()
        {
            return View();
        }
        public ActionResult Rings()
        {
            return View();
        }
        public ActionResult Bracelets()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddArticle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddArticle(Article article)
        {
            IArticleRepository articleRepository = new ArticleRepositoryDB();
            try
            {
                articleRepository.Open();
                articleRepository.InsertArticle(article);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                articleRepository.Close();
            }
            return RedirectToAction("../home/index");
        }

        public ActionResult Cart()
        {
            List<Article> articles = new List<Article>();
            ArticleRepositoryDB articleRepositoryDB = new ArticleRepositoryDB();
            try
            {
                articleRepositoryDB.Open(); 
                for (int i = 0; i < Session.Count; i++)
                {
                    articles.Add(articleRepositoryDB.GetArticleByID((int)Session[i]));
                }
            }
            catch(Exception)
            {
                throw;
            }
            finally { articleRepositoryDB.Close(); }
            return View(articles); 
        }
    }
}