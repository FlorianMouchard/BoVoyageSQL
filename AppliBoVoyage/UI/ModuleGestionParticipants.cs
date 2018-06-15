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
                InformationAffichage.Creer<Participant>(x=>x.Nom, "Nom", 20),
                InformationAffichage.Creer<Participant>(x=>x.Prenom, "Prénom", 20),
                InformationAffichage.Creer<Participant>(x=>x.Adresse, "Adresse", 50),
                InformationAffichage.Creer<Participant>(x=>x.Telephone, "Téléphone", 10),
                InformationAffichage.Creer<Participant>(x=>x.DateNaissance, "Date naissance", 15),
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
            //participant.Age = DateTime.Now.Year - participant.DateNaissance.Year -
            //             (DateTime.Now.Month < participant.DateNaissance.Month ? 1 :
            //             DateTime.Now.Day < participant.DateNaissance.Day ? 1 : 0);
            context.Participants.Add(participant);
            context.SaveChanges();
        }
        private void ModifierParticipant()
        {
            ConsoleHelper.AfficherEntete("Modifier un participant");
        }
        private void SupprimerParticipant()
        {
            ConsoleHelper.AfficherEntete("Supprimer un participant");
        }
    }
}
