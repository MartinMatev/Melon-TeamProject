using iTextSharp.text;

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
