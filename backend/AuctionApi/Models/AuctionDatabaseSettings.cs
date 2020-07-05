namespace AuctionApi.Models
{
    public class AuctionDatabaseSettings : IAuctionDatabaseSettings
    {
        public string AuctionsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IAuctionDatabaseSettings
    {
        string AuctionsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}