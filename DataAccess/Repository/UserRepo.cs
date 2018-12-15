using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class UserRepo:IDisposable
    {
        DomainModel.Models.ChatAppContext db = new DomainModel.Models.ChatAppContext();
        public void Dispose()
        {
            db.Dispose();   
        }

        public List<DomainModel.ViewModel.UserListItem> List()
        {
            var q = from u in db.tblUsers
                    select new DomainModel.ViewModel.UserListItem
                    {
                        username = u.username,
                        status = u.status,
                        user_id=u.user_id

                    };
            return q.ToList();
        }

        public bool AddUserToRoom(DomainModel.ViewModel.RoomUser rm)
        {
            bool result = false;
            try
            {
                var u = new DomainModel.Models.tblRoomUser { RoomID = rm.RoomID, UserID = rm.UserID };
                db.tblRoomUsers.Add(u);
                db.SaveChanges();
                result = true;

            }
            catch (Exception)
            {

                throw new Exception("User didn't add to room");
            }
            return result;
        }

        public DomainModel.ViewModel.UserListItem Get(int id)
        {
            
            var u = db.tblUsers.SingleOrDefault(x => x.user_id == id);
            return new DomainModel.ViewModel.UserListItem {username=u.username, user_id=u.user_id };

            
        }

        public bool LogIn(DomainModel.ViewModel.UserLogInModel lg)
        {
            return db.tblUsers.Any(x => x.password == lg.password && x.username == lg.username);
            
                     
        }
        public int GetUserIDByUsername(string username)
        {
            var u = db.tblUsers.SingleOrDefault(x => x.username == username);
            return u.user_id;
        }
    }
}
