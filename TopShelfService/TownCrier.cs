using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Timers;
using System.Threading.Tasks;


namespace TopShelfService
{
    public class TownCrier
    {
        private readonly Timer _timer;
        private readonly log4net.ILog _log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly string _crierFrequencyConfig = ConfigurationManager.AppSettings.Get("CrierFrequency");
        private readonly int _crierFrequency ;

        public TownCrier()
        {

            if (null != _crierFrequencyConfig)
            {
                _log.Info("CrierFrequency Configured as " + _crierFrequencyConfig);
                _crierFrequency = Convert.ToInt32(_crierFrequencyConfig)*1000;
            }
            else
            {
                _log.Info("CrierFrequency Was Not Configured.  Default Value Of 1 Is Used.");
                _crierFrequency = 1000;
            }


            _timer = new Timer(_crierFrequency) {AutoReset = true};
            _timer.Elapsed += (sender, eventArgs) => _log.Info("It is " + DateTime.Now.ToString() + " and all is well");
        }

        public void Start() {_timer.Start(); }

        public void Stop() {_timer.Stop(); }
    }
}
