namespace App.Web.Models
{
    public interface IFAQRepository
    {
        IEnumerable<FAQ> GetAll { get; }
    }
}
