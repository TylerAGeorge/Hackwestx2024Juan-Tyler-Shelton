using Microsoft.EntityFrameworkCore;

namespace App.Web.Models
{
    public class FrequentlyAskedQuestionDb : DbContext
    {
        public FrequentlyAskedQuestionDb(DbContextOptions<FrequentlyAskedQuestionDb> options) : base(options) { }

        // public DbSet<FrequentlyAskedQuestion>

    }
}
