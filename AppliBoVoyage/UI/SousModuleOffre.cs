using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoVoyage.Framework.UI;
using AppliBoVoyage.Metier;
using AppliBoVoyage.Dal;
using BoVoyage.UI;


namespace AppliBoVoyage.UI
{
    public class SousModuleOffre
    {
        private Menu menu;

        private static readonly List<InformationAffichage> strategieAffichageOffres
                = new List<InformationAffichage>();
        static SousModuleOffre()
        {
            strategieAffichageOffres = new List<InformationAffichage>
            {
            InformationAffichage.Creer<Voyage>(x => x.Id, "Id Voyage", 12),
            InformationAffichage.Creer<Voyage>(x => x.DateAller, "Du", 12),
            InformationAffichage.Creer<Voyage>(x => x.DateRetour, "Au", 15),
            InformationAffichage.Creer<Voyage>(x => x.PlacesDisponibles, "Places", 6),
            InformationAffichage.Creer<Voyage>(x => x.IdDestination, "Dest.", 6),
            InformationAffichage.Creer<Voyage>(x => x.IdAgence, "Proposé par", 15),
            InformationAffichage.Creer<Voyage>(x => x.TarifToutCompris, "Prix agence", 15),
            };
        }

        private void MenuOffre()
        {
            this.menu = new Menu("Gestion des offres");
            this.menu.AjouterElement(new ElementMenu("1", "Consulter offre")
            {
                FonctionAExecuter = this.ConsulterOffre
            });
            this.menu.AjouterElement(new ElementMenu("2", "Ajouter offre")
            {
                FonctionAExecuter = this.AjouterOffre
            });
            this.menu.AjouterElement(new ElementMenu("3", "Modifier offre")
            {
                FonctionAExecuter = this.ModifierOffre
            });
            this.menu.AjouterElement(new ElementMenu("4", "Supprimer offre")
            {
                FonctionAExecuter = this.SupprimerOffre
            });
            this.menu.AjouterElement(new ElementMenuQuitterMenu("R", "Revenir au menu principal..."));
        }

        public void Demarrer()
        {
            if (this.menu == null)
            {
                this.MenuOffre();
            }

            this.menu.Afficher();
        }



        private void ConsulterOffre()
        {
            ConsoleHelper.AfficherEntete("Offres");


            var liste = Application.GetBaseDonnees().Voyages.ToList();
            ConsoleHelper.AfficherListe(liste, strategieAffichageOffres);

        }

        private void AjouterOffre()
        {
            ConsoleHelper.AfficherEntete("Nouvelle offre");
            var voyage = new Voyage();
            {
                voyage.DateAller = ConsoleSaisie.SaisirDateObligatoire("Date aller: ");
                voyage.DateRetour = ConsoleSaisie.SaisirDateObligatoire("Date retour: ");
                voyage.PlacesDisponibles = ConsoleSaisie.SaisirEntierObligatoire("Nombre de place(s) disponible(s) :");
                voyage.IdDestination = ConsoleSaisie.SaisirEntierObligatoire("ID de la destination :");
                voyage.TarifToutCompris = ConsoleSaisie.SaisirDecimalObligatoire("Prix du voyage tout compris: ");
                voyage.IdAgence = ConsoleSaisie.SaisirEntierObligatoire("ID de l'agence de voyage :");
            }
            var db = new BaseDonnees();
            db.Voyages.Add(voyage);
            db.SaveChanges();


        }

        private void ModifierOffre()
        {
            ConsoleHelper.AfficherEntete("Modifier une offre");
            Console.WriteLine("Entrez le nom de l'offre à modifier");
            RechercherOffre();
            Console.WriteLine("Entrez l'Id de l'offre à modifier");
            var modifier = ConsoleSaisie.SaisirEntierObligatoire("Id : ");
            using (BaseDonnees context = new BaseDonnees())
            {
                var query = context.Voyages
                    .First(x => x.Id.Equals(modifier));

                query.DateAller = ConsoleSaisie.SaisirDateObligatoire("Date aller : ");
                query.DateRetour = ConsoleSaisie.SaisirDateObligatoire("Date retour : ");
                query.PlacesDisponibles = ConsoleSaisie.SaisirEntierObligatoire("Nombre de place disponible : ");
                query.IdDestination = ConsoleSaisie.SaisirEntierObligatoire("IdDestination : ");
                query.IdAgence = ConsoleSaisie.SaisirEntierObligatoire("IdAgence : ");


                context.SaveChanges();
            }


        }

        private void SupprimerOffre()
        {
            ConsoleHelper.AfficherEntete("Supprimer une offre");
            Console.WriteLine("Entrez l'Id de la destination à supprimer: ");
            RechercherOffre();
            
            var supprimerOffre = ConsoleSaisie.SaisirEntierObligatoire("Confirmez l'Id de l'offre à supprimer : ");
            using (BaseDonnees context = new BaseDonnees())
            {
                var query = context.Voyages
                    .First(x => x.Id.Equals(supprimerOffre));
                context.Voyages.Remove(query);
                context.SaveChanges();
            }

        }
        private void RechercherOffre()
        {
           
            var rechercheOffre =

                 ConsoleSaisie.SaisirEntierObligatoire("IdDestination : ");


            using (BaseDonnees context = new BaseDonnees())
            {
                var query = context.Voyages
                    .Where(x => x.IdDestination.Equals(rechercheOffre)).ToList();
                ConsoleHelper.AfficherListe(query, strategieAffichageOffres);

            }
        }

    }


}






