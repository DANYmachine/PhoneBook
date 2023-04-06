namespace PhoneBook.Models
{
    public class AppSettingsStore
    {
        public string DbConnectionString { get; private set; }

        public AppSettingsStore(IConfiguration configuration)
        {
            DbConnectionString = configuration.GetConnectionString("DefaultConnectionString");
        }
    }
}
