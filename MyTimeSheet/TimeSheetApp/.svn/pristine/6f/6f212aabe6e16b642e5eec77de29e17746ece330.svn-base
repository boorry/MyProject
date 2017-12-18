using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheetApp.data;
using Task = System.Threading.Tasks.Task;
using MyDataCustomer.data;



namespace TimeSheetApp.Model
{
    public interface IProjectService : IDisposable
    {
        List<Project> SearchProjects(string filtre);
        List<Project> ListProjectList();
        List<VProjectTask> ListTaskList();
        List<VProjectTask> ListTaskWhenProject(string projectName);
        //List<data.Task> ListTaskWhenProject(long projectId);
        List<VProjectHistory> ListProjectHistory(long? myProjectName);
        List<data.Task> ListTacheToAdd();
        List<VCustomers> MyCustomersList();
        List<VCustomers> SearchClient(string myClient);
        void AddTaskToListToDo(long? projectToAddId, long taskToAddId);
        void AddTaskProjectUser(int projectToAddId, int taskToAddId);
        void RemoovTaskToList(long? projectToRemovId, long? taskToremovId);
        void RemoveProjectTaskUser(int projectToRemovId, int taskToremovId);
        bool AddProjectHistories(long projectId, float? lastime, float? newTime, DateTime? actionDate, string modificator);
        void UpdateProject(Project update);
        void NewProjectAdd(string name, string descripetion, string client, DateTime? datedebut, float? estimate, string createur, DateTime creation);
        void AddMyCustomerSelect(Project toAdd);
        void ChangeCustomer(Project toChange);
        bool DeleteProjectInDetail(long? myProject);
        void DeleteTaskProject(long? projectId);
        void DeleteHistoryProject(long? projectId);
        void DeleteTaskUserProject(long? projectId);
        void RenameProject(Project project);
        ProjectTask TaskExist(long myTaskId, long? myProjectId);
        Project ProjectExist(string myProject);
        bool ProjecNameDetailExist(string myProject);
        Project IfMyProject(Project myProject);

    }
}
