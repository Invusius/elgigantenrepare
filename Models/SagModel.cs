using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elgigantenrepare.Models
{
    public class SagModel
    {

        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("beskrivelse")]
        public string beskrivelse { get; set; }
        [JsonProperty("kunde")]
        public kundeModel kunde { get; set; }
        [JsonProperty("medarbejder")]
        public medarbejdereModel medarbejder { get; set; }
        [JsonProperty("produkt")]
        public ProduktModel produkt { get; set; }
        [JsonProperty("sagstype")]
        public SagTypeModel sagstype { get; set; }
        [JsonProperty("afhentningstype")]
        public LeveringsTypeModel afhentningstype { get; set; }
        [JsonProperty("status")]
        public StatusModel status { get; set; }

    }
}
