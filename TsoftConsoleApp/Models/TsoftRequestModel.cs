using Newtonsoft.Json;

namespace Bussiness.Models
{
    public class TsoftRequestModel
    {
        [JsonIgnore]
        public string Url { get; set; }
        
        /// <summary>
        /// Gets username tsoft webservice user
        /// </summary>
        public string UserName { get; set; } 

        /// <summary>
        /// Gets password tsoft webservice user
        /// </summary>
        public string Password { get; set; } 
    }
}