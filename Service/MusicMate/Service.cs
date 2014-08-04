using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicMate
{
    public class Service
    {
        IDisposable webapp;

        public void Start()
        {
            WebApp.Start<WebApiConfiguration>("http://localhost:22555");
        }
        public void Stop()
        {
            webapp.Dispose();
        }
    }
}
