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
        public DomainModel.ViewModel.RoomListItem GetRoomByID(int id)
        {
            var r= db.tblRooms.SingleOrDefault(x => x.RoomID == id);
            return new DomainModel.ViewModel.RoomListItem
            {
                RoomID = r.RoomID,
                Picture = r.Picture,
                RoomName = r.RoomName
            };
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
