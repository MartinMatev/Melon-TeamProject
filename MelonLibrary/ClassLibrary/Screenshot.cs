using System;
using MelonLibrary.ClassLibrary.Exceptions;

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
                    throw new NullFieldOrPropertyException(NullFieldOrPropertyException.InvalidDescriptionName);
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

