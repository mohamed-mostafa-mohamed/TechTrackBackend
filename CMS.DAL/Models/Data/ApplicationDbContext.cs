using CMS.DAL.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DAL.Models.Data
{
    public class ApplicationDbContext:DbContext
    {
        public  DbSet<SenderInfo> SenderInfos { get; set; }

        public DbSet<ReceiverInfo> ReceiverInfos { get; set; }

        public DbSet<OrderInfo> OrderInfos { get; set; }


        public DbSet<AbnormalOrder> AbnormalOrders { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }



    }
}
