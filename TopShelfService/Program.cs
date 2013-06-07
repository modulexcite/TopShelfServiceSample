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
                                    x.Service<TownCrier> (s =>
                                        {
                                            s.ConstructUsing(name => new TownCrier());
                                            s.WhenStarted(tc => tc.Start());
                                            s.WhenStopped(tc => tc.Stop());
                                        });
                                    x.RunAsLocalSystem();
                                    x.SetDescription("Sample Topshelf Host");
                                    x.SetDisplayName("Stuff");
                                    x.SetServiceName("Stuff");
                                    x.UseLog4Net();
                                });
        }
    }
}
