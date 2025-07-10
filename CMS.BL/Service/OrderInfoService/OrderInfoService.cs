using AutoMapper;
using CMS.BL.DTOs;
using CMS.DAL.Models.Entities;
using CMS.DAL.Repo.OrderInfoRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CMS.BL.Service.OrderInfoService
{
    public class OrderInfoService:IOrderInfoService
    {
        private readonly IOrderInfoRepo _IOrderInfoRepo;
        private readonly IMapper _mapper;
        public OrderInfoService(IOrderInfoRepo IOrderInfoRepo, IMapper mapper) 
        {
            _IOrderInfoRepo= IOrderInfoRepo;
            _mapper = mapper;
        }


        public  async Task<IEnumerable<OrderInfoGetDto>> GetAll()
        {
            var result = await _IOrderInfoRepo.GetAll();
            return   _mapper.Map<IEnumerable<OrderInfoGetDto>>(result);
        }

        public async Task<IEnumerable<OrderInfoGetDto>> GetByOrderStatus(string status)
        {
            try
            {
                var result = await _IOrderInfoRepo.GetByOrderStatus(status);
                return _mapper.Map<IEnumerable<OrderInfoGetDto>>(result);
            }
            catch (Exception)
            {
                throw new Exception("An error occurred. Please try again later.");
            }
        }
        public async Task<IEnumerable<OrderInfoGetDto>> GetByWayBillStatus(string wayBillstatus)
        {
            try
            {
                var result = await _IOrderInfoRepo.GetByWayBillStatus(wayBillstatus);
                return _mapper.Map<IEnumerable<OrderInfoGetDto>>(result);
            }
            catch (Exception)
            {
                throw new Exception("An error occurred. Please try again later.");
            }
        }


    }
}
