using System;
using MelonLibrary.ClassLibrary.Exceptions;

namespace MelonLibrary
{
    public class Paragraph : Resource, IResource
    {
        private string text;

        public Paragraph(string text)
        {
            this.TypeResource = ResourceType.Paragraph;
            this.Text = text;
        }

        public string Text
        {
            get
            {
                return this.text;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new NullFieldOrPropertyException(NullFieldOrPropertyException.ParagraphTextException);
                }

                this.text = value;
            }
        }
    }
}
