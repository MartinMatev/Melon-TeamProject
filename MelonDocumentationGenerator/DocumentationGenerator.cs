using System;
using System.Collections.Generic;
using MelonLibrary;
using iTextSharp.text;
using iTextSharp.text.pdf;
using MelonLibrary.ClassLibrary.Exceptions;
using Paragraph = MelonLibrary.Paragraph;

namespace MelonDocumentationGenerator
{
    public class DocumentationGenerator
    {
        private List<IHuman> teamMembers;
        private List<IResource> resources;
        private StylePattern stylePattern;
        private GeneralProjetctInfo generalInfo;
        private ProjectGit projectGitInfo;
        private Paragraph mainProjectDescription;
        private bool[] usedResourcesByID;
        private const string EmptyEntry = "not filled";

        public DocumentationGenerator()
        {
            this.ResourceList = new List<IResource>();
            this.mainProjectDescription = new Paragraph(EmptyEntry);
            this.resources.Add(this.mainProjectDescription);
            this.TeamMembersList = new List<IHuman>();
            this.stylePattern = new DefaultPattern();
            this.usedResourcesByID = new bool[6];
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
                    throw  new NullFieldOrPropertyException(NullFieldOrPropertyException.ResourceListException);
                }

                this.resources = value;
            }
        }

        public List<IHuman> TeamMembersList
        {
            get
            {
                return new List<IHuman>(this.teamMembers);
            }
            set
            {
                if (value == null)
                {
                    throw new NullFieldOrPropertyException(NullFieldOrPropertyException.TeamMembersListException);
                }

                this.teamMembers = value;
            }
        }

        public StylePattern StylePattern
        {
            get
            {
                return this.stylePattern;
            }
            set
            {
                if (value == null)
                {
                    throw new NullFieldOrPropertyException(NullFieldOrPropertyException.StylePatternException);
                }

                this.stylePattern = value;
            }
        }
       
        public bool TeamMemberExist(string fName, string lName, string uName)
        {

            return this.TeamMembersList.Exists(x => (x.FirstName == fName) && (x.LastName == lName) && ((x as ITelerikHumanEntity).Username == uName));
        }

        public void AddNewTeamMember(string fName, string lName, string uName, string typeMember, bool hasParticipated)
        {

            if (typeMember.Equals("Trainee"))
            {
                this.teamMembers.Add(new ProjectParticipant(fName, lName, uName, hasParticipated));

            }
            else
            {
                this.teamMembers.Add(new TelerikTrainer(fName, lName, uName));
            }
            this.usedResourcesByID[(int)Resource.ResourceType.ProjectParticipant] = true;
        }

        public void CreateNewGeneralProjectInfo(string projectType,string nameTeam,string course,string projectName)
        {
            this.generalInfo = new GeneralProjetctInfo(projectType, nameTeam, course, projectName,
                Resource.ResourceType.GeneralProjectInfo);

            this.resources.Add(this.generalInfo);
            this.usedResourcesByID[(int)Resource.ResourceType.GeneralProjectInfo] = true;
        }

        public void CreateNewProjectGit(string repositoryName, string repositoryUrl)
        {
            this.projectGitInfo = new ProjectGit(repositoryName, repositoryUrl, Resource.ResourceType.GitHubRepository);

            this.resources.Add(this.projectGitInfo);
            this.usedResourcesByID[(int)Resource.ResourceType.GitHubRepository] = true;

        }

        public bool GeneralProjectExist()
        {
            return this.ResourceList.Exists(x => x.TypeResource == Resource.ResourceType.GeneralProjectInfo);

        }

        public bool GitUrlExist()
        {
            return this.ResourceList.Exists(x => x.TypeResource == Resource.ResourceType.GitHubRepository);

        }

        public void EditGeneralProjectInfo(string projectType, string nameTeam, string course, string projectName)
        {
            generalInfo.TeamName = nameTeam;
            generalInfo.ProjectName = projectName;
            generalInfo.ProjectTypeInfo = projectType;
            generalInfo.Course = course;
        }

        public void EditProjectGit(string repositoryName, string repositoryUrl)
        {
            projectGitInfo.RepositoryName = repositoryName;
            projectGitInfo.Url = repositoryUrl;
        }

        public void SetStylePattern(string patternType)
        {
            switch (patternType)
            {
                case "melon":
                    this.stylePattern = new MelonPattern();
                    break;
                default:
                    this.stylePattern = new DefaultPattern();
                    break;
            }
        }

        public void ProjectDescriptionChanged(string textChanged)
        {
            this.mainProjectDescription.Text = textChanged;
            this.usedResourcesByID[(int)Resource.ResourceType.Paragraph] = true;
        }

        public void AddScreenshot(string imagePath, string description)
        {
            this.resources.Add(new Screenshot(description, imagePath));
            this.usedResourcesByID[(int)Resource.ResourceType.Screenshot] = true;
        }

        public void AddResource(string name, string url)
        {
            this.resources.Add(new ExternalResource(name, url));
            this.usedResourcesByID[(int)Resource.ResourceType.ExternalResource] = true;
        }
    }
}
