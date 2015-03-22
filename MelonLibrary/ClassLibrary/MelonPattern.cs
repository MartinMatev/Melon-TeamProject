using iTextSharp.text;

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
