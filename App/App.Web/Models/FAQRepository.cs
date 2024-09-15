using App.Web.HttpManagers;
using Newtonsoft.Json;
using System.Net.Http.Headers;
namespace App.Web.Models
{
    public class FAQRepository: IFAQRepository
    {
        public string s;
        private IEnumerable<FAQ> _getAll;
        public IEnumerable<FAQ> GetAll
        {
            get
            {
                GetAllFAQ().GetAwaiter().GetResult() ;
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

            this._getAll = Newtonsoft.Json.JsonConvert.DeserializeObject<List<FAQ>>(s);
        }

    }
}
