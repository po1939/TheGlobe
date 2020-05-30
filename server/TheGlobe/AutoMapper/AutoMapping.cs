using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;


namespace TheGlobeServer.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            //CreateMap<User, UserDTO>(); // means you want to map from User to UserDTO
        }
    }
}
