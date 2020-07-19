namespace AuctionApi.Models
{
    public class AuctionDatabaseSettings : IAuctionDatabaseSettings
    {
        public string ListingsCollectionName { get; set; }
        public string UsersCollectionName { get; set; }
        public string CategoriesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IAuctionDatabaseSettings
    {
        string ListingsCollectionName { get; set; }
        string UsersCollectionName { get; set; }
        string CategoriesCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}