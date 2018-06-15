using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoVoyage.Framework.UI;
using AppliBoVoyage.Metier;
using AppliBoVoyage.Dal;

namespace AppliBoVoyage.UI
{
    public class ModuleGestionDossiersResa
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
        //    ConsoleHelper.AfficherEntete("Dossier de reservation");

        //    Console.WriteLine("Entrer le numéro du Client à afficher: ");
        //    int clientAAfficher = int.Parse(Console.ReadLine());

        //    using (BaseDonnees context = new BaseDonnees())
        //    {
        //        var ClientAAfficher = BaseDonnees.DossierResa.where(x => x.IdClient == ClientAAfficher);
        //    }
        //    Console.WriteLine("Pour modifier l'enregistrement, appuyer sur M...");
        }


        private void CreerResa()
        {
            ConsoleHelper.AfficherEntete("Nouvelle reservation");


            var dossierResa = new DossierReservation();
            {
                dossierResa.Clients.Nom = ConsoleSaisie.SaisirChaineObligatoire("Nom du client: ");
                dossierResa.Pays = ConsoleSaisie.SaisirChaineObligatoire("Pays de destination: ");
                dossierResa.DateAller = ConsoleSaisie.SaisirDateObligatoire("Date Aller: ");
                dossierResa.DateRetour = ConsoleSaisie.SaisirDateObligatoire("Date Retour: ");
                dossierResa.NumeroCarteBancaire = ConsoleSaisie.SaisirChaineObligatoire("Numero de carte bancaire: ");
                dossierResa.IdClient = ConsoleSaisie.SaisirEntierObligatoire("Identifiant du client: ");
            }

            var db = new BaseDonnees();
            db.DossiersReservation.Add(dossierResa);
            db.SaveChanges();
        }

        private void SupprimerResa()
        {
            ConsoleHelper.AfficherEntete("Supprimer une reservation");

            //Console.WriteLine("Entrer le numéro du Client à supprimer: ");
            //int clientASupprimer = int.Parse(Console.ReadLine());

            //using (BaseDonnees context = new BaseDonnees())
            //{
            //    var ClientASupprimer = BaseDonnees.DossierResa.where(x => x.IdClient == ClientAAfficher);
            //}



        }
    }
}





