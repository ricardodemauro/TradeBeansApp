using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreadBeans.Models
{
    public class Product : ModelBase
    {
        private int id;

        [JsonProperty("id")]
        public int Id
        {
            get { return id; }
            set { Set(ref id, value); }
        }

        private string name;

        [JsonProperty("name")]
        public string Name
        {
            get { return name; }
            set { Set(ref name, value); }
        }

        private string description;

        [JsonProperty("description")]
        public string Description
        {
            get { return description; }
            set { Set(ref description, value); }
        }

        private string brand;

        [JsonProperty("brand")]
        public string Brand
        {
            get { return brand; }
            set { Set(ref brand, value); }
        }

    }
}
