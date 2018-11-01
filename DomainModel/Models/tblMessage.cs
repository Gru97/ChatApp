using System;
using System.Collections.Generic;

namespace DomainModel.Models
{
    public partial class tblMessage
    {
        public int message_id { get; set; }
        public Nullable<int> user_id { get; set; }
        public Nullable<int> receiver_id { get; set; }
        public string message_text { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public virtual tblUser tblUser { get; set; }
    }
}
