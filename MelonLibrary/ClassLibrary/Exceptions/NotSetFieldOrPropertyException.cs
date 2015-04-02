namespace MelonLibrary.ClassLibrary.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class NotSetFieldOrPropertyException : ApplicationException
    {
        public string PageSizeException = "Page Size is not set";
        public string HeaderImageException = "Header Image is not set";

        public NotSetFieldOrPropertyException(string msg) : base(msg)
        {
            
        }
    }
}
