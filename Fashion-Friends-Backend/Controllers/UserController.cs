using Fashion_Friends_Backend.Models;
using Fashion_Friends_Backend.Services.Abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fashion_Friends_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IAuthService authService;
        private readonly DataContext _context;


        public UserController(IAuthService authService, DataContext context)
        {
            this.authService = authService;
            _context = context;
        }

        [HttpPost("/api/UserControler/create")]
        public async Task<ActionResult<List<UserRegister>>> RegisterUser(UserRegister userRegister)
        {
            var user = await _context.users.FirstOrDefaultAsync(e => e.Email == userRegister.Email);
            if (user != null)
                return BadRequest("Vec postoji korisnik sa unetim mailom!");
            var newUser = new UserRegister
            {
                Name = userRegister.Name,
                Surname = userRegister.Surname,
                Email = userRegister.Email,
                Password = authService.HashPassword(userRegister.Password),
                Newsletter = userRegister.Newsletter
            };
            _context.users.Add(newUser);
            await _context.SaveChangesAsync();
            
            
            return Ok(authService.GetAuthData(newUser.Id));
        }

        [HttpPost("/api/UserControler/login")]
        public async Task<ActionResult<List<UserRegister>>> LoginUser(LoginData loginData)
        {
            var user = await _context.users.FirstOrDefaultAsync(e => e.Email == loginData.Email);
            if(user == null)
            {
                return BadRequest( new { email = "Korisnik nije registrovan!"});
            }

            var paswordValid = authService.VerifyPassword(loginData.Password, user.Password);
            if (!paswordValid)
            {
                return BadRequest(new { password = "Sifru koju ste uneli nije tacna!" });
            }

            return Ok(authService.GetAuthData(user.Id));
        }

        
    }
}
