using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DAL.Models.Entities
{
    public class AbnormalOrder
    {
        public int Id { get; set; }
        public string Reasons { get; set; } = string.Empty;

        public string SubReasons { get; set; } = string.Empty;

        public string ImagePath { get; set; } = string.Empty;

        public OrderInfo? OrderInfo { get; set; }

        [ForeignKey(nameof(OrderInfo))]
        public int OrderId { get; set; }

    }
}
