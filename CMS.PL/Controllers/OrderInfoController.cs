using CMS.BL.DTOs;
using CMS.BL.Service.OrderInfoService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace CMS.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderInfoController : ControllerBase
    {
        private readonly IOrderInfoService _IOrderInfoService;
        public OrderInfoController(IOrderInfoService iOrderInfoService)
        {
            _IOrderInfoService = iOrderInfoService;
        }
        [HttpGet]
        public async Task<IEnumerable<OrderInfoGetDto>> GetAll()
        {
           return await _IOrderInfoService.GetAll();
        }
        [HttpGet("GetByOrderStatus")]
        public async Task<ActionResult<IEnumerable<OrderInfoGetDto>>> GetByOrderStatus(string status)
        {
            

          var result =  await _IOrderInfoService.GetByOrderStatus(status);
            if (result == null) return NotFound();
            return Ok(result);
           
        }
        [HttpGet("GetByWayBillStatus")]
        public async Task<ActionResult<IEnumerable<OrderInfoGetDto>>> GetByWillBayStatus(string wayBillstatus)
        {
            

            var result = await _IOrderInfoService.GetByWayBillStatus(wayBillstatus);
            if (result==null) return NotFound();
             return Ok(result);
        
        }


    }
}
