using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTextSharp.text;
using Image = iTextSharp.text.Image;

namespace MelonLibrary
{
    public class DefaultPattern : StylePattern, IStylePattern
    {
        public DefaultPattern(Font font, PageSize pageSize, Image header, bool pageNumber)
            : base(font, pageSize, header, pageNumber)
        {
        }
    }
}
