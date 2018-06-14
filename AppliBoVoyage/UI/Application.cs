using System;
using AppliBoVoyage.UI;
using BoVoyage.Framework.UI;

namespace LocaMat.UI
{
    public class Application
    {
        private Menu menuPrincipal;
        private ModuleGestionClientèle moduleGestionClients;
        private ModuleGestionVoyages moduleGestionVoyages;
        private ModuleGestionDossiersResa moduleGestionDossiersResa;

        private void InitialiserModules()
        {
            this.moduleGestionClients = new ModuleGestionClientèle();
            this.moduleGestionVoyages = new ModuleGestionVoyages();
            this.moduleGestionDossiersResa = new ModuleGestionDossiersResa();
        }

        private void InitialiserMenuPrincipal()
        {
            this.menuPrincipal = new Menu("Menu principal");
            this.menuPrincipal.AjouterElement(new ElementMenu("1", "Gestion des produits")
            {
                AfficherLigneRetourMenuApresExecution = false,
                FonctionAExecuter = this.moduleGestionProduits.Demarrer
            });
            this.menuPrincipal.AjouterElement(new ElementMenu("2", "Gestion des agences")
            {
                AfficherLigneRetourMenuApresExecution = false,
                FonctionAExecuter = this.moduleGestionAgences.Demarrer
            });
            this.menuPrincipal.AjouterElement(new ElementMenu("3", "Gestion des clients")
            {
                AfficherLigneRetourMenuApresExecution = false,
                FonctionAExecuter = this.moduleGestionClients.Demarrer
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
