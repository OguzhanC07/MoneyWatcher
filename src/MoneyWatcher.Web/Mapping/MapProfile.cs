using AutoMapper;
using MoneyWatcher.Businness.DTOs.UserDTO;
using MoneyWatcher.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyWatcher.Web.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<User, RegisterDTO>();
            CreateMap<RegisterDTO, User>();


        }
    }
}
