using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elgigantenrepare.Models
{
    public class opretSagModel
    {

        [JsonProperty("beskrivelse")]
        public string Beskrivelse { get; set; }
        [JsonProperty("chip_id")]
        public int Chip_id { get; set; }
        [JsonProperty("medarbejder_id")]
        public int Medarbejder_id { get; set; }
        [JsonProperty("kunde_id")]
        public int Kunde_id { get; set; }
        [JsonProperty("produkt_id")]
        public int Produkt_id { get; set; }
        [JsonProperty("status_id")]
        public int Status_id { get; set; }
        [JsonProperty("sagstype_id")]
        public int Sagstype_id { get; set; }
        [JsonProperty("afhentningstype_id")]
        public int Afhentningstype_id { get; set; }

        public opretSagModel(string beskrivelse , int chip_id, int medarbejder_id, int kunde_id , int produkt_id, int status_id, int sagstype_id, int afhentningstype_id)
        {
            Beskrivelse = beskrivelse; 
            Chip_id = chip_id; 
            Medarbejder_id = medarbejder_id; 
            Kunde_id = kunde_id; 
            Produkt_id = produkt_id; 
            Status_id = status_id; 
            Sagstype_id = sagstype_id; 
            Afhentningstype_id = afhentningstype_id;
        }

        public opretSagModel()
        {

        }

    }
}
