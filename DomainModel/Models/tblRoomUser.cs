using System;
using System.Collections.Generic;

namespace DomainModel.Models
{
    public partial class tblRoomUser
    {
        public int ID { get; set; }
        public int RoomID { get; set; }
        public int UserID { get; set; }
        public virtual tblRoom tblRoom { get; set; }
        public virtual tblUser tblUser { get; set; }
    }
}
