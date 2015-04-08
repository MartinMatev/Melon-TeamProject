namespace MelonLibrary
{
    public class ProjectParticipant : TelerikTrainer, ITelerikHumanEntity, IParticipant, IHuman
    {
        protected bool hasParticipated;

        public ProjectParticipant(string firstName, string lastName, string username, bool hasParticipated)
            : base(firstName, lastName, username) 
        {
            this.HasParticipated = hasParticipated;
        }

        public bool HasParticipated
        {
            get
            {
                return this.hasParticipated;
            }
            private set
            {
                this.hasParticipated = value;
            }
        }

        public override string ToString()
        {
            return string.Format(@"
{0} {1} ({2}) - {3}participated [{4}]
", this.FirstName, this.LastName, this.username, this.HasParticipated ? string.Empty : "NOT ",
                this.HasParticipated ? "V" : "X");
        }
    }
}
