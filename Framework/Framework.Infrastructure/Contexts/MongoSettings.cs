namespace Framework.Infrastructure.Contexts;

public class MongoSettings
{
    public string ConnectionString { get; set; } = string.Empty;
    public string DatabaseName { get; set; } = string.Empty;
    public string CollectionName { get; set; } = string.Empty;

    public MongoSettings(string connectionString, string databaseName, string collectionName)
    {
        ConnectionString = connectionString;
        DatabaseName = databaseName;
        CollectionName = collectionName;
    }

}
