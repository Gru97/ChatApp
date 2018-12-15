using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ChatApp.Controllers
{
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        // GET: api/User
        public IEnumerable<DomainModel.ViewModel.UserListItem> Get()
        {
            using (DataAccess.Repository.UserRepo repo=new DataAccess.Repository.UserRepo())
            {
                var lst=repo.List();
                return lst.AsEnumerable();
            }
        }

        // GET: api/User/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }

        //GET: api/User/AddUserToRoom
        [HttpGet]
        [Route("AddUserToRoom/")]
        public object AddUserToRoom([FromUri]DomainModel.ViewModel.RoomUser rm)
        {
            using (DataAccess.Repository.UserRepo repo=new DataAccess.Repository.UserRepo())
            {
                if (repo.AddUserToRoom(rm))
                {
                    using (DataAccess.Repository.UserRepo r = new DataAccess.Repository.UserRepo())
                    {
                        //AddedUser is the user who has been added to room
                        var AddedUser = r.Get(rm.UserID).username;
                        var CurrentUser= HttpContext.Current.User.Identity.Name;
                        return new { Added = AddedUser,User= CurrentUser }; 
                    }
                 
                }
                else
                    return null;
            }
        }
    }
}
