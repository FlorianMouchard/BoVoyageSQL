using AppliBoVoyage.Dal;
using AppliBoVoyage.Metier;
using BoVoyage.Framework.UI;
using BoVoyage.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliBoVoyage.UI
{
    public class ModuleGestionParticipants
    {
        private Menu menu;
        private static readonly List<InformationAffichage> strategieAffichageParticipants
           = new List<InformationAffichage>();
        static ModuleGestionParticipants()
        {

            strategieAffichageParticipants = new List<InformationAffichage>
            {
                InformationAffichage.Creer<Participant>(x=>x.Id, "Id", 3),
                InformationAffichage.Creer<Participant>(x=>x.Nom, "Nom", 15),
                InformationAffichage.Creer<Participant>(x=>x.Prenom, "Prénom", 15),
                InformationAffichage.Creer<Participant>(x=>x.Adresse, "Adresse", 30),
                InformationAffichage.Creer<Participant>(x=>x.Telephone, "Téléphone", 10),
                InformationAffichage.Creer<Participant>(x=>x.DateNaissance, "Date naissance", 17),
                InformationAffichage.Creer<Participant>(x=>x.Age, "Age", 3),
                InformationAffichage.Creer<Participant>(x=>x.Reduction, "Réduction", 10),

            };
        }

        private void InitialiserMenu()
        {
            this.menu = new Menu("Gestion des accompagnants");
            this.menu.AjouterElement(new ElementMenu("1", "Consulter la liste des participants")
            {
                FonctionAExecuter = this.ConsulterParticipants
            });
            this.menu.AjouterElement(new ElementMenu("2", "Rechercher un participant")
            {
                FonctionAExecuter = this.RechercherParticipant
            });
            this.menu.AjouterElement(new ElementMenu("3", "Ajouter un participant")
            {
                FonctionAExecuter = this.AjouterParticipant
            });
            this.menu.AjouterElement(new ElementMenu("4", "Modifier un participant")
            {
                FonctionAExecuter = this.ModifierParticipant
            });
            this.menu.AjouterElement(new ElementMenu("5", "Supprimer un participant")
            {
                FonctionAExecuter = this.SupprimerParticipant
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
        private void ConsulterParticipants()
        {
            ConsoleHelper.AfficherEntete("Liste des participants");            
            var liste = Application.GetBaseDonnees().Participants.ToList();
            ConsoleHelper.AfficherListe(liste, strategieAffichageParticipants);
        }
        private void RechercherParticipant()
        {
            ConsoleHelper.AfficherEntete("Rechercher un participant");
            var rechercheParticipant =

                 ConsoleSaisie.SaisirChaineObligatoire("Nom : ");


            using (BaseDonnees context = new BaseDonnees())
            {
                var query = context.Participants
                    .Where(x => x.Nom.Contains(rechercheParticipant)).ToList();
                ConsoleHelper.AfficherListe(query, strategieAffichageParticipants);

            }
        }
        private void AjouterParticipant()
        {
            ConsoleHelper.AfficherEntete("Ajouter un participant");
            BaseDonnees context = new BaseDonnees();
            var participant = new Participant
            {
                Civilite = ConsoleSaisie.SaisirChaineObligatoire("Civilité : "),
                Nom = ConsoleSaisie.SaisirChaineObligatoire("Nom : "),
                Prenom = ConsoleSaisie.SaisirChaineObligatoire("Prénom : "),
                Adresse = ConsoleSaisie.SaisirChaineObligatoire("Adresse : "),
                Telephone = ConsoleSaisie.SaisirChaineObligatoire("Téléphone : "),
                DateNaissance = ConsoleSaisie.SaisirDateObligatoire("Date de naissance : "),                
                Reduction = ConsoleSaisie.SaisirDecimalObligatoire("Réduction : ")

            };
            
            context.Participants.Add(participant);
            context.SaveChanges();
        }
        private void ModifierParticipant()
        {
            ConsoleHelper.AfficherEntete("Modifier un participant");
            Console.WriteLine("Entrez le nom du Participant à modifier");
            RechercherParticipant();
            Console.WriteLine("Entrez l'Id du participant à modifier");
            var modifier = ConsoleSaisie.SaisirEntierObligatoire("Id : ");
            using (BaseDonnees context = new BaseDonnees())
            {
                var query = context.Participants
                    .First(x => x.Id.Equals(modifier));

                query.Civilite = ConsoleSaisie.SaisirChaineObligatoire("Civilité : ");
                query.Nom = ConsoleSaisie.SaisirChaineObligatoire("Nom : ");
                query.Prenom = ConsoleSaisie.SaisirChaineObligatoire("Prénom : ");
                query.Adresse = ConsoleSaisie.SaisirChaineObligatoire("Adresse : ");
                query.Telephone = ConsoleSaisie.SaisirChaineObligatoire("Téléphone : ");
                query.DateNaissance = ConsoleSaisie.SaisirDateObligatoire("Date de naissance : ");
                query.Reduction = ConsoleSaisie.SaisirDecimalObligatoire("Réduction : ");

                context.SaveChanges();
            }
        }
        private void SupprimerParticipant()
        {
            ConsoleHelper.AfficherEntete("Supprimer un participant");
            ConsoleHelper.AfficherEntete("Supprimer un participant");
            Console.WriteLine("Entrez le nom du participant à supprimer: ");
            RechercherParticipant();
            Console.WriteLine("Entrez l'Id du participant à supprimer");
            var supprimerParticipant = ConsoleSaisie.SaisirEntierObligatoire("Id : ");
            using (BaseDonnees context = new BaseDonnees())
            {
                var query = context.Participants
                    .First(x => x.Id.Equals(supprimerParticipant));
                context.Participants.Remove(query);
                context.SaveChanges();
            }
        }
    }
}
