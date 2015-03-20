using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MelonLibrary
{
    public class GeneralProjetctInfo : Resource, IResource
    {
        private string projectTypeInfo;
        private string teamName;
        private string course;
        private string projectName;

        public GeneralProjetctInfo(string projectTypeInfo, string _teamName, string course, string projectName,Resource.ResourceType typeResource)
        {
            base.TypeResource = typeResource;
            this.projectTypeInfo = projectTypeInfo;
            this.teamName = _teamName;
            this.course = course;
            this.projectName = projectName;
        }

        public string ProjectTypeInfo
        {
            get
            {
               return this.projectTypeInfo;
            }
            set 
            {
                this.projectTypeInfo = value;
            }
        }
        public string ProjectName
        {
            get
            {
                return this.projectName;
            }
            set
            {
                this.projectName = value;
            }
        }
     
        public string TeamName
        {
            get
            {
                return this.teamName;
            }
            set
            {
                this.teamName = value;
            }
        }
        public string Course
        {
            get
            {
                return this.course;
            }
            set
            {
                this.course = value;
            }
        }
    }
}
