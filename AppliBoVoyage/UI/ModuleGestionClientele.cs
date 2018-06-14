using BoVoyage.Framework.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliBoVoyage.UI
{
    class ModuleGestionClientele
    {
        private Menu menu;
        private ModuleGestionClients moduleGestionClients;
        private ModuleGestionParticipants moduleGestionAccompagnant;

        private void InitialiserModules()
        {
            this.moduleGestionClients = new ModuleGestionClients();
            this.moduleGestionAccompagnant = new ModuleGestionParticipants();
        }
        private void InitialiserMenu()
        {
            this.menu = new Menu("Gestion de la clientèle");
            this.menu.AjouterElement(new ElementMenu("1", "Gestion des clients")
            {
                AfficherLigneRetourMenuApresExecution = false,
                FonctionAExecuter = this.moduleGestionClients.Demarrer
            });
            this.menu.AjouterElement(new ElementMenu("2", "Gestion des accompagnants")
            {
                AfficherLigneRetourMenuApresExecution = false,
                FonctionAExecuter = this.moduleGestionAccompagnant.Demarrer
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
    }
}
