using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class APIHelper : HelperBase
    {
        public APIHelper(ApplicationManager manager) : base(manager) { }

        public List<ProjectData> GetProjectsList(AccountData account)
        {
            List<ProjectData> projects = new List<ProjectData>();
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData[] mantisProjects = client.mc_projects_get_user_accessible(account.Name, account.Password);
            foreach(Mantis.ProjectData mantisProject in mantisProjects)
            {
                projects.Add(new ProjectData() { Name = mantisProject.name });
            }

            return projects;
        }

        public void CreateProject(AccountData account, ProjectData projectData)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            client.mc_project_add(account.Name, account.Password, new Mantis.ProjectData() { name = projectData.Name });
        }

        public bool IfProjectExist(AccountData account)
        {
            return (GetProjectsList(account).Count() > 0);
        }
    }
}
