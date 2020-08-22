using Asp.NetWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Asp.NetWebApi.Controllers
{
    public class UserController : ApiController
    {
        static readonly IRepository _repository = new Repository();

        public UserController()
        {
            
        }
        //api/user
        public IEnumerable<User> GetAllUsers()
        {
            return _repository.GetAll();
        }
        //api/user/1
        public User GetUser(int id)
        {
            User item = _repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        public HttpResponseMessage PostUser(User item)
        {
            item = _repository.Add(item);
            var response = Request.CreateResponse<User>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.ID });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        //api/
        public void DeleteUser(int id)
        {
            User item = _repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _repository.Remove(id);
           
        }

        public void PutUser(int id, User user)
        {
            user.ID = id;
            if (!_repository.Update(user))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        // Simple way for GET method without using repository
        //List<User> Users = new List<User>();
        //public UserController()
        //{
        //    Users.Add(new User { ID = 1, Name = "Antra", Address = "abc" });
        //    Users.Add(new User { ID = 2, Name = "Alok", Address = "asdsbc" });
        //    Users.Add(new User { ID = 3, Name = "Anaika", Address = "absfsfsfc" });
        //}
        ////api/user
        //public IHttpActionResult GetUsers()
        //{
        //    return Json(Users);
        //    //return Ok(Users);
        //}
        ////api/user/1
        //public IHttpActionResult GetUser(int id)
        //{
        //    User user = Users.Find(m => m.ID == id);
        //    return Json(user);
        //}


    }
}
