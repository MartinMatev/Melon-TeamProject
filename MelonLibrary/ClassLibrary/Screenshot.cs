using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MelonLibrary
{
    public struct Screenshot : IResource
    {
        private string description;
        private string imageFilePath;
        private Resource.ResourceType resourceType;


        public Screenshot(string description, string imageFilePath)
            :this()
        {
            this.TypeResource = Resource.ResourceType.Screenshot;
            this.Description = description;
            this.ImageFilePath = imageFilePath;
        }

        public string Description
        {
            get { return this.description; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Description");
                }

                this.description = value;
            }
        }

        public string ImageFilePath
        {
            get { return this.imageFilePath; }
            set { this.imageFilePath = value; }
        }

        public Resource.ResourceType TypeResource
        {
            get { return this.resourceType; }
            set { this.resourceType = value; }
        }
    }
}

