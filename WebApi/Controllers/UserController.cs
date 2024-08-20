//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using webapitaskup.Helper;
//using webapitaskup.Models;
//using webapitaskup.Interface;
//using Microsoft.AspNetCore.Mvc.Rendering;
//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace webapitaskup.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class UserController : ControllerBase
//    {
//        //private static int memberId => 1;
//        private readonly AppDbContext _dbContext;
//        public UserController(AppDbContext context)
//        {
//            _dbContext = context;
//        }
//        // GET: api/<UserController>
//        [HttpGet("GetUserInfo")]
//        public async Task<ActionResult<GetUserInfoDto>> GetUserInfo()
//        {
//            int memberId = 1;   
//            var query = from tm in _dbContext.Team_Members
//                        join t in _dbContext.Teams on tm.TeamID equals t.TeamID
//                        where tm.MemberId == memberId
//                        select new GetUserInfoDto
//                        {
//                            MemberId = tm.MemberId,
//                            Name = tm.Name,
//                            Email = tm.Email,
//                            IsActive = tm.isActive,
//                            TeamID = tm.TeamID,
//                            RoleID = tm.RoleID,
//                            Team_Name = t.Team_Name,
//                            Team_Descriptoin = t.Team_Descriptoin
//                        };

//            var userInfo = await query.FirstOrDefaultAsync();

//            if (userInfo == null)
//            {
//                return NotFound(); // Return 404 if the user is not found
//            }

//            return Ok(userInfo);
//        }

//        // GET api/<UserController>/5
//        [HttpGet("GetUser/{id}")]
//        public string GetUser(int id)
//        {
//            return "value";
//        }

//        // POST api/<UserController>
//        [HttpPost]
//        public void Post([FromBody] string value)
//        {
//        }

//        // PUT api/<UserController>/5
//        [HttpPut("{id}")]
//        public void Put(int id, [FromBody] string value)
//        {
//        }

//        // DELETE api/<UserController>/5
//        [HttpDelete("{id}")]
//        public void Delete(int id)
//        {
//        }
//    }
//}
