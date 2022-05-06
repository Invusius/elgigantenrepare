using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elgigantenrepare.Models
{
    public class medarbejderloginModel
    {
        [JsonProperty("username")]
        string username { get; set;}
        [JsonProperty("password")]
        string password { get; set;}


        public medarbejderloginModel(string Username, string Password)
        {
            username = Username;
            password = Password; 

        }

    }
}
