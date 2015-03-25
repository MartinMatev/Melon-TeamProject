using iTextSharp.text;
using iTextSharp.text.pdf;

namespace MelonLibrary
{
    public class DefaultPattern : StylePattern, IStylePattern
    {
        public DefaultPattern(Font font, Document pageSize, Image header, bool pageNumber, StylePattern.PatternType patternType)
            : base(font, pageSize, header, pageNumber, patternType)
        {
        }
    }
}
