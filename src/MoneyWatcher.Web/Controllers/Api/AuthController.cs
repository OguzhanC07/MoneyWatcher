using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoneyWatcher.Businness.Abstract;
using MoneyWatcher.Businness.DTOs.UserDTO;
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

        public AuthController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            registerDTO.Password = BCrypt.Net.BCrypt.HashPassword(registerDTO.Password);
            await _userService.AddAsync(_mapper.Map<User>(registerDTO));

            return Created("", registerDTO);
        }

        


        //[HttpPost]
        //public async Task<IActionResult> SignUp(RegisterModel registerModel)
        //{
        //    if (ModelState.IsValid)
        //    {

        //        BCrypt.Net.BCrypt.HashPassword(registerModel.Password);
        //        await _userService.AddAsync(new Entities.Concrete.User
        //        {
        //            Password = BCrypt.Net.BCrypt.HashPassword(registerModel.Password),
        //            Email = registerModel.Email,
        //            FullName = registerModel.FullName
        //        });
        //        return Created("", registerModel);
        //    }
        //    else
        //    {
        //        var errors = ModelState.Select(x => x.Value.Errors)
        //                   .Where(y => y.Count > 0)
        //                   .ToList();
        //        return BadRequest(errors);
        //    }

        //}
    }
}