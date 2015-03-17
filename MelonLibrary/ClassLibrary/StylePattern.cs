using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTextSharp.text;
using Image = iTextSharp.text.Image;

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
            throw new System.NotFiniteNumberException();
        }

        public Font Font
        {
            get
            {
                throw new System.NotFiniteNumberException();
            }
            set
            {
                throw new System.NotFiniteNumberException();
            }
        }

        public PageSize PageSize
        {
            get
            {
                throw new System.NotFiniteNumberException();
            }
            set
            {
                throw new System.NotFiniteNumberException();
            }
        }

        public Image Header
        {
            get
            {
                throw new System.NotFiniteNumberException();
            }
            set
            {
                throw new System.NotFiniteNumberException();
            }
        }

        public bool PageEnumeration
        {
            get
            {
                throw new System.NotFiniteNumberException();
            }
            set
            {
                throw new System.NotFiniteNumberException();
            }
        }
    }
}
