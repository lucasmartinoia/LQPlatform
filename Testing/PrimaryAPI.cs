using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using PrimaryFixTester;

namespace Testing
{
    [TestClass]
    public class PrimaryAPI
    {
        [TestMethod]
        public void Init()
        {
            LogFiles log = new LogFiles();
            QFApplication _qf;

            if (!File.Exists("..\..\config\tradeclientbyma.cfg"))
            {
                Console.WriteLine("No existe el archivo de configuracion MD");
            }
            else
            if (_qf != null)
            {
                _qf.RegisterFormController(log.WriteLog);
                _qf.RegisterCboSecurityListData(UpdateCboSecurityList);
                _qf.RegisterCboMarketData(UpdateMarketData);
                _qf.RegisterDGV(UpdateFormDataDGV);

                _qf.Initiate(txtRutaConfigMD.Text, txtUsuarioMD.Text, txtPasswordMD.Text, true, this);
            }
        }
    }
}
