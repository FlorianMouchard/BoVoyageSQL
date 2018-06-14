using System;
using BoVoyage.Framework.UI;
using AppliBoVoyage.UI;
using System.Data.SqlClient;
using System.Configuration;
using AppliBoVoyage.Dal;

namespace BoVoyage.UI
{
    public class Application
    {
        private Menu menuPrincipal;
        private ModuleGestionClientele moduleGestionClientele;
        private ModuleGestionVoyages moduleGestionVoyages;
        private ModuleGestionDossiersResa moduleGestionDossiersResa;

        private void InitialiserModules()
        {
            this.moduleGestionClientele = new ModuleGestionClientele();
            this.moduleGestionVoyages = new ModuleGestionVoyages();
            this.moduleGestionDossiersResa = new ModuleGestionDossiersResa();
        }

        private void InitialiserMenuPrincipal()
        {
            this.menuPrincipal = new Menu("Menu principal");
            this.menuPrincipal.AjouterElement(new ElementMenu("1", "Gestion des clients")
            {
                AfficherLigneRetourMenuApresExecution = false,
                FonctionAExecuter = this.moduleGestionClientele.Demarrer
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
        public static SqlConnection GetConnexion()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Connexion"].ConnectionString;
            return new SqlConnection(connectionString);
        }

        public static BaseDonnees GetBaseDonnees()
        {
            return new BaseDonnees();
        }
    }
}
