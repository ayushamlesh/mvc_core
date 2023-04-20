using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Care.Controllers
{
    [ApiController]
    public class AuthController : Controller
    {
        //user register controller done
        public static User user=new User();
        private readonly IConfiguration configuration;

        //adding constructor here afer coming from the appsetting token

        public AuthController(IConfiguration configuration)
        {
            this.configuration = configuration;
            //go to  "require key" comment ans use it there
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>>Register(UserDto request)
        {
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user.Username=request.Username;
            user.PasswordHash=passwordHash;
            user.PasswordSalt=passwordSalt;
            return Ok(user);

    }

        [HttpPost("Login")]
        public async Task<ActionResult<string>>Login(UserDto request)
        {
            //check exists
            if (user.Username != request.Username)
            {
                return BadRequest("User not fornd");
            }
            if(!verifyPasswordHas(request.Password,user.PasswordHash,user.PasswordSalt))
            {
                return BadRequest("Password Incorrect");

            }
            //ctreating token
            string token = CreateToken(user);
            return Ok(token);
        }

        //token function
        private string CreateToken(User user)
        {
            //creating claims
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.Username)

            };

            //require key
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(this.configuration.GetSection("AppSettings:Token").Value));
            //add sceret key in the appsetting.json then from cunstrustor add in getBytes()

            //sigin credential new
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            //define the property or payload of the json web token
            var token = new JwtSecurityToken(
                //set stuff for claims
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials:creds
                ) ;

            //jwt token string that will retun
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            //return the token
            return jwt;
        }


    //create hash of password
    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        //ENCRYPT ALGORITHM
        using(var hmac=new HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }

        //verify password

        private bool verifyPasswordHas(string password,byte[] passwordHash,byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computeHash= hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                //verify bit by bit
                return computeHash.SequenceEqual(passwordHash);
            }

        }

    }
}
