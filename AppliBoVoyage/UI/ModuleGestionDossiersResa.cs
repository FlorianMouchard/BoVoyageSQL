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

        private static readonly List<InformationAffichage> strategieAffichageDossiers
        = new List<InformationAffichage>();
        static ModuleGestionDossiersResa()
        {
            strategieAffichageDossiers = new List<InformationAffichage>
            {
            InformationAffichage.Creer<DossierReservation>(x => x.Id, "Id Dossier", 12),
            InformationAffichage.Creer<DossierReservation>(x => x.IdVoyage, "Voyage", 12),
            InformationAffichage.Creer<DossierReservation>(x => x.IdClient, "Client", 15),

            };
        }


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

            RechercherResa();

            Console.WriteLine("Pour modifier l'enregistrement, appuyer sur M...");
        }


        private void CreerResa()
        {
            ConsoleHelper.AfficherEntete("Nouvelle reservation");


            var dossierResa = new DossierReservation();
            {
                dossierResa.Clients.Nom = ConsoleSaisie.SaisirChaineObligatoire("Nom du client: ");
                dossierResa.IdVoyage = ConsoleSaisie.SaisirEntierObligatoire("Voyage : ");
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

            RechercherResa();

            Console.WriteLine("Entrer le numéro du dossier à supprimer: ");
            int dossierASupprimer = int.Parse(Console.ReadLine());

            using (BaseDonnees context = new BaseDonnees())
            {
                var query = context.DossiersReservation.First(x => x.Id.Equals(dossierASupprimer));
                context.DossiersReservation.Remove(query);
                context.SaveChanges();
            }

        }
        private void RechercherResa()
        {

            Console.WriteLine("Entrer le client ID: ");
            var clientAAfficher = int.Parse(Console.ReadLine());

            using (BaseDonnees context = new BaseDonnees())
            {
                var query = context.DossiersReservation
                    .Where(x => x.IdClient.Equals(clientAAfficher)).ToList();
                ConsoleHelper.AfficherListe(query, strategieAffichageDossiers);

            }
        }
        private void ModifierDossier()
        {
            ConsoleHelper.AfficherEntete("Modifier un dossier");
            Console.WriteLine("Entrez l'Id du Dossier à modifier");
            RechercherResa();

            var modifier = ConsoleSaisie.SaisirEntierObligatoire("Id : ");
            using (BaseDonnees context = new BaseDonnees())
            {
                var query = context.DossiersReservation
                    .First(x => x.Id.Equals(modifier));

                query.NumeroCarteBancaire = ConsoleSaisie.SaisirChaineObligatoire("Numéro de la carte bancaire : ");
                query.IdClient = ConsoleSaisie.SaisirEntierObligatoire("IdClient : ");
                query.NombreParticipants = ConsoleSaisie.SaisirEntierObligatoire("Nombre de participant : ");
                query.IdVoyage = ConsoleSaisie.SaisirEntierObligatoire("IdVoyage : ");


                context.SaveChanges();
            }
        }
    }
}





