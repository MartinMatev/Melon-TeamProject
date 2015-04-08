using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using MelonLibrary;
using iTextSharp.text;
using iTextSharp.text.pdf;
using MelonLibrary.ClassLibrary.Exceptions;
using Org.BouncyCastle.Crypto.Paddings;
using Paragraph = MelonLibrary.Paragraph;

namespace MelonDocumentationGenerator
{
    public class DocumentationGenerator
    {
        private List<IHuman> teamMembers;
        private List<Screenshot> screenshots;
        private List<IResource> resources;
        private List<IResource> usedResources;
        private List<ProjectParticipant> participants;
        private StylePattern stylePattern;
        private GeneralProjetctInfo generalInfo;
        private ProjectGit projectGitInfo;
        private Paragraph mainProjectDescription;
        private bool[] usedResourcesByID;
        private const string EmptyEntry = "not filled";

        public DocumentationGenerator()
        {
            this.screenshots = new List<Screenshot>();
            this.participants = new List<ProjectParticipant>();
            this.usedResources = new List<IResource>();
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
                    throw new NullFieldOrPropertyException(NullFieldOrPropertyException.ResourceListException);
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
                var part = new ProjectParticipant(fName, lName, uName, hasParticipated);

                this.teamMembers.Add(part);

                this.participants.Add(part);
            }
            else
            {
                this.teamMembers.Add(new TelerikTrainer(fName, lName, uName));
            }
            this.usedResourcesByID[(int)Resource.ResourceType.ProjectParticipant] = true;
        }

        public void CreateNewGeneralProjectInfo(string projectType, string nameTeam, string course, string projectName)
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
            var screenshot = new Screenshot(description, imagePath);
            this.resources.Add(screenshot);
            this.screenshots.Add(screenshot);
            this.usedResourcesByID[(int)Resource.ResourceType.Screenshot] = true;
        }

        public void AddResource(string name, string url)
        {
            this.resources.Add(new ExternalResource(name, url));
            this.usedResources.Add(new ExternalResource(name, url));
            this.usedResourcesByID[(int)Resource.ResourceType.ExternalResource] = true;
        }

        public void Export()
        {
            Document pdf = new Document(iTextSharp.text.PageSize.A4, 20, 20, 35, 35);
            PdfWriter writer = PdfWriter
                .GetInstance(pdf, new FileStream(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Test.pdf"),
                    FileMode.Create));

            pdf.Open();

            iTextSharp.text.Image imghead = iTextSharp.text.Image.GetInstance("../../Images/styleHeader.png");
            iTextSharp.text.Image imgSeparator = iTextSharp.text.Image.GetInstance("../../Images/imageSeparator.png");
            iTextSharp.text.Image separator = iTextSharp.text.Image.GetInstance("../../Images/separator.png");

            pdf.Add(imghead);
            pdf.Add(new iTextSharp.text.Paragraph(30, this.generalInfo.ProjectName, new Font(BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false), 40)));
            pdf.Add(new iTextSharp.text.Paragraph(30, "created by " + this.generalInfo.TeamName,
                new Font(BaseFont.CreateFont(), 20)));
            pdf.Add(new Chunk(string.Format(@"Course: {0}
", this.generalInfo.Course)));
            pdf.Add(new Chunk("Project repository:"));
            pdf.Add(new Chunk(this.projectGitInfo.ToString()));

            pdf.Add(separator);

            pdf.Add(new iTextSharp.text.Paragraph(10, "Description: ", new Font(BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false), 30)));
            pdf.Add(new iTextSharp.text.Paragraph(this.mainProjectDescription.Text, new Font(BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false), 14)));
            pdf.Add(separator);
            pdf.Add(new iTextSharp.text.Paragraph(15, "Used resources: ", new Font(BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false), 30)));
            foreach (var usedResource in this.usedResources)
            {
                pdf.Add(new Chunk((usedResource as ExternalResource).ToString()));
            }

            pdf.Add(separator);

            pdf.Add(new iTextSharp.text.Paragraph(30, "Project participants: ", new Font(BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false), 30)));
            foreach (var participant in this.participants)
            {
                pdf.Add(new Chunk(participant.ToString()));
            }
            pdf.Add(separator);

            pdf.Add(new iTextSharp.text.Paragraph(18, "Screenshots: ", new Font(BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false), 30)));
            foreach (var item in this.screenshots)
            {
                var paragraph = new iTextSharp.text.Paragraph(Environment.NewLine + item.Description);
                iTextSharp.text.Image pic = iTextSharp.text.Image.GetInstance(item.ImageFilePath);
                //Image pic = Image.GetInstance(item.ImageFilePath);
                if (pic.Height > pic.Width)
                {
                    float percentage = 0.0f;
                    percentage = 300 / pic.Height;
                    pic.ScalePercent(percentage * 100);
                }
                else
                {
                    float percentage = 0.0f;
                    percentage = 300 / pic.Width;
                    pic.ScalePercent(percentage * 100);
                }

                pic.Border = iTextSharp.text.Rectangle.BOX;
                pic.BorderColor = iTextSharp.text.BaseColor.BLACK;
                pic.BorderWidth = 2f;
                pdf.Add(paragraph);
                pdf.Add(pic);
            }

            //pdf.Add(imghead);

            //pdf.Add(new Paragraph(1, "string"));

            pdf.Close();



            MessageBox.Show("Done!");
        }
    }
}
