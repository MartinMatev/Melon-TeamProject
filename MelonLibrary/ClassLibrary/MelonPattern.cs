using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTextSharp.text;
using Image = iTextSharp.text.Image;

namespace MelonLibrary
{
    public class MelonPattern : StylePattern, IStylePattern
    {
        public MelonPattern(Font font, PageSize pageSize, Image header, bool pageNumber)
            :base(font, pageSize, header, pageNumber)
        {
        }
    }
}
