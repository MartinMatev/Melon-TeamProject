using System.Reflection;
using iTextSharp.text.pdf;

namespace MelonLibrary
{
    using System;
    using MelonLibrary.ClassLibrary.Exceptions;
    public class ExternalResource : Resource, IResource
    {
        private string resourceName;
        private Uri resourceUrl;

        public ExternalResource(string resourceName, string resourceUrl)
        {
            this.TypeResource = ResourceType.ExternalResource;
            this.ResourceName = resourceName;
            this.Url = resourceUrl;
        }

        public string ResourceName
        {
            get { return this.resourceName; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new NullFieldOrPropertyException(NullFieldOrPropertyException.ResourceListException);
                }

                this.resourceName = value;
            }
        }

        public string Url
        {
            get { return this.resourceUrl.AbsoluteUri; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new NullFieldOrPropertyException(NullFieldOrPropertyException.InvalidURLException);
                }

                this.resourceUrl = new Uri(value);
            }
        }

        public override string ToString()
        {
            return string.Format(@"
{0}
    {1}

", this.ResourceName, this.Url);
        }
    }
}
