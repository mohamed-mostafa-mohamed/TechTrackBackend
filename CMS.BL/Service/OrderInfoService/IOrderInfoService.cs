using CMS.BL.DTOs;
using CMS.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.BL.Service.OrderInfoService
{
    public interface IOrderInfoService
    {
        public Task<IEnumerable<OrderInfoGetDto>> GetAll();

        public Task<IEnumerable<OrderInfoGetDto>> GetByOrderStatus(string status);
        public Task<IEnumerable<OrderInfoGetDto>> GetByWayBillStatus(string wayBillstatus);


    }


}
