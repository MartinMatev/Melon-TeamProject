using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelonLibrary
{
    public interface IDocumentationGenerator
    {
        void AddNewTeamMember(string fName, string lName, string uName, string typeMember, bool hasParticipated);

        bool TeamMemberExist(string fName, string lName, string uName);

        bool GeneralProjectExist();

        void CreateNewGeneralProjectInfo(string projectType, string nameTeam, string course, string projectName);

        void EditGeneralProjectInfo(string projectType, string nameTeam, string course, string projectName);

        void CreateNewProjectGit(string repositoryName, string repositoryUrl);

        void SetStylePattern(string patternType);

        void ProjectDescriptionChanged(string textChanged);

        void AddScreenshot(string imagePath, string description);

        void AddResource(string name, string url);

        void Export(string savePath);

        bool GitUrlExist();

        void EditProjectGit(string repositoryName, string repositoryUrl);

        bool CheckAllResources();
    }
}
