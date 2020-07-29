using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data.DTOs;
using Data.Models;

namespace TheGlobeServer.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<AppUser, AppUserDto>(); 
            CreateMap<Book, BookDto>();
            CreateMap<BookTag, BookTagDto>();
            CreateMap<Chapter, ChapterDto>();
            CreateMap<Tag, TagDto>();

        }
    }
}
