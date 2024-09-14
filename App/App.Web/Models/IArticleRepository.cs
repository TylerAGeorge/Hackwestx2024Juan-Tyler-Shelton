namespace App.Web.Models
{
    public interface IArticleRepository
    {
        IEnumerable<Article> GetAll();
        Article? GetOne(int id);

    }
}
