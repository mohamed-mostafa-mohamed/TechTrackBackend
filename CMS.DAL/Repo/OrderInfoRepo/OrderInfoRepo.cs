using CMS.DAL.Models.Data;
using CMS.DAL.Models.Entities;
using CMS.DAL.Repo.GenericRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DAL.Repo.OrderInfoRepo
{
    public class OrderInfoRepo : IGenericRepo<OrderInfo>, IOrderInfoRepo
    {
        private readonly ApplicationDbContext _context;


        public OrderInfoRepo(ApplicationDbContext context)
        {
            _context = context;

        }
        public async Task Add(OrderInfo entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(OrderInfo entity)
        {
            _context.OrderInfos.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrderInfo>> GetAll()
        {
            return await _context.Set<OrderInfo>()
          .Include(o => o.SenderInfo)
          .Include(o => o.ReceiverInfo)
          .ToListAsync();
        }

        public async Task<OrderInfo> GetById(int id)
        {
            return await _context.OrderInfos.SingleOrDefaultAsync(x => x.ID == id);
        }

        public async Task<IEnumerable<OrderInfo>> GetByOrderStatus(string status)
        {
            return await _context.OrderInfos.Where(x => x.Status == status).Include(o=>o.SenderInfo).Include(o=>o.ReceiverInfo).ToListAsync();
        }

        public async Task<IEnumerable<OrderInfo>> GetByWayBillStatus(string wayBillstatus)
        {
            return await _context.OrderInfos.Where(x => x.WayBillStatus == wayBillstatus).Include(o => o.SenderInfo).Include(o => o.ReceiverInfo).ToListAsync();
        }
    }
}
