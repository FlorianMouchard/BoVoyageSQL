using System;
using BoVoyage.Framework.UI;
using AppliBoVoyage.UI;


namespace BoVoyage.UI
{
    public class Application
    {
        private Menu menuPrincipal;
        private ModuleGestionClientèle moduleGestionClientèle;
        private ModuleGestionVoyages moduleGestionVoyages;
        private ModuleGestionDossiersResa moduleGestionDossiersResa;

        private void InitialiserModules()
        {
            this.moduleGestionClientèle = new ModuleGestionClientèle();
            this.moduleGestionVoyages = new ModuleGestionVoyages();
            this.moduleGestionDossiersResa = new ModuleGestionDossiersResa();
        }

        private void InitialiserMenuPrincipal()
        {
            this.menuPrincipal = new Menu("Menu principal");
            this.menuPrincipal.AjouterElement(new ElementMenu("1", "Gestion des clients")
            {
                AfficherLigneRetourMenuApresExecution = false,
                FonctionAExecuter = this.moduleGestionClientèle.Demarrer
            });
            this.menuPrincipal.AjouterElement(new ElementMenu("2", "Gestion des voyages")
            {
                AfficherLigneRetourMenuApresExecution = false,
                FonctionAExecuter = this.moduleGestionVoyages.Demarrer
            });
            this.menuPrincipal.AjouterElement(new ElementMenu("3", "Gestion des dossiers de réservation")
            {
                AfficherLigneRetourMenuApresExecution = false,
                FonctionAExecuter = this.moduleGestionDossiersResa.Demarrer
            });
            this.menuPrincipal.AjouterElement(new ElementMenuQuitterMenu("Q", "Quitter")
            {
                FonctionAExecuter = () => Environment.Exit(1)
            });
        }

        public void Demarrer()
        {
            this.InitialiserModules();
            this.InitialiserMenuPrincipal();

            this.menuPrincipal.Afficher();
        }
    }
}
