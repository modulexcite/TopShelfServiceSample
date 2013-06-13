using System;
using System.Reflection;
using Topshelf;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "Log4Net.config", Watch = true)]
namespace TopShelfService
{
    class Program
    {
        static void Main()
        {
            log4net.ILog logger = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            logger.Info("Starting");
            HostFactory.Run(x =>
                                {
                                    x.Service<HttpApiService> (s =>
                                        {
                                            s.ConstructUsing(name => new HttpApiService());
                                            s.WhenStarted(tc => tc.Start());
                                            s.WhenStopped(tc => tc.Stop());
                                        });
                                    x.RunAsLocalSystem();
                                    x.SetDescription("Sample Web API Hosted By Topshelf");
                                    x.SetDisplayName("WebApiHostedByTopshelf");
                                    x.SetServiceName("WebApiHostedByTopshelf");
                                    x.UseLog4Net();
                                });
        }
    }
}
