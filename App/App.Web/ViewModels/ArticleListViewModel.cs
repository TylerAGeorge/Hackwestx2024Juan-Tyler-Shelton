using App.Web.Models;

namespace App.Web.ViewModels
{
    public class ArticleListViewModel
    {
        public IEnumerable<Article> Articles { get; }
        public ArticleListViewModel(IEnumerable<Article> articles)
        {
            Articles = articles;
        }
    }
}
