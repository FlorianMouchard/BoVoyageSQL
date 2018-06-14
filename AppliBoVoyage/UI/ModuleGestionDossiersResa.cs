using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoVoyage.Framework.UI;

namespace AppliBoVoyage.UI
{
    class ModuleGestionDossiersResa
    {
        private Menu menu;



        private void InitialiserMenuResa()
        {
            this.menu = new Menu("Gestion des dossiers de réservation");
            this.menu.AjouterElement(new ElementMenu("1", "Consulter")
            {
                FonctionAExecuter = this.ConsulterResa
            });
            this.menu.AjouterElement(new ElementMenu("2", "Ajouter")
            {
                FonctionAExecuter = this.CreerResa
            });
            this.menu.AjouterElement(new ElementMenu("3", "Supprimer")
            {
                FonctionAExecuter = this.SupprimerResa
            });
            this.menu.AjouterElement(new ElementMenuQuitterMenu("R", "Revenir au menu principal..."));
        }


        public void Demarrer()
        {
            if (this.menu == null)
            {
                this.InitialiserMenuResa();
            }

            this.menu.Afficher();
        }



        private void ConsulterResa()
        {
            ConsoleHelper.AfficherEntete("Dossier de reservation");

        }


        private void CreerResa()
        {
            ConsoleHelper.AfficherEntete("Nouvelle reservation");

        }

        private void SupprimerResa()
        {
            ConsoleHelper.AfficherEntete("Supprimer une reservation");

        }
    }
}






