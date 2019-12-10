using System;
using VersFx.Formats.Text.Epub;
using System.Collections.Generic;

namespace Prototipo1_Lyfr.Models
{
    public class Capitulos
    {
        public string Title { get; set; }
        public List<EpubChapter> SubChapters { get; set; }
        public Type TargetType { get; set; }
        public bool HasSubchapters { get; set; }
    }
}
