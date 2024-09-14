
namespace App.Web.Models
{
    public class MockArticleRepository : IArticleRepository
    {
        public IEnumerable<Article> GetAll() =>
            new List<Article>()
            {
                new Article(){ArticleId=1,Title="How to Be a Cowboy", Description="Howdy. I'll show you what it takes to be a REAL cowboy", TimePublished=new DateTime(2023, 3, 12, 11, 3, 3)},
                new Article(){ArticleId=2,Title="Why Barbed Wire is Overrated", Description="This is a controversial topic, but I actually think barbed wire is overused.", TimePublished=new DateTime(2024, 2, 23, 2, 0, 59)},
                new Article(){ArticleId=3,Title="How to Find a Good Cowgirl Girlfriend", Description="Good cowgirls are hard to find these days...", TimePublished= new DateTime(2022, 11, 25, 10, 22, 43)}
            };

        public Article? GetOne(int id)
        {
            switch (id) {
                case 1:
                    return new Article() { ArticleId = 1, Title = "How to Be a Cowboy", Description = "Howdy. I'll show you what it takes to be a REAL cowboy", TimePublished = new DateTime(2023, 3, 12, 11, 3, 3) };
                case 2:
                    return new Article() { ArticleId = 2, Title = "Why Barbed Wire is Overrated", Description = "This is a controversial topic, but I actually think barbed wire is overused.", TimePublished = new DateTime(2024, 2, 23, 2, 0, 59) };
                case 3:
                    return new Article() { ArticleId = 3, Title = "How to Find a Good Cowgirl Girlfriend", Description = "Good cowgirls are hard to find these days...", TimePublished = new DateTime(2022, 11, 25, 10, 22, 43) };
             default:
                    return null;
            }

        }
    }
}
