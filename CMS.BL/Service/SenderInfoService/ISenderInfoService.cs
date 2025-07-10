using CMS.BL.DTO_s;
using CMS.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.BL.Service.SenderInfoService
{
    public interface ISenderInfoService
    {
        public Task MakeOrder(SenderInfoPostDto sender, string ReceiverName, int ReceiverPhoneNumber, string ReceiverEmail, string ReceiverCountry,
           string ReceiverCity, string ReceiverRegion, string ReceiverStreet, string TypeOfItem, float ItemWeightKG, int NumberOfItem, string OrderNote);

      

    }
}
