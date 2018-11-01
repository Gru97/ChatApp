
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.ViewModel
{
    public class MessageListItem
    {
        //public int user_id { get; set; }
        public string message_text { get; set; }
        public string user_name { get; set; }
        public DateTime? date { get; set; }

    }
}
