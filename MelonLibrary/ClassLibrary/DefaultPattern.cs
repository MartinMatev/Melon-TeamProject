using System;
using iTextSharp.text;
using iTextSharp.text.pdf;
using MelonLibrary.ClassLibrary.Enums;

namespace MelonLibrary
{
    public class DefaultPattern : StylePattern, IStylePattern
    {
        private static readonly Document PAGE_SIZE = new Document(iTextSharp.text.PageSize.A4);
        private static readonly Font FONT = new Font(BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false), 12, Font.NORMAL);
        private static readonly Image HEADER = Image.GetInstance(new Uri(System.IO.Path.GetFullPath("../../Images/Koala.jpg")));
        private const bool PAGE_NUMBER = true;

        public DefaultPattern()
            : base(FONT, PAGE_SIZE, HEADER, PAGE_NUMBER, PatternType.Default)
        {
        }
    }
}
