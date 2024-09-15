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
        public static HttpClient Client = new HttpClient();

        public static async Task<Uri> CreateFAQAsync(Article f)
        {
            HttpResponseMessage response = await Client.PostAsJsonAsync("api/Article", f);
            response.EnsureSuccessStatusCode();

            return response.Headers.Location;
        }

        public static async Task<String> GetFAQAsync()
        {
            string? f = null;
            HttpResponseMessage response = await Client.GetAsync("/api/Article");
            if (response.IsSuccessStatusCode)
            {
                f = await response.Content.ReadAsStringAsync();
            }
            return f;
        }

        public static async Task<Article> UpdateFAQAsync(Article f)
        {
            HttpResponseMessage response = await Client.PutAsJsonAsync($"api/Article/{f._id}", f);
            response.EnsureSuccessStatusCode();

            f = await response.Content.ReadAsAsync<Article>();
            return f;
        }

        public static async Task<HttpStatusCode> DeleteFAQAsync(Article f)
        {
            HttpResponseMessage response = await Client.DeleteAsync($"api/Article/{f._id}");

            return response.StatusCode;
        }


    }
}
