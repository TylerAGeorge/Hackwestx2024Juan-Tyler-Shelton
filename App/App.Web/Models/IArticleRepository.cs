namespace App.Web.Models
{
    public interface IArticleRepository
    {
        IEnumerable<Article> GetAll { get;  }


    }
}
