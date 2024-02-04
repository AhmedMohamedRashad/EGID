using AutoMapper;
using Demo.BL.Helper;
using Demo.BL.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealTimeStock.BL.Entity;
using RealTimeStock.DAL.Entity;

namespace RealTimeStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRep orderRep;
        private readonly IMapper mapper;

        public OrdersController(IOrderRep orderRep,IMapper mapper)
        {
            this.orderRep = orderRep;
            this.mapper = mapper;
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(CreateOrderVM obj)
        {
            try
            {
                var data = mapper.Map<Order>(obj);
                await orderRep.Create(data);
                return Ok(new ApiResponse<string>
                {
                    Code = "201",
                    Status = "Created",
                    Message = "Data Saved",
                    Data = "Created Successfully"
                });
            }
            catch (Exception ex)
            {

                return NotFound(new ApiResponse<string>
                {
                    Code = "400",
                    Status = "Bad Request",
                    Message = "Data Not found",
                    Data = ex.Message
                });
            }
        }

        [HttpGet]
        [Route("GetOrders")]
        public async Task<IActionResult> GetOrders()
        {
            try
            {
                var data = await orderRep.GetAll();
                var result = mapper.Map<IEnumerable<OrderVM>>(data);
                return Ok(new ApiResponse<IEnumerable<OrderVM>>
                {
                    Code = "200",
                    Message = "Data found",
                    Status = "Succeed",
                    Data = result
                });
            }
            catch (Exception ex)
            {

                return NotFound(new ApiResponse<string>
                {
                    Code = "404",
                    Message = "Data Not found",
                    Status = "Not Found",
                    Data = ex.Message
                });
            }


        }


    }
}
