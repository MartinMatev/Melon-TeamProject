using System;
using iTextSharp.text;
using iTextSharp.text.pdf;
using MelonLibrary.ClassLibrary.Enums;

namespace MelonLibrary
{
    public class MelonPattern : StylePattern, IStylePattern
    {
        private static readonly Document PAGE_SIZE = new Document(iTextSharp.text.PageSize.A4);
        private static readonly Font FONT = new Font(BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false), 12, Font.ITALIC);
        private static readonly Image HEADER = Image.GetInstance(new Uri(System.IO.Path.GetFullPath("../../Images/Melon_header.png")));
        private const bool PAGE_NUMBER = false;

        public MelonPattern()
            : base(FONT, PAGE_SIZE, HEADER, PAGE_NUMBER, PatternType.Melon)
        {           
        }
    }
}
