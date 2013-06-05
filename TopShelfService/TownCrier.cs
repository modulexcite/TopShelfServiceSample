using System;
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
        private log4net.ILog _log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public TownCrier()
        {
            _timer = new Timer(1000) {AutoReset = true};
            _timer.Elapsed += (sender, eventArgs) => _log.Info("It is " + DateTime.Now.ToString() + " and all is well");
        }

        public void Start() {_timer.Start(); }

        public void Stop() {_timer.Stop(); }
    }
}
