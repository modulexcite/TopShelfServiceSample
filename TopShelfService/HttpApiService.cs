using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace TopShelfService
{
    class HttpApiService
    // http://www.piotrwalat.net/hosting-web-api-in-windows-service/
    {
        private readonly TownCrier _townCrier = new TownCrier();
        private readonly log4net.ILog _log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType); 
        private readonly HttpSelfHostServer _server;
        private readonly HttpSelfHostConfiguration _config;
        private readonly string _webApiPortConfig = ConfigurationManager.AppSettings.Get("WebApiPort");
        private readonly Uri _serverUri;
        
        public HttpApiService()
        {
           _serverUri = BuildServerUri(_webApiPortConfig);
            _log.InfoFormat(String.Format("Creating server at {0}",_serverUri.ToString()));
            _config = new HttpSelfHostConfiguration(_serverUri);
            _config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new {id = RouteParameter.Optional }
            );
            _server = new HttpSelfHostServer(_config);
        }

        public void Start()
        {
            _log.InfoFormat("Opening HttpApiService Server ");
            _server.OpenAsync();
            _log.InfoFormat("Starting Town Crier");
            _townCrier.Start();
        }

        public void Stop()
        {
            _log.InfoFormat("Stopping Town Crier");
            _townCrier.Stop();
            _log.InfoFormat("Closing HttpApiService Server");
            _server.CloseAsync().Wait();
            _server.Dispose();
        }

        Uri BuildServerUri(string port)
        {
            string webApiPort = port;
            int webApiPortAsInt;
            if (Int32.TryParse(port, out webApiPortAsInt) && webApiPortAsInt >= 0 && webApiPortAsInt < 65535)
                _log.Info("WebApiPort Configured as Port " + webApiPort);
            else
            {
                webApiPort = "8080";
                _log.Info("WebApiPort Was Not Configured Correctly.  Default Value Of Port 8080 Is Being Used.");

            }
            return new Uri("http://localhost:" + webApiPort);
        }
    }
}
