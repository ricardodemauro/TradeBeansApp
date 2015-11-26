using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TreadBeans.Models
{
    public class Announciment : ModelBase
    {
        private string owner;
        /// <summary>
        /// Getter and Setter of Owner
        /// </summary>
        public string Owner
        {
            get { return owner; }
            set { Set(ref owner, value); }
        }

        private DateTime createDate;

        [JsonProperty("create_date")]
        public DateTime CreateDate
        {
            get { return createDate; }
            set { Set(ref createDate, value); }
        }

        private DateTime expireDate;

        [JsonProperty("expire_date")]
        public DateTime ExpireDate
        {
            get { return expireDate; }
            set { Set(ref expireDate, value); }
        }

        private AnnouncimentStatus status;

        [JsonProperty("status")]
        public AnnouncimentStatus Status
        {
            get { return status; }
            set { Set(ref status, value); }
        }

        private AnnouncimentType type;

        [JsonProperty("type")]
        public AnnouncimentType Type
        {
            get { return type; }
            set { Set(ref type, value); }
        }

        private TradeItem item;

        [JsonProperty("item")]
        public TradeItem Item
        {
            get { return item; }
            set { Set(ref item, value); }
        }

    }
}
