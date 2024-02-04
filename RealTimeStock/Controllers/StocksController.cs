using AutoMapper;
using Demo.BL.Helper;
using Demo.BL.Interface;
using Demo.BL.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealTimeStock.BL.Entity;
using RealTimeStock.DAL.Entity;

namespace RealTimeStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly IStockRep stockRep;
        private readonly IMapper mapper;
        private readonly IHistoryRep historyRep;

        public StocksController(IStockRep stockRep,IMapper mapper,IHistoryRep historyRep)
        {
            this.stockRep = stockRep;
            this.mapper = mapper;
            this.historyRep = historyRep;
        }
        [HttpGet]
        [Route("GetStocks")]
        public async Task<IActionResult> GetStocks()
        {
            try
            {
                var data = await stockRep.GetAll();
                var result = mapper.Map<IEnumerable<StockVM>>(data);
                return Ok(new ApiResponse<IEnumerable<StockVM>>
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


        [HttpGet]
        [Route("GetHistoryBySymbol/{symbol}")]
        public async Task<IActionResult> GetHistoryBySymbol(string symbol)
        {
            try
            {
                var data = await historyRep.GetHistoryBySymbol(symbol);
                if (data == null)
                    throw new Exception(" this Symbol Not Exists");
                var result = mapper.Map<IEnumerable<HistoryVM>>(data);
                return Ok(new ApiResponse<IEnumerable<HistoryVM>>
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



        [HttpPut]
        [Route("UpdateStock")]
        public async Task<IActionResult> UpdateStock(StockVM obj)
        {
            try
            {
                var data = mapper.Map<Stock>(obj);
                await stockRep.Update(data);
                return Ok(new ApiResponse<string>
                {
                    Code = "202",
                    Status = "Accepted",
                    Message = "Stock Upadted",
                    Data = "Stock Upadted"
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
    }
}
