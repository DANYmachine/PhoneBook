using Newtonsoft.Json;

namespace PhoneBook.Models
{
    public abstract class BaseModel
    {
        [JsonProperty(Required = Required.AllowNull)]
        public long? Id { get; set; }
    }
}
