using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elgigantenrepare.Models
{
    public class ProduktModel
    {

        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("navn")]
        public string navn { get; set; }
        [JsonProperty("model")]
        public ProduktModelModel model { get; set; }

    }
}
