using CMS.DAL.Models.Entities;
using CMS.DAL.Repo.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DAL.Repo.OrderInfoRepo
{
    public interface IOrderInfoRepo : IGenericRepo<OrderInfo>
    {
        public Task<IEnumerable<OrderInfo>> GetByOrderStatus(string status);


        public Task<IEnumerable<OrderInfo>> GetByWayBillStatus(string wayBillstatus);

    }
}
