using System.Linq;
using System.Collections.Generic;
using INOM.Entities.Services.Parameters.Dto.Instrument;
using System;
using INOM.Entities.Services.Parameters.Dto.InstrumentMarket;

namespace INOM.Entities.Services.Parameters
{
    public static class Process
    {
        /// <summary>
        /// Get list InstrumentFamily and InstrumentFamilyPend by ID 
        /// </summary>
        /// <param name="instrumentFamilyID"></param>
        /// <returns></returns>
        public static List<InstrumentFamilyDto> GetInstrumentFamily(int id)
        {
            var instrumentList = new List<InstrumentFamilyDto>();

            using (var db = new DBContext())
            {

                var modelVigency = (from instFamily in db.InstrumentFamilies
                                    where instFamily.InstrumentFamilyID == id
                                    select new InstrumentFamilyDto
                                    {
                                        InstrumentFamilyID = instFamily.InstrumentFamilyID,
                                        MandatoryMarket = instFamily.MandatoryMarket,
                                        MandatoryMarketID = instFamily.MandatoryMarketID,
                                        ModifiedDateTime = instFamily.ModifiedDateTime,
                                        ModifiedUser = instFamily.ModifiedUser,
                                        Name = instFamily.Name,
                                        SettlementTerm120hs = instFamily.SettlementTerm120hs,
                                        SettlementTerm24hs = instFamily.SettlementTerm24hs,
                                        SettlementTerm48hs = instFamily.SettlementTerm48hs,
                                        SettlementTerm72hs = instFamily.SettlementTerm72hs,
                                        SettlementTerm96hs = instFamily.SettlementTerm96hs,
                                        SettlementTermCash = instFamily.SettlementTermCash,
                                        SetupDateTime = instFamily.SetupDateTime,
                                        SetupUser = instFamily.SetupUser,
                                        SuggestedMarket = instFamily.SuggestedMarket,
                                        SuggestedMarketID = instFamily.SuggestedMarketID,
                                        VerifiedDateTime = instFamily.VerifiedDateTime,
                                        VerifiedUser = instFamily.VerifiedUser,
                                        InstrumentFamilyMarkets = (from ins in db.InstrumentFamilyMarkets
                                                                   where ins.InstrumentFamilyID == instFamily.InstrumentFamilyID
                                                                   select new InstrumentFamilyMarketDto
                                                                   {
                                                                       Enabled = ins.Enabled,
                                                                       Market = (from mk in db.Markets
                                                                                 where mk.MarketID == ins.MarketID
                                                                                 select mk.Name).FirstOrDefault(),
                                                                       MarketID = ins.MarketID

                                                                   }).ToList()
                                    }).FirstOrDefault();

                if (modelVigency != null)
                    instrumentList.Add(modelVigency);


                var modelPending = (from instFamily in db.InstrumentFamiliesPend
                                    where instFamily.InstrumentFamilyID == id
                                    select new InstrumentFamilyDto
                                    {
                                        InstrumentFamilyID = instFamily.InstrumentFamilyID,
                                        MandatoryMarket = instFamily.MandatoryMarket,
                                        MandatoryMarketID = instFamily.MandatoryMarketID,
                                        ModifiedDateTime = instFamily.ModifiedDateTime,
                                        ModifiedUser = instFamily.ModifiedUser,
                                        Name = instFamily.Name,
                                        SettlementTerm120hs = instFamily.SettlementTerm120hs,
                                        SettlementTerm24hs = instFamily.SettlementTerm24hs,
                                        SettlementTerm48hs = instFamily.SettlementTerm48hs,
                                        SettlementTerm72hs = instFamily.SettlementTerm72hs,
                                        SettlementTerm96hs = instFamily.SettlementTerm96hs,
                                        SettlementTermCash = instFamily.SettlementTermCash,
                                        SetupDateTime = instFamily.SetupDateTime,
                                        SetupUser = instFamily.SetupUser,
                                        SuggestedMarket = instFamily.SuggestedMarket,
                                        SuggestedMarketID = instFamily.SuggestedMarketID,
                                        VerifiedDateTime = instFamily.VerifiedDateTime,
                                        VerifiedUser = instFamily.VerifiedUser,
                                        InstrumentFamilyMarkets = (from ins in db.InstrumentFamilyMarketsPend
                                                                   where ins.InstrumentFamilyID == instFamily.InstrumentFamilyID
                                                                   select new InstrumentFamilyMarketDto
                                                                   {
                                                                       Enabled = ins.Enabled,
                                                                       Market = (from mk in db.Markets
                                                                                 where mk.MarketID == ins.MarketID
                                                                                 select mk.Name).FirstOrDefault(),
                                                                       MarketID = ins.MarketID

                                                                   }).ToList()
                                    }).FirstOrDefault();

                if (modelPending != null)
                    instrumentList.Add(modelPending);

                return instrumentList;
            }
        }

        /// <summary>
        /// Get InstrumentMarket and InstrumentMarketPend by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<InstrumentMarketDto> GetInstrumentMarketByID(int id)
        {
            var instMarketList = new List<InstrumentMarketDto>();

            using (var db = new DBContext())
            {
                var modelVigency = (from model in db.InstrumentMarkets
                                    where model.InstrumentID == id
                                    select new InstrumentMarketDto
                                    {
                                        InstrumentID = model.InstrumentID,
                                        CVDescription = model.CVDescription,
                                        ModifiedDateTime = model.ModifiedDateTime,
                                        ModifiedUser = model.ModifiedUser,
                                        ProductCodeCV = model.ProductCodeCV,
                                        ProductCodeDtc = model.ProductCodeDtc,
                                        ProductCodeEuroclear = model.ProductCodeEuroclear,
                                        ProductCodeIsin = model.ProductCodeIsin,
                                        ProductCodeMae = model.ProductCodeMae,
                                        ProductCodeRic = model.ProductCodeRic,
                                        ProductCodeTicker = model.ProductCodeTicker,
                                        SetupDateTime = model.SetupDateTime,
                                        SetupUser = model.SetupUser,
                                        VerifiedDateTime = model.VerifiedDateTime,
                                        VerifiedUser = model.VerifiedUser,
                                        InstrumentMarkets = (from marketmarket in db.InstrumentMarketMarkets
                                                             where marketmarket.InstrumentID == model.InstrumentID
                                                             select new InstrumentMarketMarketDto
                                                             {
                                                                 MarketID = marketmarket.MarketID,
                                                                 Enabled = marketmarket.Enabled,
                                                                 MarketName = (from m in db.Markets
                                                                               where m.MarketID == marketmarket.MarketID
                                                                               select m.Name).FirstOrDefault()
                                                             }).ToList()
                                    }).FirstOrDefault();

                if (modelVigency != null)
                    instMarketList.Add(modelVigency);

                var modelPending = (from model in db.InstrumentMarketsPend
                                    where model.InstrumentID == id
                                    select new InstrumentMarketDto
                                    {
                                        InstrumentID = model.InstrumentID,
                                        CVDescription = model.CVDescription,
                                        ModifiedDateTime = model.ModifiedDateTime,
                                        ModifiedUser = model.ModifiedUser,
                                        ProductCodeCV = model.ProductCodeCV,
                                        ProductCodeDtc = model.ProductCodeDtc,
                                        ProductCodeEuroclear = model.ProductCodeEuroclear,
                                        ProductCodeIsin = model.ProductCodeIsin,
                                        ProductCodeMae = model.ProductCodeMae,
                                        ProductCodeRic = model.ProductCodeRic,
                                        ProductCodeTicker = model.ProductCodeTicker,
                                        SetupDateTime = model.SetupDateTime,
                                        SetupUser = model.SetupUser,
                                        VerifiedDateTime = model.VerifiedDateTime,
                                        VerifiedUser = model.VerifiedUser,
                                        InstrumentMarkets = (from marketmarket in db.InstrumentMarketMarketsPend
                                                             where marketmarket.InstrumentID == model.InstrumentID
                                                             select new InstrumentMarketMarketDto
                                                             {
                                                                 MarketID = marketmarket.MarketID,
                                                                 Enabled = marketmarket.Enabled,
                                                                 MarketName = (from m in db.Markets
                                                                               where m.MarketID == marketmarket.MarketID
                                                                               select m.Name).FirstOrDefault()
                                                             }).ToList()
                                    }).FirstOrDefault();


                if (modelPending != null)
                    instMarketList.Add(modelPending);

            }

            return instMarketList;
        }

        public static void RejectInstrumentMarketChange(RejectParameter reject, InstrumentMarketPend instrumentPend, List<InstrumentMarketMarketPend> insMarketPend)
        {
            using (var context = new DBContext().Database.BeginTransaction())
            {
                try
                {
                    //Save reject
                    RejectParameter.Save(reject);
                    //Delete pending
                    InstrumentMarketPend.Delete(instrumentPend, insMarketPend);

                    context.Commit();
                }
                catch (Exception ex)
                {
                    context.Rollback();

                    throw ex;
                }
            }
        }

        public static void ApproveInstrumentMarketChange(InstrumentMarketApprovChangeDto approvChange)
        {
            using (var db = new DBContext())
            {
                using (var context = new DBContext().Database.BeginTransaction())
                {
                    try
                    {
                        //Save Hist
                        db.InstrumentMarketsHist.Add(approvChange.InstrumentMarketHistToSave);
                        db.SaveChanges();
                        db.InstrumentMarketMarketsHist.AddRange(approvChange.InstrumentMarketMarketsHistToSave);

                        //Delete vigency
                        db.InstrumentMarketMarkets.RemoveRange(approvChange.InstrumentMarketMarketsToDelete);
                        db.InstrumentMarkets.Remove(approvChange.InstrumentMarketToDelete);

                        //Save Vigency
                        db.InstrumentMarkets.Add(approvChange.InstrumentMarketNewToSave);
                        db.InstrumentMarketMarkets.AddRange(approvChange.InstrumentMarketMarketsNewToSave);

                        db.SaveChanges();

                        //Delete pending
                        db.InstrumentMarketMarketsPend.RemoveRange(approvChange.InstrumentMarketMarketsPendToDelete);
                        db.SaveChanges();
                        db.InstrumentMarketsPend.Remove(approvChange.InstrumentMarketPendToDelete);

                        //Save all change
                        db.SaveChanges();

                        context.Commit();
                    }
                    catch (Exception ex)
                    {
                        context.Rollback();

                        throw ex;
                    }
                }
            }
        }

        /// <summary>
        /// Approve change InstrumentFamily
        /// </summary>
        /// <param name="approvChange"></param>
        public static void ApproveInstrumentFamilyChange(InstrumentFamilyApprovChangeDto approvChange)
        {
            using (var db = new DBContext())
            {
                using (var context = new DBContext().Database.BeginTransaction())
                {
                    try
                    {
                        //Save Hist
                        db.InstrumentFamiliesHist.Add(approvChange.InstrumentFamilyHistToSave);
                        db.InstrumentFamilyMarketsHist.AddRange(approvChange.InstrumentMarketsHistToSave);

                        //Delete vigency
                        db.InstrumentFamilyMarkets.RemoveRange(approvChange.InstrumentMarketsToDelete);
                        db.InstrumentFamilies.Remove(approvChange.InstrumentFamilyToDelete);

                        //Save Vigency
                        db.InstrumentFamilies.Add(approvChange.InstrumentFamilyNewToSave);
                        db.InstrumentFamilyMarkets.AddRange(approvChange.InstrumentMarketsNewToSave);

                        db.SaveChanges();

                        //Delete pending
                        db.InstrumentFamilyMarketsPend.RemoveRange(approvChange.InstrumentMarketsPendToDelete);
                        db.SaveChanges();
                        db.InstrumentFamiliesPend.Remove(approvChange.InstrumentFamilyPendToDelete);

                        //Save all change
                        db.SaveChanges();

                        context.Commit();
                    }
                    catch (Exception ex)
                    {
                        context.Rollback();

                        throw ex;
                    }
                }
            }
        }

        /// <summary>
        /// Save reject instrumentFamily in generic table
        /// </summary>
        /// <param name="reject"></param>
        /// <param name="instrumentPend"></param>
        /// <param name="insMarketPend"></param>
        public static void RejectInstrumentFamilyChange(RejectParameter reject, InstrumentFamilyPend instrumentPend, List<InstrumentFamilyMarketPend> insMarketPend)
        {
            using (var context = new DBContext().Database.BeginTransaction())
            {
                try
                {
                    //Save reject
                    RejectParameter.Save(reject);
                    //Delete pending
                    InstrumentFamilyPend.Delete(instrumentPend, insMarketPend);

                    context.Commit();
                }
                catch (Exception ex)
                {
                    context.Rollback();

                    throw ex;
                }
            }
        }
    }
}
