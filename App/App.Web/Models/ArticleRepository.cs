using App.Web.HttpManagers;
using Newtonsoft.Json;
using System.Net.Http.Headers;
namespace App.Web.Models
{
    public class ArticleRepository : IArticleRepository
    {
        public string? s;
        private IEnumerable<Article> _getAll;
        private Article _getOne { get; set; }
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

        public Article GetOne(string id)
        {
            GetOneAsync(id).GetAwaiter().GetResult();
            return _getOne;
        }


        async Task GetOneAsync(string id)
        {
            //ArticleAccessor.Client.BaseAddress = new Uri("https://localhost:7135");
            //ArticleAccessor.Client.DefaultRequestHeaders.Accept.Clear();
            //ArticleAccessor.Client.DefaultRequestHeaders.Accept.Add(
            //    new MediaTypeWithQualityHeaderValue("application/json"));
            s = await ArticleAccessor.GetArticleAsync(id);

            this._getOne = JsonConvert.DeserializeObject<Article>(s);
        }
        async Task GetAllFAQ()
        {
            s = await ArticleAccessor.GetArticleAsync();

            this._getAll = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Article>>(s);
        }

    }
}
