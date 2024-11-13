using Microsoft.AspNetCore.Mvc;
using NexusBijoux.web.Data.Entities;

namespace NexusBijoux.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserControllers : ControllerBase
    {
        private static List<User> users = new List<User>();

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            var user = users.FirstOrDefault(u => u.User_ID == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public ActionResult<User> RegisterUser(User newUser)
        {
            newUser.User_ID = users.Count > 0 ? users.Max(u => u.User_ID) + 1 : 1;
            users.Add(newUser);
            return CreatedAtAction(nameof(GetUser), new { id = newUser.User_ID }, newUser);
        }
    }
}