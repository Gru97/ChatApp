using System;
using System.Collections.Generic;

namespace DomainModel.Models
{
    public partial class tblRoom
    {
        public tblRoom()
        {
            this.tblRoomUsers = new List<tblRoomUser>();
        }

        public int RoomID { get; set; }
        public string RoomName { get; set; }
        public string Picture { get; set; }
        public string Link { get; set; }
        public virtual ICollection<tblRoomUser> tblRoomUsers { get; set; }
    }
}
