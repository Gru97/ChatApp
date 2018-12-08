using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChatApp.Controllers
{
    public class RoomController : ApiController
    {
        // GET: api/Room
        public IEnumerable<DomainModel.ViewModel.RoomListItem> Get()
        {
            using (DataAccess.Repository.RoomRepo repo = new DataAccess.Repository.RoomRepo())
            {
                var lst = repo.List();
                return lst.AsEnumerable();
            }
        }

        // GET: api/Room/5
        public IEnumerable<DomainModel.ViewModel.RoomListItem> Get(int id)
        {
            using (DataAccess.Repository.RoomRepo repo = new DataAccess.Repository.RoomRepo())
            {
                var lst=repo.List(id);
                return lst.AsEnumerable();
            }
        }

        // POST: api/Room
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Room/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Room/5
        public void Delete(int id)
        {
        }
    }
}
