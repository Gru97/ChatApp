using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class MessageRepo:IDisposable
    {
        DomainModel.Models.ChatAppContext db = new DomainModel.Models.ChatAppContext();

        public void Add(DomainModel.ViewModel.MessageAddEditModel m)
        {
            var message = new DomainModel.Models.tblMessage
            {
                date = DateTime.Now,
                message_text = m.message_text,
                user_id = m.user_id,
                receiver_id = 2             //for now
                
            };

            db.tblMessages.Add(message);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public List<DomainModel.ViewModel.MessageListItem> List()
        {
            var q = from m in db.tblMessages
                    join u in db.tblUsers on m.user_id equals u.user_id
                    select new DomainModel.ViewModel.MessageListItem
                    {
                        date = m.date,
                        message_text = m.message_text,
                        user_name = u.username

                    };
            q = q.Take(20);
            return q.ToList();
        }
        public List<DomainModel.ViewModel.MessageListItem> List(DateTime date)
        {
            var q = from m in db.tblMessages
                    join u in db.tblUsers on m.user_id equals u.user_id
                    select new DomainModel.ViewModel.MessageListItem
                    {
                        date = m.date,
                        message_text = m.message_text,
                        user_name = u.username

                    };
            q = q.Where(x => x.date > date);
            return q.ToList();
        }
    }
}
