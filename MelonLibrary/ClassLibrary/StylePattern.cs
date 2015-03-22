using System;
using iTextSharp.text;

namespace MelonLibrary
{
    public abstract class StylePattern : ProjectEntity, IStylePattern
    {
        protected Font font;
        protected PageSize pageSize;
        protected Image headerImage;
        protected bool pageNumber;

        public StylePattern(Font font, PageSize pageSize, Image header, bool pageNumber)
        {
            throw new NotFiniteNumberException();
        }

        public Font Font
        {
            get
            {
                throw new NotFiniteNumberException();
            }
            set
            {
                throw new NotFiniteNumberException();
            }
        }

        public PageSize PageSize
        {
            get
            {
                throw new NotFiniteNumberException();
            }
            set
            {
                throw new NotFiniteNumberException();
            }
        }

        public Image Header
        {
            get
            {
                throw new NotFiniteNumberException();
            }
            set
            {
                throw new NotFiniteNumberException();
            }
        }

        public bool PageEnumeration
        {
            get
            {
                throw new NotFiniteNumberException();
            }
            set
            {
                throw new NotFiniteNumberException();
            }
        }
    }
}
