using dotless.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace MusicMate.Controllers
{
    public class StaticController : BaseController
    {
        public ILessEngine LessEngine = new dotless.Core.EngineFactory().GetEngine();

        public HttpResponseMessage ServeStaticFile(string path)
        {
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            string mime,content = null;
            var extension = System.IO.Path.GetExtension(path);
            switch (extension)
            {
                case ".htm":
                case ".html":
                    mime = "text/html";
                    break;
                case ".css":
                case ".less":
                    mime = "text/css";
                    content = LessEngine.TransformToCss(null,path);
                    break;
                case ".js":
                    mime = "text/javascript";
                    break;
                default:
                    mime = "text/plain";
                    break;
            }

            if (mime == null)
            {
                content = File.ReadAllText(path);
            }

            result.Content = new StringContent(content);
            result.Content.Headers.ContentType = new MediaTypeHeaderValue(mime);
            return result;
        }
    }
}
