namespace App.Web.Models
{
    public interface IArticleRepository
    {
        IEnumerable<Article> GetAll { get; set; }
        Article? GetOne(string id);

    }
}
