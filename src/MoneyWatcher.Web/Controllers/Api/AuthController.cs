using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoneyWatcher.Businness.Abstract;
using MoneyWatcher.Businness.DTOs.UserDTO;
using MoneyWatcher.Businness.JwtTools;
using MoneyWatcher.Entities.Concrete;
using MoneyWatcher.Web.Models;

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
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            registerDTO.Password = BCrypt.Net.BCrypt.HashPassword(registerDTO.Password);
            await _userService.AddAsync(_mapper.Map<User>(registerDTO));

            return Created("", registerDTO);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            var user=await _userService.LoginValidate(loginDTO);
            if (user != null)
            {
                var token = _jwtService.GenerateToken(user);

                return Ok(token);
            }
            else
            {
                return BadRequest(new { Message="Mail and Password Wrong."});
            }

        }



    }
}