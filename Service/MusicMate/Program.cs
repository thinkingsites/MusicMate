using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using Topshelf.Hosts;
using Topshelf.HostConfigurators;
using Topshelf.Options;
using Topshelf.Runtime;
using Topshelf.ServiceConfigurators;

namespace MusicMate
{
    class Program
    {
        static void Main(string[] args)
        {
            Topshelf.HostFactory.Run(c => {
                c.SetDescription("A music manager, player, server, and sync.");
                c.SetDisplayName("MusicMate");
                c.SetServiceName("MusicMate");
                c.StartAutomatically();
                c.RunAsNetworkService();
                c.Service<Service>(Configure);
            });
        }

        static void Configure(ServiceConfigurator<Service> sc)
        {
            sc.ConstructUsing(x => new Service());
            sc.WhenStarted(x => x.Start());
            sc.WhenStopped(x => x.Stop());
        }
    }
}
