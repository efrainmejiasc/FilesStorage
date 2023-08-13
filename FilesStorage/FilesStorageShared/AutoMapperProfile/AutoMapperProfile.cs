using AutoMapper;
using FilesStorageShared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesStorageShared.AutoMapperProfile
{
    public  class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
             CreateMap<UsuarioDTO, UserCredentialsDTO>().ReverseMap();
      
        }
    }
}
