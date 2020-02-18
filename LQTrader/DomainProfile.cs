using AutoMapper;
using LatamQuants.PrimaryAPI.Models;

namespace LQTrader
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Instrument, ModelViews.Instrument>()
               .ForMember(dest => dest.CFICode, opt => opt.MapFrom(o => o.cficode))
               .ForMember(dest => dest.MarketID, opt => opt.MapFrom(o => o.instrumentId.marketId))
               .ForMember(dest => dest.Symbol, opt => opt.MapFrom(o => o.instrumentId.symbol));

            //CreateMap<InstructionFundsTransferFund, InstructionFundsAmendOrder>()
            //  .ForMember(dest => dest.InstructionID, opt => opt.Ignore())
            //  .ForMember(dest => dest.Orders, opt => opt.Ignore())
            //  .ForMember(dest => dest.ParentInstructionID, opt => opt.Ignore())
            //  .ForMember(dest => dest.ParentInstructionID, opt => opt.MapFrom(o => o.InstructionID))
            //  .ForMember(dest => dest.OrderID, opt => opt.Ignore());

        }
    }
}
