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
using dotless.Core.configuration;

namespace MusicMate.Controllers
{
    public class PublicFilesController : BaseController
    {
        public const string PublicRoot = "../../public";

        [Route("{*path}"),HttpGet]
        public HttpResponseMessage Get(string path)
        {
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            HttpContent content = null;

            if (String.IsNullOrWhiteSpace(path))
                path = "html/index.html";

            var segments = path.Split('/', '\\').ToList();
            segments.Insert(0, PublicRoot);
            path = Path.Combine(segments.ToArray());


            var extension = System.IO.Path.GetExtension(path);
            switch (extension)
            {
                case ".htm":
                case ".html":
                    content = GetStringContent(path,"text/html");
                    break;
                case ".css":
                case ".less":
                    content = GetStringContent(path, "text/css", dotless.Core.Less.Parse);
                    break;
                case ".js":
                    content = GetStringContent(path, "text/javascript");
                    break;
                case ".jpg":
                case ".jpeg":
                    content = GetBinaryContent(path, "image/jpg");
                    break;
                case ".png":
                    content = GetBinaryContent(path, "image/png");
                    break;
                case ".gif":
                    content = GetBinaryContent(path, "image/gif");
                    break;
                default:
                    content = GetStringContent(path, "text/plain");
                    break;
            }

            if (content == null)
            {
                result.StatusCode = HttpStatusCode.NotFound;
            }
            else
            {
                result.Content = content;
            }
            return result;
        }

        [Route("css"),HttpGet]
        public HttpResponseMessage Css(string f)
        {
            var sb = new StringBuilder();
            var files = f
                .Split(new [] { "," },StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.ToLower())              
                .Select(s => PublicRoot + "/css/" + s + ".css");
            foreach (var file in files)
            {
                if (File.Exists(file))
                    sb.AppendLine(File.ReadAllText(file));
            }

            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            result.Content = new StringContent(dotless.Core.Less.Parse(sb.ToString()));
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("text/css");
            return result;
        }

        public HttpContent GetStringContent(string path, string mime, Func<string, string> transform = null)
        {
            if (!File.Exists(path))
            {
                return null;
            }
            var content = File.ReadAllText(path);
            if (transform != null)
            {
                content = transform(content);
            }
            var result = new StringContent(content);
            result.Headers.ContentType = new MediaTypeHeaderValue(mime);
            return result;
        }

        public HttpContent GetBinaryContent(string path, string mime, Func<byte[], byte[]> transform = null)
        {
            if (!File.Exists(path))
            {
                return null;
            }
            var content = File.ReadAllBytes(path);
            if (transform != null)
            {
                content = transform(content);
            }
            var result = new StreamContent(new MemoryStream(content));
            result.Headers.ContentType = new MediaTypeHeaderValue(mime);
            return result;
        }
    }
}
