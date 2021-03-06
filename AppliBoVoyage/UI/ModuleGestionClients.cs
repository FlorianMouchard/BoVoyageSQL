﻿using AppliBoVoyage.Dal;
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
                InformationAffichage.Creer<Client>(x=>x.Nom, "Nom", 15),
                InformationAffichage.Creer<Client>(x=>x.Prenom, "Prénom", 15),
                InformationAffichage.Creer<Client>(x=>x.Adresse, "Adresse", 30),
                InformationAffichage.Creer<Client>(x=>x.Telephone, "Téléphone", 10),
                InformationAffichage.Creer<Client>(x=>x.Email, "Email", 30),
                InformationAffichage.Creer<Client>(x=>x.DateNaissance, "Date de naissance", 17),
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
            var rechercheClient = ConsoleSaisie.SaisirChaineObligatoire("Nom : ");       
                            
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
           
            context.Clients.Add(client);
            context.SaveChanges();
        }
        private void ModifierClient()
        {
            ConsoleHelper.AfficherEntete("Modifier un client");
            Console.WriteLine("Entrez le nom du client à modifier");
            RechercherClient();
            Console.WriteLine("Entrez l'Id du client à modifier");
            var modifier = ConsoleSaisie.SaisirEntierObligatoire("Id : ");
            using (BaseDonnees context = new BaseDonnees())
            {
                var query = context.Clients
                    .First(x => x.Id.Equals(modifier));

                query.Civilite = ConsoleSaisie.SaisirChaineObligatoire("Civilité : ");
                query.Nom = ConsoleSaisie.SaisirChaineObligatoire("Nom : ");
                query.Prenom = ConsoleSaisie.SaisirChaineObligatoire("Prénom : ");
                query.Adresse = ConsoleSaisie.SaisirChaineObligatoire("Adresse : ");
                query.Telephone = ConsoleSaisie.SaisirChaineObligatoire("Téléphone : ");
                query.Email = ConsoleSaisie.SaisirChaineObligatoire("Email : ");
                query.DateNaissance = ConsoleSaisie.SaisirDateObligatoire("Date de naissance : ");
                                
                context.SaveChanges();
            }
        }
        private void SupprimerClient()
        {
            ConsoleHelper.AfficherEntete("Supprimer un client");
            Console.WriteLine("Entrez le nom du client à supprimer: ");
            RechercherClient();
            Console.WriteLine("Entrez l'Id du client à supprimer");
            var supprimerClient = ConsoleSaisie.SaisirEntierObligatoire("Id : ");
            using (BaseDonnees context = new BaseDonnees())
            {
                var query = context.Clients
                    .First(x => x.Id.Equals(supprimerClient));
                context.Clients.Remove(query);
                context.SaveChanges();
            }
            
        }
    }
}
