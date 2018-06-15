using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoVoyage.Framework.UI;
using System.Linq;
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
                FonctionAExecuter = this.SupprimerOffre
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
                voyage.TarifToutCompris = ConsoleSaisie.SaisirDecimalObligatoire("Prix du voyage tout compris: ");
            }
            var db = new BaseDonnees();
            db.Voyages.Add(voyage);
            db.SaveChanges();


        }

        private void ModifierOffre()
        {
            ConsoleHelper.AfficherEntete("Modifier une offre");

        }

        private void SupprimerOffre()
        {
            ConsoleHelper.AfficherEntete("Supprimer une offre");

        }
       
    }


}






