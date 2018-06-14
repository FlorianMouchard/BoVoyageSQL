using BoVoyage.Framework.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliBoVoyage.UI
{
    public class ModuleGestionParticipants
    {
        private Menu menu;

        private void InitialiserMenu()
        {
            this.menu = new Menu("Gestion des accompagnants");
            this.menu.AjouterElement(new ElementMenu("1", "Consulter la liste des participants")
            {
                FonctionAExecuter = this.ConsulterParticipants
            });
            this.menu.AjouterElement(new ElementMenu("2", "Rechercher un participant")
            {
                FonctionAExecuter = this.RechercherParticipant
            });
            this.menu.AjouterElement(new ElementMenu("3", "Ajouter un participant")
            {
                FonctionAExecuter = this.AjouterParticipant
            });
            this.menu.AjouterElement(new ElementMenu("4", "Modifier un participant")
            {
                FonctionAExecuter = this.ModifierParticipant
            });
            this.menu.AjouterElement(new ElementMenu("5", "Supprimer un participant")
            {
                FonctionAExecuter = this.SupprimerParticipant
            });
            this.menu.AjouterElement(new ElementMenuQuitterMenu("R", "Revenir au menu principal..."));
        }

        public void Demarrer()
        {
            if (this.menu == null)
            {
                this.InitialiserMenu();
            }

            this.menu.Afficher();
        }
        private void ConsulterParticipants()
        {
            ConsoleHelper.AfficherEntete("Liste des participants");
        }
        private void RechercherParticipant()
        {
            ConsoleHelper.AfficherEntete("Rechercher un participant");
        }
        private void AjouterParticipant()
        {
            ConsoleHelper.AfficherEntete("Ajouter un participant");
        }
        private void ModifierParticipant()
        {
            ConsoleHelper.AfficherEntete("Modifier un participant");
        }
        private void SupprimerParticipant()
        {
            ConsoleHelper.AfficherEntete("Supprimer un participant");
        }
    }
}
