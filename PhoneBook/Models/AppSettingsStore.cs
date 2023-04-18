namespace PhoneBook.Models
{
    public class AppSettingsStore
    {
        public string DbConnectionString { get; private set; }

        public AppSettingsStore(IConfiguration configuration)
        {
            //DbConnectionString = configuration.GetConnectionString("ConnectionString");
            DbConnectionString = "Data Source=DESKTOP-P30DA0N\\SQLEXPRESS;Initial Catalog=webapi;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

            /*string host = "localhost"; // Имя хоста
            string database = "webapi"; // Имя базы данных
            string user = "root"; // Имя пользователя
            string password = "Dan2334001"; // Пароль пользователя

            DbConnectionString = "Database=" + database + ";server=" + host + ";User=" + user + ";Password=" + password;*/

        }
    }
}
