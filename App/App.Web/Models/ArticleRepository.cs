using App.Web.HttpManagers;
using Newtonsoft.Json;
using System.Net.Http.Headers;
namespace App.Web.Models
{
    public class ArticleRepository : IArticleRepository
    {
        public string s;
        private IEnumerable<Article> _getAll;
        public IEnumerable<Article> GetAll
        {
            get
            {
                GetAllFAQ().GetAwaiter().GetResult();
                return _getAll;
            }
            set
            {
                GetAll = value;
            }
        }
        async Task GetAllFAQ()
        {
            FAQDbAccessor.Client.BaseAddress = new Uri("https://localhost:7135");
            FAQDbAccessor.Client.DefaultRequestHeaders.Accept.Clear();
            FAQDbAccessor.Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            s = await FAQDbAccessor.GetFAQAsync();

            this._getAll = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Article>>(s);
        }

    }
}
