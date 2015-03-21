using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MelonLibrary
{
    public class Paragraph : Resource, IResource
    {
        private string text;

        public Paragraph(string text)
        {
            this.TypeResource = Resource.ResourceType.Paragraph;
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
                    throw new System.NullReferenceException();
                }

                this.text = value;
            }
        }
    }
}
