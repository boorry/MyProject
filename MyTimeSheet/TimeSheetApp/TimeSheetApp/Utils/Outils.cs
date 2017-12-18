using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.VisualBasic;
using TimeSheetApp.data;
using TimeSheetApp.Model;
using Task = TimeSheetApp.data.Task;

/*Tsiry 
 * dérnier modif : 14-12-2017
 */
namespace TimeSheetApp.Utils
{
    //cette classe comme son non l'indique contien touts les méthodes qui seronts utilisées à plusieurs
    //endroid de l'application, ceci affin d'évider la redendance de code et de facilier la maintenance et la lisibilitée du code
    //tout les méthodes de la classe sont static affin de faciliter leurs utilisation, ainsi on peut appeller dirrectement la classe sans instancie à chaque fois
    //un objet
    internal class Outils
    {
        private static readonly IService Service = new Service();//pour interragire avec la base

        public static bool VerificationSiAppacrientAlUtilisateurCourant(VProjectTaskUser selection)
        {
            return selection.UserName.Equals(Environment.UserName);
        }

        public static bool VerificationSiAppacrientAlUtilisateurCourant(Task selection)
        {
            return selection.CreatedBy.Equals(Environment.UserName);
        }

        public static void LancerUnEngagE(VProjectTaskUser selection)
        {
            if (Utils.MaterialMessageBox.ShowWithCancel("Vouler vous réelement engager cette têche") !=
                MessageBoxResult.OK) return;
            //modification de l'etat
            var mapTaskState = new MapTaskState
            {
                MapTaskStateID = selection.MapTaskStateID,
                MapTaskStateName = "En cours"
            };

            Service.MapTaskStateModifier(mapTaskState);


            //modificaton de la date de début
            var projectTaskUser = Service.ProjectTaskUserChargerUn(selection.ProjectTaskUserID);
            projectTaskUser.StartTask = DateTime.Now;
            Service.ProjectTaskUserModifier(projectTaskUser);

            //on crée nouveau enregistrement dans TaskUserTime
            var taskUserTime = new TaskUserTime
            {
                startDate = DateTime.Now,
                Active = true,
                MapTaskStateName = "En cours",
                ProjectTaskUserID = selection.ProjectTaskUserID
            };
            Service.TaskUserTimeAjouter(taskUserTime);
        }

        public static void LancerUnEnPause(VProjectTaskUser selection)
        {
            var mapTaskState = new MapTaskState
            {
                MapTaskStateID = selection.MapTaskStateID,
                MapTaskStateName = "En cours"
            };
            Service.MapTaskStateModifier(mapTaskState);


            //suppresion de la date de fin dans ProjectTaskUser
            var projectTaskUser = Service.ProjectTaskUserChargerUn(selection.ProjectTaskUserID);
            projectTaskUser.EndTask = null;
            Service.ProjectTaskUserModifier(projectTaskUser);



            //on crée nouveau enregistrement dans TaskUserTime
            var taskUserTime = new TaskUserTime
            {
                startDate = DateTime.Now,
                Active = true,
                MapTaskStateName = "En cours",
                ProjectTaskUserID = selection.ProjectTaskUserID
            };
            Service.TaskUserTimeAjouter(taskUserTime);

        }

        public static void LancerUnTerminE(VProjectTaskUser selection)
        {
            //On Pause une question
            if (Utils.MaterialMessageBox.ShowWithCancel("Vouler vous réelement relancer cette tâche ?") !=
                MessageBoxResult.OK) return;
            var mapTaskState = new MapTaskState
            {
                MapTaskStateID = selection.MapTaskStateID,
                MapTaskStateName = "En cours"
            };
            Service.MapTaskStateModifier(mapTaskState);

            //suppresion de la date de fin
            var projectTaskUser = Service.ProjectTaskUserChargerUn(selection.ProjectTaskUserID);
            projectTaskUser.EndTask = null;
            Service.ProjectTaskUserModifier(projectTaskUser);



            //on crée nouveau enregistrement dans TaskUserTime
            var taskUserTime = new TaskUserTime
            {
                startDate = DateTime.Now,
                Active = true,
                MapTaskStateName = "En cours",
                ProjectTaskUserID = selection.ProjectTaskUserID
            };
            Service.TaskUserTimeAjouter(taskUserTime);

            //pour la modification de l'état d'une tache, il faut verifier tout les  ProjectTaskUser liée au tache
            //MAJ etat tache
            // Service.TaskModifierEtatDUneAPartirDeVProjectTaskUser(selection, true);

        }

        public static void MettreEnPause(VProjectTaskUser selection)
        {

            //modification de l'état
            var mapTaskState = new MapTaskState
            {
                MapTaskStateID = selection.MapTaskStateID,
                MapTaskStateName = "En pause"
            };
            Service.MapTaskStateModifier(mapTaskState);

            //on met à jour le "TaskUserTime" en ajoutant un "EndDate" et en modifiant sont état et son "active"
            var taskUserTime = Service.TaskUserTimeChargerLeDérnierAssocierAuVProjectTaskUser(selection);//on charge le dérnier "TaskUserTime" lié à la selection
            taskUserTime.EndDate = DateTime.Now;
            taskUserTime.MapTaskStateName = "En pause";
            taskUserTime.Active = false;
            DateTime ddb = Convert.ToDateTime(taskUserTime.startDate.ToString());
            DateTime ddf = Convert.ToDateTime(taskUserTime.EndDate.ToString());
            double intervaleSeconde = DateAndTime.DateDiff(DateInterval.Second, ddb, ddf);
            taskUserTime.ExecutionTime = (float)SecondeEnHeur(intervaleSeconde);
            Service.TaskUserTimeModifier(taskUserTime);

            //calcule et modification de temps d'éxecution de ProjectTaskUser
            CalculeEtModificationDuTemptsDExeCutionTotalDuProjectTaskUser(selection.ProjectTaskUserID);



            //on caclule le temps pour le projet rattacher donc: on cherche tout les projectTaskUser rattacher au projet
            CacluTempuPourLeProjetattachE(selection.ProjectID);


        }


        public static void ModificationDeExecutionTimeEtRecaluleDesTemps(TaskUserTime taskUserTime)
        {
            //on charge les nouveau dates et on fait le calcule
            if (taskUserTime.EndDate == null) return;// si il n'y a pas de date de fin, on ne fait pas le calcule
            var ddb = Convert.ToDateTime(taskUserTime.startDate.ToString());
            var ddf = Convert.ToDateTime(taskUserTime.EndDate.ToString());
            double intervaleSeconde = DateAndTime.DateDiff(DateInterval.Second, ddb, ddf);
            taskUserTime.ExecutionTime = (float)SecondeEnHeur(intervaleSeconde);
            Service.TaskUserTimeModifier(taskUserTime);

            //Charger le "ProjectTaskUser" Associer au "taskUserTime"
            if (taskUserTime.ProjectTaskUserID != null)
                CalculeEtModificationDuTemptsDExeCutionTotalDuProjectTaskUser((long)taskUserTime.ProjectTaskUserID);



            //calcule de temps de prj
            CacluTempuPourLeProjetattachE(Service.ChargerUnProjet(taskUserTime).ProjectID);
        }

        public static void CalculeEtModificationDuTemptsDExeCutionTotalDuProjectTaskUser(long projectTaskUserId)
        {
            //on caclule "le temps d'éxecution total"
            float durrEeEffective = Service.CalculerTempsTotalDesTaskUserTimeAPartirDuProjectTaskUserId(projectTaskUserId);
            //Service.ProjectTaskUserModifierDurrEeEffective(selection, durrEeEffective);

            var projectTaskUser = Service.ProjectTaskUserChargerUn(projectTaskUserId);//on charge le ProjectTaskUser(
            projectTaskUser.ExecutionTime = durrEeEffective;//modification du durée effective
            Service.ProjectTaskUserModifier(projectTaskUser);
        }





        public static void CacluTempuPourLeProjetattachE(long? projectId)
        {
            var durrEePrj = Service.CalculerTempsTotalDuProjetAPartirDuProjectId(projectId);
            Service.ModifierDurrEeEffectiveProject(projectId, durrEePrj);
        }


        public static void Stoper(VProjectTaskUser selection)
        {
            if (Utils.MaterialMessageBox.ShowWithCancel("Vouler vous réelement términer cette tâche ?") !=
                MessageBoxResult.OK) return;
            if (selection.MapTaskStateName.Equals("En cours"))
                Outils.MettreEnPause(selection);//si en cours, on met d'abort en pause pour faire les caclules


            var mapTaskState = new MapTaskState
            {
                MapTaskStateID = selection.MapTaskStateID,
                MapTaskStateName = "Terminé"
            };
            Service.MapTaskStateModifier(mapTaskState);

            //modification date fin
            var projectTaskUser = Service.ProjectTaskUserChargerUn(selection.ProjectTaskUserID);
            projectTaskUser.EndTask = DateTime.Now;
            Service.ProjectTaskUserModifier(projectTaskUser);
        }



        public static bool VerificationEtChangementEtatTache(Task selection)//pour verifier si une tache n'est plus liée à un projet avant de le désactiver
        {
            if (selection.Active != null && (bool)selection.Active)//quand on passe de 1 à 0
            {

                //VERIFICATION SI LA TACHE N'EST PAS ACTIVE DANS UN PRJ
                if (Service.ProjectTaskTacheEstDedans(selection) || Service.ProjectTaskUserTacheEstDedans(selection))
                {
                    Utils.MaterialMessageBox.ShowWarning("La tâche : " + selection.TaskName + " ne peut pas être désactivée car elle est liée à un projet ou à un TimeSheet");
                    return false;
                }
                else
                {
                    selection.Active = !selection.Active;
                    Service.TaskModifier(selection);
                    return true;

                }

            }
            else
            {
                selection.Active = !selection.Active;
                //  ServiceTache st = new ServiceTache();
                Service.TaskModifier(selection);
                return true;

            }
        }


        private static double SecondeEnHeur(double seconde)//cette methode change les secode en heurs avec 2 chiffre apres la firgule
        {
            return Math.Round(seconde / 3600, 2);
        }
    }
}
