
namespace MelonLibrary.ClassLibrary.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class NullFieldOrPropertyException: ApplicationException
    {
        public const string ResourceListException = "ResourceList Name cannot be Null or Empty";
        public const string TeamMembersListException = "TeamMembersList cannot be Null or Empty";
        public const string StylePatternException = "Style Pattern cannot be Null Or Empty";
        public const string InvalidResourceName = "Resource Name cannot be Null or Empty";
        public const string InvalidURLException = "Invalid URL";
        public const string InvalidDescriptionName = "Resource Name cannot be Null or Empty";
        public const string FontValueException = "Font Value cannot be Null";

        public NullFieldOrPropertyException(string msg) : base(msg)
        {
            
        }

        
    }
}
