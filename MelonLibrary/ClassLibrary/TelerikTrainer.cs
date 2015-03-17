using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MelonLibrary
{
    public class TelerikTrainer : TelerikHumanEntity, ITelerikHumanEntity, IHuman
    {
        public TelerikTrainer(string firstName, string lastName, string username)
            : base(firstName, lastName, username) 
        {
        }
    }
}
