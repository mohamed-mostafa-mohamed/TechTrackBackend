using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DAL.Models.Entities
{
    public class SenderInfo
    {
        [Key] public int SenderID { get; set; }

        public string SenderName { get; set; }
        public int SenderPhoneNumber { get; set; }

        public string SenderEmail { get; set; }


        public string SenderCountry { get; set; }

        public string SenderCity { get; set; }


        public string SenderRegion { get; set; }

        public string SenderStreet { get; set; }

       public ICollection<ReceiverInfo> Receivers { get; set; }=new HashSet<ReceiverInfo>();

        public ICollection<OrderInfo> OrderInfos { get; set; } = new HashSet<OrderInfo>();

















    }
}
