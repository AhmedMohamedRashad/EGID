using AutoMapper;
using RealTimeStock.BL.Entity;
using RealTimeStock.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeStock.BL.Mapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Stock,StockVM>();
            CreateMap<StockVM,Stock>();

            CreateMap<Order, OrderVM>()
                .ForMember(o => o.OrderTypeName, opt => opt.MapFrom(src => src.OrderType.Name));
            CreateMap<OrderVM, Order>();

            CreateMap<Order, CreateOrderVM>();
            CreateMap<CreateOrderVM, Order>();

            CreateMap<OrderType, OrderTypeVM>();
            CreateMap<OrderTypeVM, OrderType>();

            CreateMap<History, HistoryVM>();
            CreateMap<HistoryVM, History>();


        }
    }
}
