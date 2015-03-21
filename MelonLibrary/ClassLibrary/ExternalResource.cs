using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MelonLibrary
{
    public class ExternalResource : Resource, IResource
    {
        private string resourceName;
        private Uri resourceUrl;

        public ExternalResource(string resourceName, string resourceUrl)
        {
            this.TypeResource = Resource.ResourceType.ExternalResource;
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
                    throw new Exception();
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
                    throw new Exception();
                }

                this.resourceUrl = new Uri(value);
            }
        }
    }
}
