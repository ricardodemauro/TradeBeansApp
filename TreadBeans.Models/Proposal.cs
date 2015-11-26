using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreadBeans.Models
{
    public class Proposal : ModelBase
    {
        private long id;

        [JsonProperty("id")]
        public long Id
        {
            get { return id; }
            set { Set(ref id, value); }
        }

        private DateTime createDate;

        [JsonProperty("create_date")]
        public DateTime CreateDate
        {
            get { return createDate; }
            set { Set(ref createDate, value); }
        }

        private long idAnnounciment;

        [JsonProperty("id_adverting")]
        public long IdAnnounciment
        {
            get { return idAnnounciment; }
            set { Set(ref idAnnounciment, value); }
        }

    }
}
