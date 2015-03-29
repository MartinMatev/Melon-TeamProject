namespace MelonLibrary
{
    public abstract class Resource : ProjectEntity, IResource
    {


        public ResourceType TypeResource { get; set; }


        public enum ResourceType
        {
            GeneralProjectInfo = 0,
            GitHubRepository = 1,
            ProjectParticipant = 2,
            Paragraph = 3,
            Screenshot = 4,
            ExternalResource = 5,

        }
    }
}
