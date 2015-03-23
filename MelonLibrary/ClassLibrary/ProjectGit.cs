using System;

namespace MelonLibrary
{
    public class ProjectGit : Resource, IResource
    {
        private string repositoryName;
        private Uri gitUrl;

        public ProjectGit(string repositoryName, string repositoryUrl, Resource.ResourceType typeResource)
        {
            base.TypeResource = typeResource;
            this.repositoryName = repositoryName;
            this.Url = repositoryUrl;
        }

        public string RepositoryName
        {
            get
            {
                return this.repositoryName;
            }
            set
            {
                this.repositoryName = value;
            }
        }

        public string Url
        {
            get
            {
                return this.gitUrl.ToString();
            }
            set
            {
                this.gitUrl = new Uri(value);
            }
        }
    }
}
