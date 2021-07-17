using AutoMapper;
using DatabaseManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace RESTAPIExample.MappingProfile
{
    class Mapping: Profile
    {
        public Mapping()
        {
            CreateMap<VMUser,Tbl_User>().ReverseMap();
            CreateMap<VMTask, Tbl_Task>().ReverseMap();
            CreateMap<VMUserResponse, Tbl_User>().ReverseMap();
        }
    }
}
