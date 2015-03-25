using iTextSharp.text;

namespace MelonLibrary
{
    public class MelonPattern : StylePattern, IStylePattern
    {
        public MelonPattern(Font font, Document pageSize, Image header, bool pageNumber, StylePattern.PatternType patternType)
            : base(font, pageSize, header, pageNumber, patternType)
        {
        }
    }
}
