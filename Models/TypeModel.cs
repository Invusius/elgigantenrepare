using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elgigantenrepare.Models
{
    public class TypeModel
    {

        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("navn")]
        public string navn { get; set; }


    }
}
