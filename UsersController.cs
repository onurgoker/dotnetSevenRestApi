using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace MyMicroService
{
	[ApiController]
	[Route("api/user")]
	public class UsersController: ControllerBase
	{
		private readonly MyDbContext _dbContext;

		public UsersController(MyDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		[HttpGet]
        public async Task<IActionResult> GetUsers()
		{
            var users = _dbContext.Users.Take(100);

            return Ok(users);
		}

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsers(int id)
        {
            var customer = await _dbContext.FindAsync<User>(id);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }
    }
}

