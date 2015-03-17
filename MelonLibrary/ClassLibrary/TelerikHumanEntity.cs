using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MelonLibrary
{
    public class TelerikHumanEntity : Human, ITelerikHumanEntity, IHuman
    {
        protected string username;

        public TelerikHumanEntity(string firstName, string lastName, string username)
            : base(firstName, lastName)
        {
            this.Username = username;
        }

        public string Username
        {
            get
            {
                return this.username;
            }
            set
            {
                this.username = value;
            }
        }
    }
}
