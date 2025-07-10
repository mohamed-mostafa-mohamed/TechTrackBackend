using CMS.DAL.Models.Entities;
using CMS.DAL.Repo.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DAL.Repo.SenderInfoRepo
{
    public interface ISenderInfoRepo : IGenericRepo<SenderInfo>
    {
        public Task MakeOrder(SenderInfo sender, string ReceiverName, int ReceiverPhoneNumber, string ReceiverEmail, string ReceiverCountry,
            string ReceiverCity, string ReceiverRegion, string ReceiverStreet, string TypeOfItem, float ItemWeightKG, int NumberOfItem, string OrderNote);

       
    }

}
