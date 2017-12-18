using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using MyDataCustomer.data;
using TimeSheetApp.data;
using TimeSheetApp.Utils;
using TimeSheetApp.ViewModel;
using MessageBox = System.Windows.Forms.MessageBox;
using Task = TimeSheetApp.data.Task;


namespace TimeSheetApp.Model
{
    public class ProjectService : IProjectService
    {
        public static TimeSheetDBEntities Context = new TimeSheetDBEntities();
        public AuxipressJumboPilotEntities Auxipress = new AuxipressJumboPilotEntities();
        private readonly TimeSheetDBEntities _data;

        public ProjectService()
        {
            _data = new TimeSheetDBEntities();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<Project> SearchProjects(string myfiltre)
        {
            try
            {
                var result = Context.Project.Where(u => u.ProjectName.Contains(myfiltre) || u.Description.Contains(myfiltre) || u.ModifiedBy.Contains(myfiltre) || u.CreatedBy.Contains(myfiltre) || u.CustomerName.Contains(myfiltre) || myfiltre.ToString().Equals("")).ToList();
                return result;
            }
            catch (Exception)
            {
                //  MessageBox.Show();
                return null;
            }
        }
        public List<Project> ListProjectList()
        {
            try
            {
                var projetListe = Context.Project.OrderBy(x => x.ProjectName).ToList();
                return projetListe;
            }
            catch (Exception)
            {
                return null;
            }
        }
        //tache dans le detailviewprojet
        public List<VProjectTask> ListTaskList()
        {
            try
            {
                var liste = Context.VProjectTask.Distinct().ToList();
                return liste;
            }
            catch (Exception)
            {
                // MessageBox.Show(e.ToString());
                return null;
            }
        }

        // Verification if task 

        public ProjectTask TaskExist(long myTaskId, long? myProjectId)
        {
            try
            {
                var myVerify = _data.ProjectTask.FirstOrDefault(t => t.TaskID == myTaskId && t.ProjectID == myProjectId);
                return myVerify;
            }
            catch (Exception)
            {

                return null;
            }
        }

        // verification if project
        public Project ProjectExist(string myProject)
        {
            try
            {
                var myVerify = _data.Project.FirstOrDefault(t => t.ProjectName.Equals(myProject));
                return myVerify;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public bool ProjecNameDetailExist(string myProject)
        {
            var myVerify = _data.Project.FirstOrDefault(t => t.ProjectName == myProject);
            return myVerify != null;
        }

        public Project IfMyProject(Project myProject)
        {
            try
            {
                var variable = _data.Project.FirstOrDefault(x => x.ProjectID == myProject.ProjectID);
                return variable;

            }
            catch (Exception)
            {
                
                throw;
            }
           
        }


        public List<Task> ListTacheToAdd()
        {
            try
            {
                //var liste = Context.Task.Distinct().ToList();
                var liste = Context.Task.Where(ta => ta.Active.Value).ToList();
                return liste;
            }
            catch (Exception)
            {
                // MessageBox.Show(e.ToString());
                return null;
            }
        }

        // PojectHistories
        public List<VProjectHistory> ListProjectHistory (long? myProjectName)
        {
            try
            {
                var historys = Context.VProjectHistory.Where(y => y.ProjectID == myProjectName).ToList();
                return historys;
            }
            catch (Exception)
            {
                // MessageBox.Show(e.ToString());
                return null;
            }
        }

        // Customer 

        public List<VCustomers> MyCustomersList()
        {
            try
            {
                var custom = Auxipress.VCustomers.OrderBy(cu => cu.Customername).ToList();
                return custom;
            }
            catch (Exception)
            {
                //MessageBox.Show(e.ToString());
                return null;
            }
        }

        public List<VCustomers> SearchClient(string myClient)
        {
            try
            {

                var result = Auxipress.VCustomers.Where(u => u.Customername.Contains(myClient) || myClient.ToString().Equals("")).ToList();
                return result;
            }
            catch (Exception)
            {
                //  MessageBox.Show();
                return null;
            }
        }
        
        //ListTaskMinus
        public List<VProjectTask> ListTaskWhenProject(string projectName)
        {
            
            try
            {
                var lstProjectTask = Context.VProjectTask.Where(a => a.ProjectName.Equals(projectName)).ToList();
                return lstProjectTask;
            }
            catch (Exception )
            {
                return null;
            }
        }

        // Add new Project

        public void AddTaskToListToDo(long? projectToAddId, long taskToAddId)
        {
            try
            {
                ProjectTask addTaskTo = new ProjectTask()
                {
                    ProjectID = projectToAddId,
                    TaskID = taskToAddId
                };
                _data.ProjectTask.Add(addTaskTo);
                General.SaveContextChanges("Add a Task to Project :" + projectToAddId, _data);
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
                return;
            }

        }

        // Add to ProjectTaskUser
        public void AddTaskProjectUser(int projectToAddId, int taskToAddId)
        {
            try
            {
                ProjectTaskUser addTaskTo = new ProjectTaskUser()
                {
                    ProjectID = projectToAddId,
                    TaskID = taskToAddId
                };
                _data.ProjectTaskUser.Add(addTaskTo);
                General.SaveContextChanges("Add a Task to Project :" + projectToAddId, _data);
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
                return;
            }

        }

        // Remove to ProjectTask

        public void RemoovTaskToList(long? projectToRemovId, long? taskToremovId)
        {
            try
            {
                var removTaskSelecte =
                    _data.ProjectTask.FirstOrDefault(
                        tt => tt.ProjectID == projectToRemovId && tt.TaskID == taskToremovId);
                if (removTaskSelecte != null) _data.ProjectTask.Remove(removTaskSelecte);
                //_data.SaveChanges();
                General.SaveContextChanges("Remove a Task from Project : " + taskToremovId, _data);
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
                return;
            }
        }

        // Remove to ProjectTaskUser

        public void RemoveProjectTaskUser(int projectToRemovId, int taskToremovId)
        {
            try
            {
                var removTaskSelecte = _data.ProjectTaskUser.FirstOrDefault(tt => tt.ProjectID == projectToRemovId && tt.TaskID == taskToremovId);
                if (removTaskSelecte != null) _data.ProjectTaskUser.Remove(removTaskSelecte);
                //_data.SaveChanges();
                General.SaveContextChanges("Remove a Task from Project : " + taskToremovId, _data);
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
                return;
            }
        }

        // add project histories
        public bool AddProjectHistories(long projectId, float? lastime, float? newTime, DateTime? actionDate,
            string modificator)
        {
            try
            {
                ProjectHistory history = new ProjectHistory
                {
                    ProjectID = projectId,
                    LastTime = lastime,
                    NewTime = newTime,
                    ActionDate = DateTime.Now,
                    CreatedBy = Environment.UserName
                };
                _data.ProjectHistory.Add(history);
                General.SaveContextChanges("Get a project history : " + projectId, _data);
                return true;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
                return false;
            }
        }

        // Update duration project
        public void UpdateProject(Project update/*, long tesId*/)
        {
            try
            {
                _data.Project.AddOrUpdate(update);
                General.SaveContextChanges("Change estimate duration projocet :" + update, _data);


            }
            catch (Exception)
            {
                return;
            }
        }


        public void NewProjectAdd(string name, string descripetion, string client, DateTime? datedebut, float? estimate,
            string createur, DateTime creation)
        {
            try
            {
                Project addProject = new Project()
                {
                    ProjectName = name,
                    Description = descripetion,
                    CustomerName = client,
                    StartDate = datedebut,
                    EstimateDurationProject = estimate,
                    CreatedBy = createur,
                    CreationDate = creation
                };
                _data.Project.Add(addProject);
                General.SaveContextChanges("Add a new Project to list Project" + name, _data);
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return ;
            }
        }

        // Add CustomerName
        public void AddMyCustomerSelect(Project toAdd)
        {
            try
            {
                _data.Project.AddOrUpdate(toAdd);
                General.SaveContextChanges("Add customers :" + toAdd, _data);
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
                return;
            }

        }

        public void ChangeCustomer(Project toChange)
        {
            try
            {
                _data.Project.AddOrUpdate(toChange);
                General.SaveContextChanges("Update project :" + toChange, _data);
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
                throw;
            }
        }

        // Delete Project in Detail
        public bool DeleteProjectInDetail(long? myProject)
        {
            try
            {
                //¨project
                var selectProject = _data.Project.FirstOrDefault(p => p.ProjectID == myProject);
                if (selectProject != null) _data.Project.Remove(selectProject);

                //HitoryProject
                var selectProject1 = _data.ProjectHistory.FirstOrDefault(p => p.ProjectID == myProject);
                if (selectProject1 != null) _data.ProjectHistory.Remove(selectProject1);

                //ProjectTask
                var selectProject2 = _data.ProjectTask.FirstOrDefault(p => p.ProjectID == myProject);
                if (selectProject2 != null) _data.ProjectTask.Remove(selectProject2);

                //ProjectTaskUser
                var selectProject3 = _data.ProjectTaskUser.FirstOrDefault(p => p.ProjectID == myProject);
                if (selectProject3 != null) _data.ProjectTaskUser.Remove(selectProject3);

                General.SaveContextChanges("Delete Project's ID : " + myProject, _data);

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        // overdraw task related to the project

        public void DeleteTaskProject(long? projectId)
        {
            try
            {
                var testRequest1 = _data.ProjectTask.Where(pt => pt.ProjectID == projectId);
                foreach (var toDelete in testRequest1)
                {
                    _data.ProjectTask.Remove(toDelete);
                    General.SaveContextChanges("Dlete Task in ProjectTask " + projectId, _data);
                }
            }
            catch (Exception)
            {

                //return null;
            }
        }

        // orverdraw the history project related project
        public void DeleteHistoryProject(long? projectId)
        {
            try
            {
                var testRequest2 = _data.ProjectHistory.Where(pt => pt.ProjectID == projectId);
                foreach (var toDelete in testRequest2)
                {
                    _data.ProjectHistory.Remove(toDelete);
                    General.SaveContextChanges("Dlete Task in ProjectTask " + projectId, _data);
                }

            }
            catch (Exception)
            {

                //return null;
            }
        }

        // deletre relation project and user
        public void DeleteTaskUserProject(long? projectId)
        {
            try
            {
                var testRequest3 = _data.ProjectTaskUser.Where(pt => pt.ProjectID == projectId);

                foreach (var toDelete in testRequest3)
                {
                    _data.ProjectTaskUser.Remove(toDelete);
                    General.SaveContextChanges("Delete Task in ProjectTask " + projectId, _data);
                }

            }
            catch (Exception)
            {
                //return null;
            }
        }

        //Rename project

        public void RenameProject(Project project)
        {
            try
            {
                _data.Project.AddOrUpdate(project);
                General.SaveContextChanges("RenameProject : " + project, _data);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                //return null;
            }
        }

       

        public long? MaxProjectId()
        {
            long? maxId = _data.Project.Select(d => d.ProjectID).Max();
            return maxId;
        }

        // Validate ProjectName
        
    }
}
