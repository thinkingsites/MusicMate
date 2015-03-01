using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using MusicMate.Business.Models;

namespace MusicMate.Controllers
{
    public class LibraryController
    {   
        [Route("library")]
        public Song[] Get(int skip = 0, int take = 100)
        {
            return new Song[0];
        }


    }
}
