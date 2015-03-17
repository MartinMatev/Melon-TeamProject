using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }
}
