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
