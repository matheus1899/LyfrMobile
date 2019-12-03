using System;
using System.Collections.Generic;
using System.Text;
using VersFx.Formats.Text.Epub;

namespace Prototipo1_Lyfr.Models
{
    public class Capitulos
    {
        public string Title { get; set; }
        public List<EpubChapter> SubChapters { get; set; }
        public Type TargetType { get; set; }
    }
}
