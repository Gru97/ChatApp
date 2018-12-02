using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChatApp.Controllers
{
    public class ChatController : ApiController
    {
        // GET: api/Chat
        public IEnumerable<DomainModel.ViewModel.MessageListItem> Get()
        {
            using (DataAccess.Repository.MessageRepo repo = new DataAccess.Repository.MessageRepo())
            {
                var lst = repo.List();
                return lst.AsEnumerable();

            }
        }

        // GET: api/Chat/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Chat
        public void Post(DomainModel.ViewModel.MessageAddEditModel m)
        {
            using (DataAccess.Repository.MessageRepo repo = new DataAccess.Repository.MessageRepo())
            {
                repo.Add(m);
                                
            }
        }

        // PUT: api/Chat/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Chat/5
        public void Delete(int id)
        {
        }
    }
}
