using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoVoyage.Framework.UI;
using System.Linq;
using AppliBoVoyage.Metier;
using AppliBoVoyage.Dal;

namespace AppliBoVoyage.UI
{
    public class SousModuleDestination
    {

        private Menu menu;

        private void MenuDestination()
        {
            this.menu = new Menu("Gestion des destination");
            this.menu.AjouterElement(new ElementMenu("1", "Consulter destinations")
            {
                FonctionAExecuter = this.ConsulterDestination
            });
            this.menu.AjouterElement(new ElementMenu("2", "Ajouter destination")
            {
                FonctionAExecuter = this.AjouterDestination
            });
            this.menu.AjouterElement(new ElementMenu("3", "Modifier destination")
            {
                FonctionAExecuter = this.SupprimerDestination
            });
            this.menu.AjouterElement(new ElementMenu("4", "Supprimer destination")
            {
                FonctionAExecuter = this.SupprimerDestination
            });
            this.menu.AjouterElement(new ElementMenuQuitterMenu("R", "Revenir au menu principal..."));
        }

        public void Demarrer()
        {
            if (this.menu == null)
            {
                this.MenuDestination();
            }

            this.menu.Afficher();
        }



        private void ConsulterDestination()
        {
            ConsoleHelper.AfficherEntete("Destination");

        }



        private void AjouterDestination()
        {
            ConsoleHelper.AfficherEntete("Nouvelle destination");
            var destination = new Destination();
            {

                destination.Pays = ConsoleSaisie.SaisirChaineObligatoire("Pays de destination: ");
                destination.Region = ConsoleSaisie.SaisirChaineObligatoire("Region de destination: ");
                destination.Continent = ConsoleSaisie.SaisirChaineOptionnelle("Continent: ");
                destination.Description = ConsoleSaisie.SaisirChaineOptionnelle("Description de la destination: ");

            }
            var db = new BaseDonnees();
            db.Destinations.Add(destination);
            db.SaveChanges();

        }

        private void ModifierDestination()
        {
            ConsoleHelper.AfficherEntete("Modifier une destination");

        }

        private void SupprimerDestination()
        {
            ConsoleHelper.AfficherEntete("Supprimer une offre");

        }
    }
    
}






   

