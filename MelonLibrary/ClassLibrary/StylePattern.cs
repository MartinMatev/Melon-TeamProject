using System;
using iTextSharp.text;

namespace MelonLibrary
{
    public abstract class StylePattern : ProjectEntity, IStylePattern
    {
        protected Font font;
        protected Document pageSize;
        protected Image templateImage;
        protected bool pageNumber;

        public StylePattern(Font font, Document pageSize, Image template, bool pageNumber, StylePattern.PatternType patternType)
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
                    throw new ArgumentNullException("Font vaue cannot be null.");
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
                    throw new ArgumentNullException("Page size is not set");
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
                    throw new ArgumentNullException("Header image is not set");
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
                if (value == null)
                {
                    throw new ArgumentNullException("Page enumeration is not set");
                }

                this.pageNumber = value;
            }
        }

        public enum PatternType
        {
            Default,
            Melon
        }
    }
}
