using CMS.BL.DTO_s;
using CMS.BL.Service.SenderInfoService;
using CMS.BL.Service.SendEmailService;
using CMS.DAL.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SenderInfoController : ControllerBase
    {
        private readonly ISenderInfoService _ISenderInfoService;
        private readonly ISendEmailService _ISendEmailService;
        public SenderInfoController (ISenderInfoService ISenderInfoService, ISendEmailService ISendEmailService)
        {
            _ISenderInfoService= ISenderInfoService;
            _ISendEmailService = ISendEmailService;
        }
        [HttpPost]
        public async Task<ActionResult> MakeOrder(SenderInfoPostDto SenderDto, string ReceiverName, int ReceiverPhoneNumber, string ReceiverEmail, string ReceiverCountry,
           string ReceiverCity, string ReceiverRegion, string ReceiverStreet, string TypeOfItem, float ItemWeightKG, int NumberOfItem, string OrderNote)
        {
            

            await _ISenderInfoService.MakeOrder(SenderDto, ReceiverName, ReceiverPhoneNumber, ReceiverEmail, ReceiverCountry, ReceiverCity, ReceiverRegion,
                ReceiverStreet, TypeOfItem, ItemWeightKG, NumberOfItem, OrderNote);

         await   _ISendEmailService.SendEmailAsync(ReceiverEmail, "Confirmation Message", "Our courier will deliver the package to the provided address on or before the estimated delivery date." +
             " Please ensure someone is available to receive the shipment during the delivery window");

            await _ISendEmailService.SendEmailAsync(SenderDto.SenderEmail, "Confirmation Message ", "Please ensure that the package is securely packed and ready for pickup on the scheduled date. Our courier will arrive within the specified " +
                "time window to collect it.");

            return Ok("The order added success");
           

        }
    


    }
}
