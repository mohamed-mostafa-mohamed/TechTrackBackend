using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.BL.DTO_s
{
    public class SenderInfoPostDto
    {
        public string SenderName { get; set; }
        public int SenderPhoneNumber { get; set; }

        public string SenderEmail { get; set; }


        public string SenderCountry { get; set; }

        public string SenderCity { get; set; }


        public string SenderRegion { get; set; }

        public string SenderStreet { get; set; }

    }
}
