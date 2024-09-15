using App.Web.Models;
using App.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using App.Web.HttpManagers;
namespace App.Web.Controllers
{
    public class ArticleController : Controller
    {

        private readonly IArticleRepository _articleRepository;

        public ArticleController(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public IActionResult List()
        {
            var articleListViewModel = new ArticleListViewModel(_articleRepository.GetAll);
            return View(articleListViewModel);
        }
        public IActionResult Detail(string id)
        {
            return View(_articleRepository.GetOne(id));
        }

        public IActionResult AddArticleDialogue()
        {
            return View(new AddArticleListViewModel());
        }

        public IActionResult DeleteArticle(string id)
        {
            bool s = false;
            if (!(string.IsNullOrEmpty(id)))
            {
                s = ArticleAccessor.DeleteArticleAsync(id).GetAwaiter().GetResult() == null ? false : true;
            }


            return View(new AddArticleSuccessViewModel(s));
        }
        public IActionResult AddArticle(string title, string description)
        {
            bool s = false;
            if (!(string.IsNullOrEmpty(title) || string.IsNullOrEmpty(description)))
            {
                Article article = new Article() { Title = title, Description = description, ArticleId = 0, TimePublished = DateTime.Now };

                s = ArticleAccessor.CreateArticleAsync(article).GetAwaiter().GetResult() == null ? false: true;
            }
            
            
            return View(new AddArticleSuccessViewModel(s));
        }

    }
}
