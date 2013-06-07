using System;
using System.Configuration;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Timers;
using System.Threading.Tasks;


namespace TopShelfService
{
    public class TownCrier
    {
        private readonly log4net.ILog _log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType); 
        private readonly string _crierFrequencyConfig = ConfigurationManager.AppSettings.Get("CrierFrequency");
        private readonly double _crierFrequency;
        private readonly Timer _timer;

        public TownCrier()
        {
            if (Double.TryParse(_crierFrequencyConfig, out _crierFrequency))
                _log.Info("CrierFrequency Configured as " + _crierFrequency.ToString(CultureInfo.InvariantCulture) + " Seconds");
            else
            {
                _log.Info("CrierFrequency Was Not Configured Correctly.  Default Value Of 1 Second Is Being Used.");
                _crierFrequency = 1;
            }

            _timer = new Timer(_crierFrequency*1000) {AutoReset = true};
            _timer.Elapsed += (sender, eventArgs) => _log.Info("It is " + 
                DateTime.Now.ToString(CultureInfo.InvariantCulture) + " and all is well");
        }

        public void Start() {_timer.Start(); }

        public void Stop() {_timer.Stop(); }
    }
}
