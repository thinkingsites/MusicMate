using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MusicMate.Business
{
    public class Scanner
    {
        public static IEnumerable<string> AllDirectories(IEnumerable<string> dirs)
        {
            return dirs.SelectMany(s => Directory.EnumerateDirectories(s,"*", SearchOption.AllDirectories));
        }

        public static IEnumerable<string> AllFiles(IEnumerable<string> extensions,IEnumerable<string> dirs, bool subdirectories = true)
        {
            return dirs.SelectMany(d => extensions.SelectMany(e => Directory.EnumerateFiles(d, e, subdirectories ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly)));
        }
    }
}