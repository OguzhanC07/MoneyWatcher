using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoneyWatcher.Businness.Abstract;
using MoneyWatcher.Businness.JwtTools;
using MoneyWatcher.Businness.Utils.Dtos.UserDto;
using MoneyWatcher.Businness.Utils.ResponseMessage;
using MoneyWatcher.Entities.Concrete;

namespace MoneyWatcher.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IJwtService _jwtService;
        public AuthController(IUserService userService, IMapper mapper, IJwtService jwtService)
        {
            _userService = userService;
            _mapper = mapper;
            _jwtService = jwtService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var user = await _userService.FindUserByEmail(registerDto.Email);
            if (user != null) return Ok(ResponseCreater.CreateResponse(false, "Email is already taken", null));
            registerDto.Password = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);
            await _userService.AddAsync(_mapper.Map<User>(registerDto));
            return Ok(ResponseCreater.CreateResponse(true,"Added Succesfully",null));
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var user=await _userService.LoginValidate(loginDto);
            if (user == null) return Ok(ResponseCreater.CreateResponse(false, "Username or password is wrong", null));
            var token = _jwtService.GenerateToken(user);
            return Ok(ResponseCreater.CreateResponse(true,"Login Successfully",token));
        }
    }
}