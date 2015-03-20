using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MelonLibrary
{
    public class GeneralProjetctInfo : Resource, IResource
    {
        private string projectTypeInfo;
        private string nameTeam;
        private string course;
        private string projectName;

        public GeneralProjetctInfo(string projectTypeInfo, string nameTeam, string course, string projectName,Resource.ResourceType typeResource)
        {
            base.TypeResource = typeResource;
            this.projectTypeInfo = projectTypeInfo;
            this.nameTeam = nameTeam;
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
     
        public string NameTeam
        {
            get
            {
                return this.nameTeam;
            }
            set
            {
                this.nameTeam = value;
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
