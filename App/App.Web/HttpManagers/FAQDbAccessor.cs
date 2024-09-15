using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using App.Web.Models;
using MongoDB.Bson.Serialization.Conventions;

namespace App.Web.HttpManagers
{
    public static class FAQDbAccessor
    {
        public static HttpClient Client = new HttpClient();

        public static async Task<Uri> CreateFAQAsync(FAQ f)
        {
            HttpResponseMessage response = await Client.PostAsJsonAsync("api/FAQ", f);
            response.EnsureSuccessStatusCode();

            return response.Headers.Location;
        }

        public static async Task<String> GetFAQAsync()
        {
            string? f = null;
            HttpResponseMessage response = await Client.GetAsync("/api/FAQ");
            if(response.IsSuccessStatusCode)
            {
                f = await response.Content.ReadAsStringAsync();
            }
            return f;
        }

        public static async Task<FAQ> UpdateFAQAsync(FAQ f)
        {
            HttpResponseMessage response = await Client.PutAsJsonAsync($"api/FAQ/{f._id}", f);
            response.EnsureSuccessStatusCode();

            f = await response.Content.ReadAsAsync<FAQ>();
            return f;
        }

        public static async Task<HttpStatusCode> DeleteFAQAsync(FAQ f)
        {
            HttpResponseMessage response = await Client.DeleteAsync($"api/FAQ/{f._id}");

            return response.StatusCode;
        }


    }
}
