using AutoMapper;
using CMS.BL.DTO_s;
using CMS.DAL.Models.Entities;
using CMS.DAL.Repo.SenderInfoRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace CMS.BL.Service.SenderInfoService
{
    public class SenderInfoService: ISenderInfoService
    {
        private readonly ISenderInfoRepo _ISenderInfoRepo;
        private readonly IMapper _mapper;


        public SenderInfoService(ISenderInfoRepo ISenderInfoRepo , IMapper mapper) 
        {
            _ISenderInfoRepo= ISenderInfoRepo;
            _mapper= mapper;
        }

        public async Task MakeOrder(SenderInfoPostDto SenderDto, string ReceiverName, int ReceiverPhoneNumber, string ReceiverEmail, string ReceiverCountry,
   string ReceiverCity, string ReceiverRegion, string ReceiverStreet, string TypeOfItem, float ItemWeightKG, int NumberOfItem, string OrderNote)
        {
            //var SenderDb = new SenderInfo
            //{
            //    SenderName = SenderDto.SenderName,
            //    SenderPhoneNumber=SenderDto.SenderPhoneNumber,
            //    SenderEmail=SenderDto.SenderEmail,
            //    SenderCountry=SenderDto.SenderCountry,
            //    SenderCity=SenderDto.SenderCity,
            //    SenderRegion=SenderDto.SenderRegion,
            //    SenderStreet=SenderDto.SenderStreet


            //};
            try
            {

                var SenderDb = _mapper.Map<SenderInfo>(SenderDto);


                await _ISenderInfoRepo.MakeOrder(SenderDb, ReceiverName, ReceiverPhoneNumber, ReceiverEmail, ReceiverCountry, ReceiverCity,
                      ReceiverRegion, ReceiverStreet, TypeOfItem, ItemWeightKG, NumberOfItem, OrderNote);
            }

            catch (Exception)
            {
                throw new Exception("An error occurred while making the order. Please try again later.");
            }

        }

      

    }
}
