namespace MelonLibrary
{
    public class TelerikTrainee : TelerikHumanEntity, ITelerikHumanEntity, IHuman
    {
        public TelerikTrainee(string firstName, string lastName, string username)
            : base(firstName, lastName, username) 
        {
        }
    }
}
