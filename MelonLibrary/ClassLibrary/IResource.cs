using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MelonLibrary
{
    public interface IResource
    {
        Resource.ResourceType TypeResource { get; set; }
    }
}
