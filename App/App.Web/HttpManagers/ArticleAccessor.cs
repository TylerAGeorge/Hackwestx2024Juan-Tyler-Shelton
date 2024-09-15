using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using App.Web.Models;
using MongoDB.Bson.Serialization.Conventions;

namespace App.Web.HttpManagers
{
    public static class ArticleAccessor
    {
        static ArticleAccessor()
        {
            ArticleAccessor.Client.BaseAddress = new Uri("https://localhost:7135");
            ArticleAccessor.Client.DefaultRequestHeaders.Accept.Clear();
            ArticleAccessor.Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public static HttpClient Client = new HttpClient();

        public static async Task<Uri> CreateArticleAsync(Article f)
        {
            HttpResponseMessage response = await Client.PostAsJsonAsync("api/Article", f);
            response.EnsureSuccessStatusCode();

            return response.Headers.Location;
        }

        public static async Task<String> GetArticleAsync()
        {
            string? f = null;
            HttpResponseMessage response = await Client.GetAsync("/api/Article");
            if (response.IsSuccessStatusCode)
            {
                f = await response.Content.ReadAsStringAsync();
            }
            return f;
        }

        public static async Task<String> GetArticleAsync(string id)
        {
            string? f = null;
            HttpResponseMessage response = await Client.GetAsync($"/api/Article/{id}");
            if (response.IsSuccessStatusCode)
            {
                f = await response.Content.ReadAsStringAsync();
            }
            return f;
        }

        public static async Task<Article> UpdateArticleAsync(Article f)
        {
            HttpResponseMessage response = await Client.PutAsJsonAsync($"api/Article/{f._id}", f);
            response.EnsureSuccessStatusCode();

            f = await response.Content.ReadAsAsync<Article>();
            return f;
        }

        public static async Task<HttpStatusCode> DeleteArticleAsync(string id)
        {
            HttpResponseMessage response = await Client.DeleteAsync($"api/Article/{id}");

            return response.StatusCode;
        }


    }
}
