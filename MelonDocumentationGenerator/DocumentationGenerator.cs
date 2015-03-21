using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MelonLibrary;

namespace MelonDocumentationGenerator
{
    public class DocumentationGenerator
    {
        private List<IResource> resources;
        private GeneralProjetctInfo generalInfo;
        private Paragraph mainProjectDescription;
        private const string EmptyEntry = "not filled";

        public DocumentationGenerator()
        {
            this.ResourceList = new List<IResource>();
            this.mainProjectDescription = new Paragraph(DocumentationGenerator.EmptyEntry);
            this.resources.Add(this.mainProjectDescription);
        }

        public List<IResource> ResourceList
        {
            get
            {
                return new List<IResource>(this.resources);
            }
            set
            {
                if (value == null)
                {
                    throw  new ArgumentNullException("Resources");
                }

                this.resources = value;
            }
        }

        public void CreateNewGeneralProjectInfo(string projectType,string nameTeam,string course,string projectName)
        {
            this.generalInfo = new GeneralProjetctInfo(projectType, nameTeam, course, projectName,
                Resource.ResourceType.GeneralProjectInfo);

            this.resources.Add(this.generalInfo);           
        }

        public bool GeneralProjectExist()
        {
            return this.ResourceList.Exists(x => x.TypeResource == Resource.ResourceType.GeneralProjectInfo);

        }

        public void EditGeneralProjectInfo(string projectType, string nameTeam, string course, string projectName)
        {
            generalInfo.TeamName = nameTeam;
            generalInfo.ProjectName = projectName;
            generalInfo.ProjectTypeInfo = projectType;
            generalInfo.Course = course;
        }

        public void ProjectDescriptionChanged(string textChanged)
        {
            this.mainProjectDescription.Text = textChanged;
        }
    }
}
