
using CMS.DAL.Models.Data;
using CMS.DAL.Models.Entities;
using CMS.DAL.Repo.GenericRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DAL.Repo.SenderInfoRepo
{
    public class SenderInfoRepo : ISenderInfoRepo, IGenericRepo<SenderInfo>
    {
        private readonly ApplicationDbContext _context;
        

        public SenderInfoRepo(ApplicationDbContext context )
        {
            _context = context;
            
        }
        public async Task Add(SenderInfo entity)
        {
          await  _context.AddAsync(entity);
          await  _context.SaveChangesAsync();
        }

        public async Task Delete(SenderInfo entity)
        {
            _context.SenderInfos.Remove(entity);
           await _context.SaveChangesAsync();
        }

        public async Task< IEnumerable<SenderInfo>> GetAll()
        {
            return await _context.Set<SenderInfo>().ToListAsync();
        }

        public async Task<SenderInfo> GetById(int id)
        {
            return await _context.SenderInfos.SingleOrDefaultAsync(x => x.SenderID == id);
        }

        public async Task MakeOrder(SenderInfo sender, string ReceiverName, int ReceiverPhoneNumber, string ReceiverEmail, string ReceiverCountry,
                              string ReceiverCity, string ReceiverRegion, string ReceiverStreet, string TypeOfItem, float ItemWeightKG, int NumberOfItem, string OrderNote)
        {
            
                await _context.AddAsync(sender);
                await _context.SaveChangesAsync();

                var receiver = new ReceiverInfo
                {
                    ReceiverCity = ReceiverCity,
                    ReceiverRegion = ReceiverRegion,
                    ReceiverName = ReceiverName,
                    ReceiverPhoneNumber = ReceiverPhoneNumber,
                    ReceiverEmail = ReceiverEmail,
                    ReceiverCountry = ReceiverCountry,
                    ReceiverStreet = ReceiverStreet
                };
                await _context.AddAsync(receiver);
                await _context.SaveChangesAsync();

                var order = new OrderInfo
                {
                    OrderNote = OrderNote,
                    TypeOfItem = TypeOfItem,
                    ItemWeightKG = ItemWeightKG,
                    NumberOfItem = NumberOfItem,
                    Status = "UnPrinted",
                    WayBillStatus = "InWay",
                    SenderId = sender.SenderID,
                    ReceiverId = receiver.ReceiverID
                };
                await _context.AddAsync(order);
                await _context.SaveChangesAsync();
            }
            
        
        


    }
}
