using AutoMapper;
using LatamQuants.PrimaryAPI.Models;
using System;

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

            CreateMap<InstrumentDetails, ModelViews.InstrumentDetail>()
                .ForMember(dest => dest.CFICode, opt => opt.MapFrom(o => o.cficode))
                .ForMember(dest => dest.ContractMultiplier, opt => opt.MapFrom(o => o.contractMultiplier))
                .ForMember(dest => dest.Currency, opt => opt.MapFrom(o => o.currency))
                .ForMember(dest => dest.HighLimitPrice, opt => opt.MapFrom(o => o.highLimitPrice))
                .ForMember(dest => dest.InstrumentPricePrecision, opt => opt.MapFrom(o => o.instrumentPricePrecision))
                .ForMember(dest => dest.InstrumentSizePrecision, opt => opt.MapFrom(o => o.instrumentSizePrecision))
                .ForMember(dest => dest.LowLimitPrice, opt => opt.MapFrom(o => o.lowLimitPrice))
                .ForMember(dest => dest.MarketID, opt => opt.MapFrom(o => o.instrumentId.marketId))
                .ForMember(dest => dest.MaturityDate, opt => opt.MapFrom(o => DateTime.ParseExact(o.maturityDate,"yyyyMMdd",null)))
                .ForMember(dest => dest.MaxTradeVol, opt => opt.MapFrom(o => o.maxTradeVol))
                .ForMember(dest => dest.MinPriceIncrement, opt => opt.MapFrom(o => o.minPriceIncrement))
                .ForMember(dest => dest.MinTradeVol, opt => opt.MapFrom(o => o.minTradeVol))
                .ForMember(dest => dest.OrderTypes, opt => opt.MapFrom(o => o.orderTypes))
                .ForMember(dest => dest.PriceConvertionFactor, opt => opt.MapFrom(o => o.priceConvertionFactor))
                .ForMember(dest => dest.RoundLot, opt => opt.MapFrom(o => o.roundLot))
                .ForMember(dest => dest.SecurityType, opt => opt.MapFrom(o => o.securityType))
                .ForMember(dest => dest.SegmentID, opt => opt.MapFrom(o => o.segment.marketSegmentId))
                .ForMember(dest => dest.SettlementType, opt => opt.MapFrom(o => o.settlType))
                .ForMember(dest => dest.Symbol, opt => opt.MapFrom(o => o.instrumentId.symbol))
                .ForMember(dest => dest.TickSize, opt => opt.MapFrom(o => o.tickSize))
                .ForMember(dest => dest.TimesInForce, opt => opt.MapFrom(o => o.timesInForce));



            //CreateMap<InstructionFundsTransferFund, InstructionFundsAmendOrder>()
            //  .ForMember(dest => dest.InstructionID, opt => opt.Ignore())
            //  .ForMember(dest => dest.Orders, opt => opt.Ignore())
            //  .ForMember(dest => dest.ParentInstructionID, opt => opt.Ignore())
            //  .ForMember(dest => dest.ParentInstructionID, opt => opt.MapFrom(o => o.InstructionID))
            //  .ForMember(dest => dest.OrderID, opt => opt.Ignore());

        }
    }
}
