using System.Linq;
using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController(AppDbContext context) : ControllerBase
    {
        private readonly AppDbContext _context = context;

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _context.Users;
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok(user);
        }

        [HttpPost("login")]
        public IActionResult Login(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u =>
                u.Email == email && u.Password == password
            );
            if (user == null)
                return Unauthorized();
            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, User user)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.Id == id);
            if (existingUser == null)
                return NotFound();
            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;
            _context.SaveChanges();
            return Ok(existingUser);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
                return NotFound();
            _context.Users.Remove(user);
            _context.SaveChanges();
            return NoContent();
        }
    }

    [ApiController]
    [Route("api/profiles")]
    public class ProfilesController(AppDbContext context) : ControllerBase
    {
        private readonly AppDbContext _context = context;

        [HttpGet]
        public IActionResult GetProfiles()
        {
            var profiles = _context.Profiles;
            return Ok(profiles);
        }

        [HttpGet("{id}")]
        public IActionResult GetProfile(int id)
        {
            var profile = _context.Profiles.FirstOrDefault(p => p.Id == id);
            if (profile == null)
                return NotFound();
            return Ok(profile);
        }

        [HttpPost]
        public IActionResult CreateProfile(Profile profile)
        {
            _context.Profiles.Add(profile);
            _context.SaveChanges();
            return Ok(profile);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProfile(int id, Profile profile)
        {
            var existingProfile = _context.Profiles.FirstOrDefault(p => p.Id == id);
            if (existingProfile == null)
                return NotFound();
            existingProfile.Name = profile.Name;
            existingProfile.Email = profile.Email;
            existingProfile.Address = profile.Address;
            existingProfile.PhoneNumber = profile.PhoneNumber;
            existingProfile.DateOfBirth = profile.DateOfBirth;
            _context.SaveChanges();
            return Ok(existingProfile);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProfile(int id)
        {
            var profile = _context.Profiles.FirstOrDefault(p => p.Id == id);
            if (profile == null)
                return NotFound();
            _context.Profiles.Remove(profile);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
