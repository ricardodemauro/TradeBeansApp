using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreadBeans.Models
{
    public class TradeItem : ModelBase  
    {
        private int id;

        [JsonProperty("id_product")]
        public int Id
        {
            get { return id; }
            set { Set(ref id, value); }
        }
    }
}
