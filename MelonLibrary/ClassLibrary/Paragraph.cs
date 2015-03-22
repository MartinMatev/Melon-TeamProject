using System;

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
                    throw new NullReferenceException();
                }

                this.text = value;
            }
        }
    }
}
