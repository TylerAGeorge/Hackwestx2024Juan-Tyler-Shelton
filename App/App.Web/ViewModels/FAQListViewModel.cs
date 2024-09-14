using App.Web.Models;

namespace App.Web.ViewModels
{
    public class FAQListViewModel
    {
        public IEnumerable<FAQ> FAQs { get; }
        public FAQListViewModel(IEnumerable<FAQ> fAQs)
        {
            FAQs = fAQs;
        }
    }
}
