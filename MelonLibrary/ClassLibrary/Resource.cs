namespace MelonLibrary
{
    public abstract class Resource : ProjectEntity, IResource
    {


        public ResourceType TypeResource { get; set; }
   

        public enum ResourceType
        {
            GitHubRepository,
            Screenshot,
            Paragraph,
            ExternalResource,
            GeneralProjectInfo
        }
    }
}
