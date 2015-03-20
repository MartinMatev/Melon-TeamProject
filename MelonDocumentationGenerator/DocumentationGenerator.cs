using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MelonLibrary;

namespace MelonDocumentationGenerator
{
    public class DocumentationGenerator
    {
        private List<IResource> resources = new List<IResource>();

        public List<IResource> ListResources
        {
            get
            {
                return new List<IResource>(this.resources);
            }
            set
            {
                this.resources = value;
            }
        }

        public void CreateNewGeneralProjectInfo(string projectType,string nameTeam,string course,string projectName)
        {
            GeneralProjetctInfo newProject = new GeneralProjetctInfo(projectType,nameTeam,course,projectName,Resource.ResourceType.GeneralProjectInfo);
            this.ListResources.Add(newProject);           
        }
        public bool GeneralProjectExist()
        {
            if (this.ListResources.Exists(x => x.TypeResource == Resource.ResourceType.GeneralProjectInfo))
                return true;
            return false;
        }
        public void EditGeneralProjectInfo(string projectType, string nameTeam, string course, string projectName)
        {
            GeneralProjetctInfo genInfo = (GeneralProjetctInfo)this.resources.Find(x => x.TypeResource == Resource.ResourceType.GeneralProjectInfo);
            genInfo.NameTeam = nameTeam;
            genInfo.ProjectName = projectName;
            genInfo.ProjectTypeInfo = projectType;
            genInfo.Course = course;
        }
        
    }
}
