using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DAL.Models.Entities
{
    public class OrderInfo
    {
        public int ID { get; set; }
        public string TypeOfItem { get; set; } = string.Empty;

        public float ItemWeightKG { get; set; }

        public int NumberOfItem { get; set; }

        public string OrderNote { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public string WayBillStatus { get; set; } = string.Empty;


        public float BillingAmount { get; set; }


        public float BillingFeeInKG { get;set; }


        public string BillingStatus { get; set; } =string.Empty;

        public string PaymentMethod { get; set; } = string.Empty;

        public SenderInfo SenderInfo { get; set; } 

        [ForeignKey(nameof(SenderInfo))]
        public int SenderId { get; set;}

        
        public  ReceiverInfo ReceiverInfo { get; set; }

        [ForeignKey(nameof(ReceiverInfo))]
        public int ReceiverId { get; set;}

       public AbnormalOrder? AbnormalOrder { get; set; } //? mean that can by null value 















    }
}
