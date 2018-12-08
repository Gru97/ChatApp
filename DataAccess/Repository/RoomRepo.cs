using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class RoomRepo : IDisposable
    {
        DomainModel.Models.ChatAppContext db = new DomainModel.Models.ChatAppContext();

        public List<DomainModel.ViewModel.RoomListItem> List(int userID)
        {
            var q = from r in db.tblRoomUsers
                    join rooms in db.tblRooms
                    on r.RoomID equals rooms.RoomID
                    where r.UserID == userID
                    select new DomainModel.ViewModel.RoomListItem {RoomID=rooms.RoomID, RoomName = rooms.RoomName, Picture = rooms.Picture };
     
            return q.ToList();
        }
        public List<DomainModel.ViewModel.RoomListItem> List()
        {
            var q = from rooms in db.tblRooms       
                    select new DomainModel.ViewModel.RoomListItem {RoomID=rooms.RoomID, RoomName = rooms.RoomName, Picture = rooms.Picture };
            return q.ToList();
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
