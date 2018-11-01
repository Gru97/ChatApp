using System;
using System.Collections.Generic;

namespace DomainModel.Models
{
    public partial class tblUser
    {
        public tblUser()
        {
            this.tblMessages = new List<tblMessage>();
        }

        public int user_id { get; set; }
        public Nullable<short> role_id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public Nullable<short> status { get; set; }
        public virtual ICollection<tblMessage> tblMessages { get; set; }
    }
}
