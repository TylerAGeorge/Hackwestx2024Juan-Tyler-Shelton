using App.Web.Models;
using App.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

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

    }
}
