using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LatamQuants.PrimaryAPI;

namespace LQTrader.ModelViews
{
    class Instrument
    {
        public string MarketID { get; set; }
        public string Symbol { get; set; }
        public string CFICode { get; set; }

        public static List<Instrument> GetInstruments()
        {
            List<ModelViews.Instrument> colReturn = new List<ModelViews.Instrument>();

            List<LatamQuants.PrimaryAPI.Models.Instrument> colInstruments=RestAPI.GetInstruments().instruments;

            foreach(LatamQuants.PrimaryAPI.Models.Instrument oInstrument in colInstruments)
            {
                ModelViews.Instrument vInstrument = new Instrument();
                Service.mapper.Map<LatamQuants.PrimaryAPI.Models.Instrument, ModelViews.Instrument>(oInstrument, vInstrument);
                colReturn.Add(vInstrument);
            }

            return colReturn;
        }
    }
}
