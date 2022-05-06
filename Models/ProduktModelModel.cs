using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elgigantenrepare.Models
{
    public class ProduktModelModel
    {

        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("navn")]
        public string navn { get; set; }
        [JsonProperty("fabrikant")]
        public FabrikantModel fabrikant { get; set;  }
        [JsonProperty("type")]
        public TypeModel type { get; set; }
    }
}
