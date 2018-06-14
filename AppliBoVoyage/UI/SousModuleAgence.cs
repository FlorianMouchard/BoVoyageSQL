using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoVoyage.Framework.UI;
using AppliBoVoyage.Metier;

namespace AppliBoVoyage.UI
{
    class SousModuleAgence
    {
        private Menu menu;
        private ModuleGestionVoyages moduleGestionVoyages;


        private void MenuAgence()
        {
            this.menu = new Menu("Gestion des agences");
            this.menu.AjouterElement(new ElementMenu("1", "Consulter agences")
            {
                FonctionAExecuter = this.ConsulterAgence
            });
            this.menu.AjouterElement(new ElementMenu("2", "Ajouter agence")
            {
                FonctionAExecuter = this.AjouterAgence
            });
            this.menu.AjouterElement(new ElementMenu("3", "Modifier agence")
            {
                FonctionAExecuter = this.ModifierAgence
            });
            this.menu.AjouterElement(new ElementMenu("4", "Supprimer agence")
            {
                FonctionAExecuter = this.SupprimerAgence
            });
            this.menu.AjouterElement(new ElementMenuQuitterMenu("R", "Revenir au menu principal..."));
        }

        public void Demarrer()
        {
            if (this.menu == null)
            {
                this.MenuAgence();
            }

            this.menu.Afficher();
        }



        private void ConsulterAgence()
        {
            ConsoleHelper.AfficherEntete("Les agences");



        }


        private void AjouterAgence()
        {
            ConsoleHelper.AfficherEntete("Nouvelle agence");
            var agence = new AgenceVoyage ();
            {
                agence.Nom = ConsoleSaisie.SaisirChaineObligatoire("Raison Sociale: ");
            }
        }


        private void ModifierAgence()
        {
            ConsoleHelper.AfficherEntete("Modification d'une agence");

        }


        private void SupprimerAgence()
        {
            ConsoleHelper.AfficherEntete("Supprimer une agence");

        }

    }




}






