using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight.Command;
using TimeSheetApp.data;
using Task = TimeSheetApp.data.Task;
/*Tsiry 
 * dérnier modif : 08-12-2017
 */


namespace TimeSheetApp.Model
{
    //cette Interface servira de base pour la classe "Service" qui seras l'outil de communication et d'interraction avec la base
    //pour tout ce qui est "TimeSheet" et "Tache"
    //tout les méthodes qui y sont déclarées seront à implémenter dans la classe "Service"
    public interface IService
    {

        #region Génerale
        Project ChargerUnProjet(VProjectTaskUser filtre);
        Project ChargerUnProjet(TaskUserTime taskUserTime);
        bool ModifierDurrEeEffectiveProject(long? projectId, float tempsTotal);
        bool MiseAJourTempsProject(string idPr, float tempsTotal);
        List<Project> ChargerContenuLstProjet();
        float CalculerTempsTotalDesTaskUserTimeAPartirDuProjectTaskUserId(long projectTaskUserId);
        float CalculerTempsTotalDuProjetAPartirDuProjectId(long? projectId);
        #endregion

        #region MapTaskState
        bool MapTaskStateModifier(MapTaskState mapTaskState);
        string MapTaskStateLireEtatAPartirDUnProjectTaskUser(VProjectTaskUser projectTaskUser);
        bool MapTaskStateAjouterUnEngagE();
        #endregion

        #region ProjectTask
        bool ProjectTaskTacheEstDedans(Task task);
        List<VProjectTask> VProjectTaskChargerLst(string filtre);
        #endregion

        #region ProjectTaskUser

        VProjectTaskUser VProjectTaskUserChargerUn(long idProjectTaskUser);
        ProjectTaskUser ProjectTaskUserChargerUn(long idProjectTaskUser);
        List<VProjectTaskUser> VProjectTaskUserChargerLst(string filtre, bool isUniquementMesProjets,
       bool isUniquementTimeSheetCloturEs);//un ProjectTaskUsers représente un "TimeSheet"


        List<VProjectTaskUser> VProjectTaskUserChargerLstParIntervenant(string filtre, bool isUniquementMesProjets,
        bool isUniquementTimeSheetCloturEs);//un ProjectTaskUsers représente un "TimeSheet"


        void ProjectTaskUserModifier(ProjectTaskUser projectTaskUser);

        bool ProjectTaskUserAjouter(VProjectTask vProjectTask);
        bool ProjectTaskUserSupprimer(ProjectTaskUser projectTaskUser);
        bool ProjectTaskUserEstDedans(VProjectTask vProjectTask);
        bool ProjectTaskUserTacheEstDedans(Task task);
        bool ProjectTaskUserTacheEstDedans(long taskId);
        bool ProjectTaskUserProjetEstDedans(Project project);

        #endregion


        #region Tache
        List<Task> TaskChargerLst();
        List<Task> TaskChargerLst(string filtre, bool isUniquementMesTaches);
        Task TaskCharger(Task task);
        Task TaskCharger(long? idTache);
        bool TaskModifier(Task update);
        bool TaskAjouter(Task task);
        bool TaskSupprimer(Task task);
        bool TaskNomExisteDeja(string nomTache);

        #endregion
        #region TaskUserTime et TaskTime
        List<VTaskTime> VTaskTimeChargerLstDuProjectTaskUser(VProjectTaskUser vProjectTaskUser);
        bool TaskUserTimeAjouter(TaskUserTime taskUserTime);
        TaskUserTime TaskUserTimeChargerLeDérnierAssocierAuVProjectTaskUser(VProjectTaskUser vProjectTaskUser);
        TaskUserTime TaskUserTimeCharger(VTaskTime vTaskTime);
        VTaskTime VTaskUserTimeCharger(VTaskTime vTaskTime);
        bool TaskUserTimeModifier(TaskUserTime update);
        bool TaskUserTimeSupprimerAPartirDUnvProjectTaskUser(long idProjectTaskUser);
        bool TaskUserTimeModifier(VTaskTime update);
        TaskUserTime TaskUserTimePrecedent(int indiceSelectionActuel);
        TaskUserTime TaskUserTimeSuivant(int indiceSelectionActuel);

        //Pour TaskUserTimeHistory
        bool TaskUserTimeHistoryAjouterUnTaskUserTime(TaskUserTime taskUserTime);
        List<TaskUserTimeHistory> TaskUserTimeHistoryChargerLst(VTaskTime vTaskTime);
        bool TaskUserTimeHistorySupprimerAPartirDeTaskUserTime(long taskUserTimeId);

        #endregion

    }
}
