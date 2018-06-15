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
    public class ModuleGestionClients
    {
        private Menu menu;

        private static readonly List<InformationAffichage> strategieAffichageClients
            = new List<InformationAffichage>();
        static ModuleGestionClients()
        {

            strategieAffichageClients = new List<InformationAffichage>
            {
                InformationAffichage.Creer<Client>(x=>x.Id, "Id", 3),
                InformationAffichage.Creer<Client>(x=>x.Nom, "Nom", 20),
                InformationAffichage.Creer<Client>(x=>x.Prenom, "Prénom", 20),
                InformationAffichage.Creer<Client>(x=>x.Adresse, "Adresse", 50),
                InformationAffichage.Creer<Client>(x=>x.Telephone, "Téléphone", 10),
                InformationAffichage.Creer<Client>(x=>x.Email, "Email", 50),
                InformationAffichage.Creer<Client>(x=>x.DateNaissance, "Date de naissance", 10),
                InformationAffichage.Creer<Client>(x=>x.Age, "Age", 3)

            };
        }
        private void InitialiserMenu()
        {
            this.menu = new Menu("Gestion des clients");
            this.menu.AjouterElement(new ElementMenu("1", "Consulter la liste des clients")
            {
                FonctionAExecuter = this.ConsulterClients
            });
            this.menu.AjouterElement(new ElementMenu("2", "Rechercher un client")
            {
                FonctionAExecuter = this.RechercherClient
            });
            this.menu.AjouterElement(new ElementMenu("3", "Ajouter un client")
            {
                FonctionAExecuter = this.AjouterClient
            });
            this.menu.AjouterElement(new ElementMenu("4", "Modifier un client")
            {
                FonctionAExecuter = this.ModifierClient
            });
            this.menu.AjouterElement(new ElementMenu("5", "Supprimer un client")
            {
                FonctionAExecuter = this.SupprimerClient
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
        private void ConsulterClients()
        {
            ConsoleHelper.AfficherEntete("Liste des clients");
            var liste = Application.GetBaseDonnees().Clients.ToList();
            ConsoleHelper.AfficherListe(liste, strategieAffichageClients);

        }
        private void RechercherClient()
        {
            ConsoleHelper.AfficherEntete("Rechercher un client");
            var rechercheClient =

                 ConsoleSaisie.SaisirChaineObligatoire("Nom : ");         
                
            
            using (BaseDonnees context = new BaseDonnees())
            {
                var query = context.Clients
                    .Where(x => x.Nom.Contains(rechercheClient)).ToList();
                ConsoleHelper.AfficherListe(query, strategieAffichageClients);

            }
            

        }
        private void AjouterClient()
        {
            ConsoleHelper.AfficherEntete("Ajouter un client");
            BaseDonnees context = new BaseDonnees();
            var client = new Client
            {
                Civilite = ConsoleSaisie.SaisirChaineObligatoire("Civilité : "),
                Nom = ConsoleSaisie.SaisirChaineObligatoire("Nom : "),
                Prenom = ConsoleSaisie.SaisirChaineObligatoire("Prénom : "),
                Adresse = ConsoleSaisie.SaisirChaineObligatoire("Adresse : "),
                Telephone = ConsoleSaisie.SaisirChaineObligatoire("Téléphone : "),
                Email = ConsoleSaisie.SaisirChaineObligatoire("Email : "),
                DateNaissance = ConsoleSaisie.SaisirDateObligatoire("Date de naissance : "),

            };

            client.Age = DateTime.Now.Year - client.DateNaissance.Year -
                         (DateTime.Now.Month < client.DateNaissance.Month ? 1 :
                         DateTime.Now.Day < client.DateNaissance.Day ? 1 : 0);
            context.Clients.Add(client);
            context.SaveChanges();
        }
        private void ModifierClient()
        {
            ConsoleHelper.AfficherEntete("Modifier un client");
        }
        private void SupprimerClient()
        {
            ConsoleHelper.AfficherEntete("Supprimer un client");
        }
    }
}
