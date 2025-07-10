using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DAL.Models.Entities
{
    public class ReceiverInfo
    {

        [Key] public int ReceiverID { get; set; }
        public string ReceiverName { get; set; }=string.Empty;
        public int ReceiverPhoneNumber { get; set; }

        public string ReceiverEmail { get; set; } = string.Empty;


        public string ReceiverCountry { get; set; } = string.Empty;

        public string ReceiverCity { get; set; } = string.Empty;


        public string ReceiverRegion { get; set; } = string.Empty;

        public string ReceiverStreet { get; set; } = string.Empty;

        public ICollection<SenderInfo> Receivers { get; set; } = new HashSet<SenderInfo>();

        public ICollection<OrderInfo> OrderInfos { get; set; } = new HashSet<OrderInfo>();


    }
}
