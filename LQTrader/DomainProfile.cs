﻿using AutoMapper;
using LatamQuants.PrimaryAPI.Models;
using System;

namespace LQTrader
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<LatamQuants.PrimaryAPI.Models.Instrument, ModelViews.Instrument>()
               .ForMember(dest => dest.CFICode, opt => opt.MapFrom(o => o.cficode))
               .ForMember(dest => dest.MarketID, opt => opt.MapFrom(o => o.instrumentId.marketId))
               .ForMember(dest => dest.Symbol, opt => opt.MapFrom(o => o.instrumentId.symbol));

            CreateMap<LatamQuants.PrimaryAPI.Models.InstrumentDetails, ModelViews.InstrumentDetail>()
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

            CreateMap<LatamQuants.PrimaryAPI.Models.Order, ModelViews.Order>()
               .ForMember(dest => dest.AccountID, opt => opt.MapFrom(o => o.accountId.id))
               .ForMember(dest => dest.AveragePrice, opt => opt.MapFrom(o => o.avgPx))
               .ForMember(dest => dest.ClientOrderID, opt => opt.MapFrom(o => o.clOrdId))
               .ForMember(dest => dest.CumulativeQuantity, opt => opt.MapFrom(o => o.cumQty))
               .ForMember(dest => dest.ExecutionID, opt => opt.MapFrom(o => o.execId))
               .ForMember(dest => dest.LastPrice, opt => opt.MapFrom(o => o.lastPx))
               .ForMember(dest => dest.LastQuantity, opt => opt.MapFrom(o => o.lastQty))
               .ForMember(dest => dest.LeavesQuantity, opt => opt.MapFrom(o => o.leavesQty))
               .ForMember(dest => dest.MarketID, opt => opt.MapFrom(o => o.instrumentId.marketId))
               .ForMember(dest => dest.Symbol, opt => opt.MapFrom(o => o.instrumentId.symbol))
               .ForMember(dest => dest.OrderID, opt => opt.MapFrom(o => o.orderId))
               .ForMember(dest => dest.Price, opt => opt.MapFrom(o => o.price))
               .ForMember(dest => dest.Proprietary, opt => opt.MapFrom(o => o.proprietary))
               .ForMember(dest => dest.Quantity, opt => opt.MapFrom(o => o.orderQty))
               .ForMember(dest => dest.Side, opt => opt.MapFrom(o => o.side))
               .ForMember(dest => dest.Status, opt => opt.MapFrom(o => o.status))
               .ForMember(dest => dest.Text, opt => opt.MapFrom(o => o.text))
               .ForMember(dest => dest.TimeInForce, opt => opt.MapFrom(o => o.timeInForce))
               .ForMember(dest => dest.TransactionTime, opt => opt.MapFrom(o => o.transactTime))
               .ForMember(dest => dest.Type, opt => opt.MapFrom(o => o.ordType))
               .ForMember(dest => dest.CancelClientOrderID, opt => opt.Ignore())
               .ForMember(dest => dest.DisplayQuantity, opt => opt.MapFrom(o => o.displayQty))
               .ForMember(dest => dest.ExpireDate, opt => opt.MapFrom(o => o.expireDate))
               .ForMember(dest => dest.Iceberg, opt => opt.MapFrom(o => o.iceberg))
               .ForMember(dest => dest.ReplaceClientOrderID, opt => opt.Ignore())
               .ForMember(dest => dest.OriginalClientOrderID, opt => opt.MapFrom(o => o.origClOrdId));

            CreateMap<ModelViews.Order, LatamQuants.PrimaryAPI.Models.newSingleOrderRequest>()
                .ForMember(dest => dest.account, opt => opt.MapFrom(o => o.AccountID))
                .ForMember(dest => dest.cancelPrevious, opt => opt.Ignore())
                .ForMember(dest => dest.displayQty, opt => opt.MapFrom(o => o.DisplayQuantity))
                .ForMember(dest => dest.expireDate, opt => opt.MapFrom(o => o.ExpireDate))
                .ForMember(dest => dest.iceberg, opt => opt.MapFrom(o => o.Iceberg))
                .ForMember(dest => dest.orderQty, opt => opt.MapFrom(o => o.Quantity))
                .ForMember(dest => dest.ordType, opt => opt.MapFrom(o => o.Type))
                .ForMember(dest => dest.price, opt => opt.MapFrom(o => o.Price))
                .ForMember(dest => dest.side, opt => opt.MapFrom(o => o.Side))
                .ForMember(dest => dest.timeInForce, opt => opt.MapFrom(o => o.TimeInForce))
                .ForPath(dest => dest.instrumentId.marketId, opt => opt.MapFrom(o => o.MarketID))
                .ForPath(dest => dest.instrumentId.symbol, opt => opt.MapFrom(o => o.Symbol));

            CreateMap<LatamQuants.PrimaryAPI.Models.MarketDataRT, ModelViews.MarketDataRT.MarketDataItem>()
                .ForMember(dest => dest.Price, opt => opt.MapFrom(o => o.price))
                .ForMember(dest => dest.Size, opt => opt.MapFrom(o => o.size))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(o => String.IsNullOrEmpty(o.date) ? "" : (new System.DateTime(1970, 1, 1, 0, 0, 0, 0)).AddMilliseconds(Convert.ToDouble(o.date)).ToString()))
                .ForMember(dest => dest.Name, opt => opt.Ignore());

            CreateMap<LatamQuants.PrimaryAPI.Models.Trade, ModelViews.MarketDataHistoric>()
                .ForMember(dest => dest.Symbol, opt => opt.MapFrom(o => o.symbol))
                //.ForMember(dest => dest.DateTime, opt => opt.MapFrom(o => (new System.DateTime(1970, 1, 1, 0, 0, 0, 0)).AddMilliseconds(Convert.ToDouble(o.servertime))))
                .ForMember(dest => dest.DateTime, opt => opt.MapFrom(o => o.datetime))
                .ForMember(dest => dest.Size, opt => opt.MapFrom(o => o.size));

            CreateMap<LatamQuants.PrimaryAPI.Models.getAccountPositionsResponse.Position, ModelViews.Position>()
                .ForMember(dest => dest.BuyPrice, opt => opt.MapFrom(o => o.buyPrice))
                .ForMember(dest => dest.BuySize, opt => opt.MapFrom(o => o.buySize))
                .ForMember(dest => dest.OriginalBuyPrice, opt => opt.MapFrom(o => o.originalBuyPrice))
                .ForMember(dest => dest.OriginalSellPrice, opt => opt.MapFrom(o => o.originalSellPrice))
                .ForMember(dest => dest.SellPrice, opt => opt.MapFrom(o => o.sellPrice))
                .ForMember(dest => dest.SellSize, opt => opt.MapFrom(o => o.sellSize))
                .ForMember(dest => dest.Symbol, opt => opt.MapFrom(o => o.symbol))
                .ForMember(dest => dest.SymbolReference, opt => opt.MapFrom(o => o.instrument.symbolReference))
                .ForMember(dest => dest.TotalDailyDiff, opt => opt.MapFrom(o => o.totalDailyDiff))
                .ForMember(dest => dest.TotalDiff, opt => opt.MapFrom(o => o.totalDiff));
        }
    }
}
