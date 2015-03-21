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

        public Screenshot(string description, string imageFilePath)
            :this()
        {
            throw new System.NotFiniteNumberException();
        }

        public string Description
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

        public string ImageFilePath
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

        public Resource.ResourceType TypeResource
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}

