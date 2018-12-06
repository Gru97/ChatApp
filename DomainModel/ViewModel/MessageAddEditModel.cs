﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.ViewModel
{
    public class MessageAddEditModel
    {
        public string message_text { get; set; }
        public int user_id { get; set; }
        public int receiver_id { get; set; }
        public int room_id { get; set; }
        public bool type { get; set; }

    }
}
