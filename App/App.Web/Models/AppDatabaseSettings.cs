namespace App.Web.Models
{
    public class AppDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set;} = null!;
        public string FAQCollectionName { get; set; } = null!;
    }
}
