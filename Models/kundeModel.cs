using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elgigantenrepare.Models
{
    public class kundeModel
    {

        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("fornavn")]
        public string fornavn { get; set; }
        [JsonProperty("efternavn")]
        public string efternavn { get; set; }
        [JsonProperty("email")]
        public string email { get; set; }


    }
}
