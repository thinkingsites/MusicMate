using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicMate.Business.Models
{
    public class Song
    {
        public string ID { get; set; }
        public string Location { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string Genre { get; set; }
        public int BPM { get; set; }
        public int TotalPlays { get; set; }
        public DateTime? LastPlayed { get; set; }
    }
}
