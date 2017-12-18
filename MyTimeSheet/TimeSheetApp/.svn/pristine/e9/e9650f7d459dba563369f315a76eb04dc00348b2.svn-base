using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight.Command;
using TimeSheetApp.data;
using TimeSheetApp.Model;
using TimeSheetApp.Utils;
using Task = TimeSheetApp.data.Task;
/*Tsiry 
 * dérnier modif : 08-12-2017
 */

namespace TimeSheetApp.Model
{
    //cette classe est le Service principal, pour tout ce qui est interraction avec la base pour "TimeSheet" et "Tache"
    //elle hérite de l'interface "IService" et
    //elle pemret bien sure la lécture, mais aussi la modification, l'ajout et la supprésion dans la base en fournissant des
    //méthode prévue à ces éffets,
    //si les modelVeiw à besion d'iteragir avec la base, on fait appelle à ce sérice
    public class Service : IService
    {
        private readonly TimeSheetDBEntities _context;//_context représente ici un objet qui représente la base, ceci est redue possible grace à l'utilisation de "Entitie" framewrok
        //pour ce qui est de la modification de la base, on utilisera la classe "Génerale" ceci permetra d'avoir 
        //des logs des differont modification que nous avons faits dirrectement dans une base de données dédiée à cette éffet
        public Service()
        {
            _context = new TimeSheetDBEntities();
        }

        #region Génerale
        //cette séction comprend les méthodes qui permente de metres à jours les projets, chager un ou la liste des projets
        //elle contien aussi les méthodes qui permete de faire les calules de temps sur les différents tables 
        public bool MiseAJourTempsProject(string idPr, float tempsTotal)//à partir de l'id du projet
        {
            bool retour = false;
            try
            {
                var temp = _context.Project.FirstOrDefault(x => x.ProjectID.ToString() == idPr);
                if (temp != null)
                {
                    //  MessageBox.Show(tempsTotal.ToString());
                    temp.DurationProject = tempsTotal;
                    _context.SaveChanges();
                    retour = true;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return retour;
        }

        public List<Project> ChargerContenuLstProjet()
        {
            try
            {
                var liste = _context.Project.Distinct().ToList();
                return liste.OrderBy(x => x.ProjectName).ToList();//pour ranger le résultat selon le nom du projet;
            }
            catch (Exception)
            {
                // MessageBox.Show(e.ToString());
                return null;
            }
        }
        public Project ChargerUnProjet(VProjectTaskUser filtre)//à partir d'un "VProjectTaskUser"
        {
            try
            {

                var lst = _context.Project.Where(x => x.ProjectID == filtre.ProjectID).Distinct().ToList();
                var prj = lst[0];
                return prj;
            }
            catch (Exception)
            {
                // MessageBox.Show(e.ToString());
                return null;
            }
        }

        public Project ChargerUnProjet(TaskUserTime taskUserTime)//à partir d'un "TaskUserTime"
        {
            try
            {
                //il faut cherche le ProjectTaskUser associer
                var projectTaskUser =
                    _context.ProjectTaskUser.FirstOrDefault(x => x.ProjectTaskUserID == taskUserTime.ProjectTaskUserID);

                var project = _context.Project.FirstOrDefault(x => x.ProjectID == projectTaskUser.ProjectID);
                
                return project;
            }
            catch (Exception)
            {
                // MessageBox.Show(e.ToString());
                return null;
            }
        }

        public float CalculerTempsTotalDesTaskUserTimeAPartirDuProjectTaskUserId(long projectTaskUserId)//à partir de ProjectTaskUserId
        {
            //on liste les "TaskUserTime" liés au projet
            var taskUserTime =
                from tut in _context.TaskUserTime
                where tut.ProjectTaskUserID == projectTaskUserId
                select tut;
            var lst = taskUserTime.ToList();

            //on retourne la somme des "ExecutionTime" de la liste
            return lst.Select(t => t.ExecutionTime).Where(executionTime => executionTime != null).Sum(executionTime => (float) executionTime);
        }

        public float CalculerTempsTotalDuProjetAPartirDuProjectId(long? projectId)
        {
            //à partir des projectId , on fait la liste de tout les ProjectTaskUser qui on le projectId
            var ptu = _context.ProjectTaskUser.Where(x => x.ProjectID == projectId).Distinct();
            var lst = ptu.ToList();
            //on retourne la somme des "ExecutionTime" de la liste
            return lst.Select(t => t.ExecutionTime).Where(executionTime => executionTime != null).Sum(executionTime => (float)executionTime);
          
        }


        public bool ModifierDurrEeEffectiveProjectTaskUser(VProjectTaskUser vProjectTaskUser, float tempsTotal)//à partir du VProjectTaskUser
        {
            var retour = false;
            try
            {
                var temp = _context.ProjectTaskUser.FirstOrDefault(x => x.ProjectTaskUserID == vProjectTaskUser.ProjectTaskUserID);//on selectionne l'id
                if (temp != null)
                {
                    //on fait la modification
                    temp.ExecutionTime = tempsTotal;
                    General.SaveContextChanges(
                        "Modification de la durrée total dans ProjectTaskUser : " + vProjectTaskUser.ProjectName, _context);
                    retour = true;
                }
            }
            catch (Exception)
            {
                //MessageBox.Show(e.ToString());
                return false;
            }
            return retour;
        }

        public bool ModifierDurrEeEffectiveProject(long? projectId, float tempsTotal)////à partir de l'id du projet
        {
            var retour = false;
            try
            {
                var temp = _context.Project.FirstOrDefault(x => x.ProjectID == projectId);
                if (temp != null)
                {
                    //  MessageBox.Show(tempsTotal.ToString());
                    temp.DurationProject = tempsTotal;
                    General.SaveContextChanges(
                       "Modification de la durrée total du projet dont l'id est : " + projectId, _context);
                    retour = true;
                }

            }
            catch (Exception)
            {
                return false;
            }
            return retour;
        }
        #endregion


        #region Pour "MapTaskState"
        //cette section contien tout les méthodes liées à MapTaskState
        public string MapTaskStateLireEtatAPartirDUnProjectTaskUser(VProjectTaskUser projectTaskUser)//on lit l'etat du "VProjectTaskUser"
        {
            var res = "";
            try
            {
                var firstOrDefault = _context.MapTaskState.FirstOrDefault(x => x.MapTaskStateID == projectTaskUser.MapTaskStateID);
                if (
                    firstOrDefault !=
                    null)
                    res = firstOrDefault.MapTaskStateName;
            }
            catch (Exception)
            {
                 //MessageBox.Show(e.ToString());


            }
            return res;
        }
        public bool MapTaskStateModifier(MapTaskState mapTaskState)
        {
            try
            {

                _context.MapTaskState.AddOrUpdate(mapTaskState);
                _context.SaveChanges();

                return true;
            }
            catch (Exception )
            {
                //MessageBox.Show(e.ToString());
                return false;
            }
        }

        public bool MapTaskStateAjouterUnEngagE()// cette métode ajoute un "MapTaskState", qui a comme " MapTaskStateName" un ""Engagé", car qond 
                                                 //on créer un timeSheet, il doit etre lier à un "MapTaskState" dont l'etat est "Engagé"
        {
            var mapTaskState = new MapTaskState { MapTaskStateName = "Engagé" };
            _context.MapTaskState.Add(mapTaskState);
            General.SaveContextChanges("Ajout d'un engagé dans MapTaskState id : " + mapTaskState.MapTaskStateID, _context);
            return true;
        }

        #endregion


        #region pour ProjectTask
        //cette séction contien tout les méthodes relatif à ProjectTask
        //un "ProjectTask" est une tache qui est liée à un projet et qui peut etre ajouter au liste de "ProjectTaskUsers" pour devenir un "TimeSheet"

        public bool ProjectTaskTacheEstDedans(Task task)//verifie si la tache est dans "ProjectTask", si la tache est dedans, cela veut dire qu'elle est déja engagée
        {
            var trouvE = false;
            try
            {
                var tmp = _context.ProjectTask.FirstOrDefault(x => x.TaskID == task.TaskID);
                if (tmp != null)
                {
                    trouvE = true;
                }
            }
            catch (Exception )
            {
                 //MessageBox.Show(e.ToString());
                trouvE = false;

            }
            return trouvE;
        }

        public List<VProjectTask> VProjectTaskChargerLst(string filtre) {
            try
            {
               var liste = _context.VProjectTask.Where(x => x.ProjectName == filtre || filtre.ToString().ToString().Equals("tout")).Distinct().ToList();
                //FILTRE
              /*  if (isUniquementLesNonEngagEs)
                {*/
                    //on enleve de la liste les tache qui sont déja liées
                    liste.RemoveAll(x =>  ProjectTaskUserEstDedans(x, Environment.UserName));

              //  }

                return liste;
            }
            catch (Exception )
            {
                //MessageBox.Show(e.ToString());
                return null;
            }
        }



        #endregion


        #region Pour ProjectTaskUser
        //un "ProjectTaskUser" est un "TimeSheet"
        public VProjectTaskUser VProjectTaskUserChargerUn(long idProjectTaskUser)//à partir de l'id
        {
           var temp = _context.VProjectTaskUser.FirstOrDefault(x => x.ProjectTaskUserID == idProjectTaskUser);
            return temp;

        }

        public ProjectTaskUser ProjectTaskUserChargerUn(long idProjectTaskUser)//à partir de l'id
        {
            var temp = _context.ProjectTaskUser.FirstOrDefault(x => x.ProjectTaskUserID == idProjectTaskUser);
            return temp;
        }
      

        public void ProjectTaskUserModifier(ProjectTaskUser projectTaskUser)
        {
            try
            {

                _context.ProjectTaskUser.AddOrUpdate(projectTaskUser);
                    General.SaveContextChanges("modificaton dans ProjectTaskUser id : "+projectTaskUser.ProjectTaskUserID, _context);
                    
            }
            catch (Exception )
            {
                //MessageBox.Show(e.ToString());
                return;
            }
        }
       

        public bool ProjectTaskUserAjouter(VProjectTask vProjectTask)//id MapTaskState
        {
            //pour ajouter un "ProjectTaskUser", vue qu'il est lier à "MapTaskState" et qu'on ajout d'abord un ""MapTaskState"
            //il faut d'abord selectionner le dérnier id de "MapTaskState"
            var mapTaskState =
                   from mts in _context.MapTaskState
                   orderby mts.MapTaskStateID descending
                   select mts;

            long idDernierMapTaskState = mapTaskState.ToList()[0].MapTaskStateID;

            //en suite, idDernierMapTaskState est entrée dans le nouveau ProjectTaskUser
            var projectTaskUser = new ProjectTaskUser
            {
                MapTaskStateID = idDernierMapTaskState,
                ProjectID = vProjectTask.ProjectID,
                TaskID = vProjectTask.TaskID,
                UserName = Environment.UserName
            };


            _context.ProjectTaskUser.Add(projectTaskUser);
            General.SaveContextChanges("ajout dans ProjectTaskUser : " + projectTaskUser.ProjectTaskUserID, _context);
            return true;
        }

        public bool ProjectTaskUserSupprimer(ProjectTaskUser projectTaskUser)//suppression d'un TimeSheet
        {
            try
            {
                //vue qu'un "ProjectTaskUser"
               
                _context.ProjectTaskUser.Remove(projectTaskUser);
                General.SaveContextChanges("suppression dans ProjectTaskUser  id : " + projectTaskUser.ProjectTaskUserID, _context);
                return true;


            }
            catch (Exception )
            {
                return false;
            }

        }

        public bool ProjectTaskUserEstDedans(VProjectTask vProjectTask)//vérifie si VProjectTask est déja dans ProjectTaskUse
        {
            var trouvE = false;
            try
            {
                var tmp = _context.VProjectTaskUser.FirstOrDefault(x => x.ProjectID == vProjectTask.ProjectID && x.TaskID == vProjectTask.TaskID);
                if (tmp != null)
                {
                    trouvE = true;
                }
            }
            catch (Exception )
            {
                 //MessageBox.Show(e.ToString());
                trouvE = false;

            }
            return trouvE;
        }

        public bool ProjectTaskUserEstDedans(VProjectTask vProjectTask,string userName)//vérifie si VProjectTask est déja dans ProjectTaskUse
        {
            var trouvE = false;
            try
            {
                var tmp = _context.VProjectTaskUser.FirstOrDefault(x => x.ProjectID == vProjectTask.ProjectID && x.TaskID == vProjectTask.TaskID && x.UserName.Equals(userName));
                if (tmp != null)
                {
                    trouvE = true;
                }
            }
            catch (Exception)
            {
                //MessageBox.Show(e.ToString());
                trouvE = false;

            }
            return trouvE;
        }

        public bool ProjectTaskUserTacheEstDedans(Task task)//verifi si la tache est encore liée au ProjectTaskUserTache
        {
            var trouvE = false;
            try
            {
                var tmp = _context.ProjectTaskUser.FirstOrDefault(x => x.TaskID == task.TaskID);
                if (tmp != null)
                {
                    trouvE = true;
                }
            }
            catch (Exception )
            {
                 //MessageBox.Show(e.ToString());
                trouvE = false;

            }
            return trouvE;
        }

        public bool ProjectTaskUserTacheEstDedans(long taskId)//verifi si la tache est encore liée au ProjectTaskUserTache
        {
            var trouvE = false;
            try
            {
                var tmp = _context.ProjectTaskUser.FirstOrDefault(x => x.TaskID == taskId);
                if (tmp != null)
                {
                    trouvE = true;
                }
            }
            catch (Exception)
            {
                //MessageBox.Show(e.ToString());
                trouvE = false;

            }
            return trouvE;
        }

        public bool ProjectTaskUserProjetEstDedans(Project project)//verifi si le projet est encore liée au ProjectTaskUserTache
        {
            var trouvE = false;
            try
            {
                var tmp = _context.ProjectTaskUser.FirstOrDefault(x => x.ProjectID == project.ProjectID);
                if (tmp != null)
                {
                    trouvE = true;
                }
            }
            catch (Exception)
            {
                //MessageBox.Show(e.ToString());
                trouvE = false;

            }
            return trouvE;
        }

        public List<VProjectTaskUser> VProjectTaskUserChargerLst(string filtre, bool isUniquementMesProjets, bool isUniquementTimeSheetCloturEs)//liste tout les ProjectTaskUsers avec les different filtres
        {
            try
            {

                List<VProjectTaskUser> lstResult = null;
                lstResult = _context.VProjectTaskUser.Where(vptu => vptu.UserName.Contains(filtre) || vptu.ProjectName.Contains(filtre) || vptu.TaskName.Contains(filtre) || vptu.MapTaskStateName.Contains(filtre) || filtre.ToString().Equals("")).ToList();

                //on appllique les filtres des checkbox
                if (isUniquementMesProjets)
                    lstResult.RemoveAll(ts => ts.UserName != Environment.UserName);//on supprime tout les "UserName" different de "Environment.UserName"
                if (isUniquementTimeSheetCloturEs)
                    lstResult.RemoveAll(ts => ts.MapTaskStateName != "Terminé");//on supprime les taches qui ne sont pas términées
                return lstResult.OrderBy(x => x.ProjectName).ToList();//pour ranger le résultat selon le nom du projet
            }
            catch (Exception )
            {
                  //MessageBox.Show(e.ToString());
                return null;
            }

        }

        public List<VProjectTaskUser> VProjectTaskUserChargerLstParIntervenant(string filtre, bool isUniquementMesProjets, bool isUniquementTimeSheetCloturEs)//liste tout les ProjectTaskUsers avec les different filtres
        {
            try
            {

                List<VProjectTaskUser> lstResult = null;
                lstResult = _context.VProjectTaskUser.Where(vptu => vptu.UserName.Contains(filtre) || vptu.TaskName.Contains(filtre) || vptu.MapTaskStateName.Contains(filtre) || filtre.ToString().Equals("")).ToList();

                //on appllique les filtres des checkbox
                if (isUniquementMesProjets)
                    lstResult.RemoveAll(ts => ts.UserName != Environment.UserName);
                if (isUniquementTimeSheetCloturEs)
                    lstResult.RemoveAll(ts => ts.MapTaskStateName != "Terminé");
                return lstResult.OrderBy(x => x.ProjectName).ToList();//pour ranger le résultat selon le nom du projet
            }
            catch (Exception)
            {
                //  MessageBox.Show(e.ToString());
                return null;
            }

        }

      



        #endregion

        #region Pour "Task"
        //cette dégion regroupe tout les methodes liées au taches
        public List<Task> TaskChargerLst()//liste les taches
        {
            try
            {
                var liste = _context.Task.ToList();
                return liste.OrderBy(x => x.TaskName).ToList();//pour ranger le résultat selon le nom des tache
            }
            catch (Exception )
            {
               //  MessageBox.Show(e.ToString());
                return null;
            }
        }


        public List<Task> TaskChargerLst(string filtre, bool isUniquementMesTaches)//liste les taches avec les filtres
        {
            try
            {

                var result = _context.Task.Where(t => t.TaskName.Contains(filtre) || t.CreatedBy.Contains(filtre) || t.ModifiedBy.Contains(filtre) || filtre.ToString().Equals("")).ToList();
                var lstResult = result.ToList();

                //filtre par checkBox
                if (isUniquementMesTaches)
                    lstResult.RemoveAll(t => t.CreatedBy != Environment.UserName);


                return lstResult.OrderBy(x => x.TaskName).ToList();//pour ranger le résultat selon le nom des tache
            }
            catch (Exception )
            {
                // MessageBox.Show(e.ToString());
                return null;
            }

        }

        public Task TaskCharger(Task task)//charge une tache à partir de d'une tache
        {
            try
            {
                var result = _context.Task.FirstOrDefault(t => t.TaskID == task.TaskID);
                return result;
            }
            catch (Exception )
            {
                //MessageBox.Show(e.ToString());
                return null;
            }
        }

        public Task TaskCharger(long? idTache)//charge une tache à partir de son id
        {
            try
            {
                var tache = _context.Task.FirstOrDefault(x => x.TaskID == idTache);
                return tache;
            }
            catch (Exception )
            {
                //MessageBox.Show(e.ToString());
                return null;
            }
        }

        public bool TaskModifier(Task update)
        {
            var retour = false;
            try
            {
                var temp = _context.Task.FirstOrDefault(x => x.TaskID == update.TaskID);
                if (temp != null)
                {

                    temp.ModifiedBy = update.ModifiedBy;
                    temp.TaskName = update.TaskName;
                    temp.CreatedBy = update.CreatedBy;
                    temp.CreationDate = update.CreationDate;
                    temp.ModificationDate = update.ModificationDate;
                    temp.Active = update.Active;

                    General.SaveContextChanges("modification d'une tahe id : " + temp.TaskID, _context);
                    retour = true;

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());

                return false;
            }
            return retour;
        }


        public bool TaskAjouter(Task task)
        {
            try
            {
                _context.Task.Add(task);
                General.SaveContextChanges("ajout d'une tahe nom : " + task.TaskName, _context);
                return true;
            }
            catch (Exception )
            {

                //MessageBox.Show(e.ToString());
                return false;
            }
        }

        public bool TaskSupprimer(Task task)
        {
            var retour = false;
            try
            {
                var temp = _context.Task.FirstOrDefault(x => x.TaskID == task.TaskID);
                if (temp != null)
                {
                    _context.Task.Remove(temp);
                    General.SaveContextChanges("suppression de la tache :  " + task.TaskName, _context);
                    retour = true;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return retour;
        }

        public bool TaskNomExisteDeja(string nomTache)
        {
            var tmp = _context.Task.FirstOrDefault(x => x.TaskName == nomTache);
            return tmp != null;
        }
             

        #endregion

        #region Pour TaskUserTime et TaskTime
        //cette section contien tous les m"thodes liées à TaskUserTime et TaskTime,

        public List<VTaskTime> VTaskTimeChargerLstDuProjectTaskUser(VProjectTaskUser vProjectTaskUser)//liste les VTaskTimes liées au VProjectTaskUser
        {
            try
            {
                var res =
                    from vti in _context.VTaskTime
                    where vti.ProjectTaskUserID == vProjectTaskUser.ProjectTaskUserID
                    select vti;

                return res.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
        public bool TaskUserTimeAjouter(TaskUserTime taskUserTime)//ajout d'un TaskUserTime quand on vie de mettre en pause le dérnier
        {
           // bool retour = false;
            try
            {

                _context.TaskUserTime.Add(taskUserTime);
                General.SaveContextChanges("ajout d'un UserTime id : " + taskUserTime.TaskUserTimeID, _context);
                return true;
            }
            catch (Exception )
            {

                //MessageBox.Show(e.ToString());
                return false;
            }
           // return retour;

        }

        public TaskUserTime TaskUserTimeChargerLeDérnierAssocierAuVProjectTaskUser(VProjectTaskUser vProjectTaskUser)// on charge le dérnier TaskUserTime lier au VProjectTaskUser
        {
            try
            {
                var taskUserTime = _context.TaskUserTime.OrderByDescending(x => x.TaskUserTimeID).FirstOrDefault(x => x.ProjectTaskUserID == vProjectTaskUser.ProjectTaskUserID);
                return taskUserTime;
            }
            catch (Exception )
            {
                return null;
            }
        }

        public TaskUserTime TaskUserTimeCharger(VTaskTime vTaskTime)// à partir d'un VTaskTime
        {
            try
            {
                var taskUserTime = _context.TaskUserTime.FirstOrDefault(x => x.TaskUserTimeID == vTaskTime.TaskUserTimeID);

                return taskUserTime;
            }
            catch (Exception)
            {
                // MessageBox.Show(e.ToString());
                return null;
            }
        }
        public VTaskTime VTaskUserTimeCharger(VTaskTime vTaskTime)// à partir d'un VTaskTime
        {
            try
            {
                var taskUserTime = _context.VTaskTime.FirstOrDefault(x => x.TaskUserTimeID == vTaskTime.TaskUserTimeID);
                return taskUserTime;
            }
            catch (Exception)
            {
                // MessageBox.Show(e.ToString());
                return null;
            }
        }


        public bool TaskUserTimeModifier(TaskUserTime update)
        {
            try
            {
                _context.TaskUserTime.AddOrUpdate(update);
                General.SaveContextChanges("modification d'un UserTime id : " + update.TaskUserTimeID, _context);

                return true;
            }
            catch (Exception )
            {
                //MessageBox.Show(e.ToString());
                return false;
            }
        }

        public bool TaskUserTimeSupprimerAPartirDUnvProjectTaskUser(long idProjectTaskUser) //on supprime le  TaskUserTime  lié au projet
        {
            try
            {

                var lstTaskUserTime = _context.TaskUserTime.Where(x => x.ProjectTaskUserID == idProjectTaskUser).ToList();

                foreach (var temp in lstTaskUserTime)
                {
                    TaskUserTimeHistorySupprimerAPartirDeTaskUserTime(temp.TaskUserTimeID);//il faut d'abord suppriner les  "TaskUserTimeHistory" liées au "TaskUserTime"
                    _context.TaskUserTime.Remove(temp);

                    General.SaveContextChanges("suppression d'un UserTime id : " + temp.TaskUserTimeID, _context);
                }


                return true;
            }
            catch (Exception )
            {
               // MessageBox.Show(e.ToString());
                return false;
            }
        }
        
        public bool TaskUserTimeModifier(VTaskTime update)//modification
        {
            try
            {
                var temp = _context.TaskUserTime.FirstOrDefault(x => x.TaskUserTimeID == update.TaskUserTimeID);
                if (temp == null) return true;
                temp.startDate = update.startDate;
                temp.EndDate = update.EndDate;
                General.SaveContextChanges("modification d'un UserTime id : " + temp.TaskUserTimeID, _context);

                return true;
            }
            catch (Exception )
            {
                //MessageBox.Show(e.ToString());
                return false;
            }
        }

        public TaskUserTime TaskUserTimePrecedent(int indiceSelectionActuel)
        {
           // MessageBox.Show("indice = " + (indiceSelectionActuel - 1));
            return _context.TaskUserTime.ToList()[12];
        }

        public TaskUserTime TaskUserTimeSuivant(int indiceSelectionActuel)
        {
            return _context.TaskUserTime.ToList()[indiceSelectionActuel + 1];
        }

      




        #endregion

        #region Pour TaskUserTimeHistory
        //cette section contien tout les méthode de TaskUserTimeHistory

        public bool TaskUserTimeHistoryAjouterUnTaskUserTime(TaskUserTime taskUserTime)// ajout d'un TaskUserTime
        {

            try
            {
                var taskUserTimeHistory = new TaskUserTimeHistory
                {
                    EndDate = taskUserTime.EndDate,
                    startDate = taskUserTime.startDate,
                    TaskUserTimeID = taskUserTime.TaskUserTimeID,
                    CreatedBy = Environment.UserName
                };
                //taskUserTimeHistory.CreatedBy=taskUserTime.
                _context.TaskUserTimeHistory.Add(taskUserTimeHistory);
                // General.SaveContextChanges("ajout dans TimeHistory id : " + taskUserTimeHistory.TaskUserTimeHistoryID,_context);
                _context.SaveChanges();
                return true;
            }
            catch (Exception )
            {

                //MessageBox.Show(e.ToString());
                return false;
            }

        }

        public List<TaskUserTimeHistory> TaskUserTimeHistoryChargerLst(VTaskTime vTaskTime)//la liste des TaskUserTimeHistory liées à VTaskTime
        {
            try
            {
                var liste = _context.TaskUserTimeHistory.Where(x => x.TaskUserTimeID == vTaskTime.TaskUserTimeID).Distinct().ToList();
                return liste;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public bool TaskUserTimeHistorySupprimerAPartirDeTaskUserTime(long taskUserTimeId)//suppression
        {
            try
            {

                var lstTaskUserTimeHistory = _context.TaskUserTimeHistory.Where(x => x.TaskUserTimeID == taskUserTimeId).ToList();

                foreach (var temp in lstTaskUserTimeHistory)
                {
                    _context.TaskUserTimeHistory.Remove(temp);
                    General.SaveContextChanges("suppression d'un UserTimeHistory id : " + temp.TaskUserTimeHistoryID, _context);
                }


                return true;
            }
            catch (Exception )
            {
                //MessageBox.Show(e.ToString());
                return false;
            }
        }

        #endregion
    }
}
