using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.BL.DTOs
{
    public class OrderInfoGetDto
    {
        
        public string SenderName { get; set; }= string.Empty;
        public string ReceiverName { get; set; } = string.Empty;
        public string TypeOfItem { get; set; } = string.Empty;

        public float ItemWeightKG { get; set; }

        public int NumberOfItem { get; set; }

        public string OrderNote { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;
        
        public string WayBillStatus { get; set; } = string.Empty;

    }
}
