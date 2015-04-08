using System;
using iTextSharp.text;
using MelonLibrary.ClassLibrary.Enums;
using MelonLibrary.ClassLibrary.Exceptions;

namespace MelonLibrary
{
    public abstract class StylePattern : ProjectEntity, IStylePattern
    {
        private Font font;
        private Document pageSize;
        private Image templateImage;
        private bool pageNumber;

        protected StylePattern(Font font, Document pageSize, Image template, bool pageNumber, PatternType patternType)
        {
            this.Font = font;
            this.PageSize = pageSize;
            this.TemplateImage = template;
            this.PageEnumeration = pageNumber;
            this.TypePattern = patternType;

        }

        public PatternType TypePattern { get; set; }

        public Font Font
        {
            get
            {
                return this.font;
            }
            set
            {

                if (value == null)
                {
                    throw new NullFieldOrPropertyException(NullFieldOrPropertyException.FontValueException);
                }

                this.font = value;
            }
        }

        public Document PageSize
        {
            get
            {
                return this.pageSize;
            }
            set
            {
                if (value == null)
                {
                    throw new NotSetFieldOrPropertyException(NotSetFieldOrPropertyException.PageSizeException);
                }

                this.pageSize = value;
            }
        }

        public Image TemplateImage
        {
            get
            {
                return this.templateImage;
            }
            set
            {
                if (value == null)
                {
                    throw new NotSetFieldOrPropertyException(NotSetFieldOrPropertyException.HeaderImageException);
                }

                this.templateImage = value;
            }
        }

        public bool PageEnumeration
        {
            get
            {
                return this.pageNumber;
            }
            set
            {
                this.pageNumber = value;
            }
        }
    }
}
