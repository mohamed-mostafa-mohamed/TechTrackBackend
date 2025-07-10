using System;
using AutoMapper;
using CMS.BL.DTO_s;
using CMS.DAL.Models;
using CMS.BL.Mapping;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.DAL.Models.Entities;
using CMS.BL.DTOs;


namespace CMS.BL.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        { 
            CreateMap<SenderInfo, SenderInfoPostDto>().ReverseMap();
            CreateMap<OrderInfo, OrderInfoGetDto>()
                .ForMember(dest => dest.SenderName, opt => opt.MapFrom(src => src.SenderInfo.SenderName))
                .ForMember(dest => dest.ReceiverName, opt => opt.MapFrom(src => src.ReceiverInfo.ReceiverName)).ReverseMap();
        }



    }
}
