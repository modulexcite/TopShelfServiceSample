using Topshelf;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main()
        {
            //HostFactory.New(x => x.StartAutomatically());

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
                                });
        }
    }
}
