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
                        status = u.status

                    };
            return q.ToList();
        }
    }
}
