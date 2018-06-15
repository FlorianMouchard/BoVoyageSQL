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
    public class SousModuleAgence
    {
        private Menu menu;

        private static readonly List<InformationAffichage> strategieAffichageAgences
            = new List<InformationAffichage>();
        static SousModuleAgence()
        {
            strategieAffichageAgences = new List<InformationAffichage>
            {
            InformationAffichage.Creer<AgenceVoyage>(x => x.Id, "Id Agence :", 10),
            InformationAffichage.Creer<AgenceVoyage>(x => x.Nom, "Raison sociale :", 20),

            };
        }

        private void MenuAgence()
        {
            this.menu = new Menu("Gestion des agences");
            this.menu.AjouterElement(new ElementMenu("1", "Consulter agences")
            {
                FonctionAExecuter = this.ConsulterAgence
            });
            this.menu.AjouterElement(new ElementMenu("2", "Ajouter agence")
            {
                FonctionAExecuter = this.AjouterAgence
            });
            this.menu.AjouterElement(new ElementMenu("3", "Modifier agence")
            {
                FonctionAExecuter = this.ModifierAgence
            });
            this.menu.AjouterElement(new ElementMenu("4", "Supprimer agence")
            {
                FonctionAExecuter = this.SupprimerAgence
            });
            this.menu.AjouterElement(new ElementMenuQuitterMenu("R", "Revenir au menu principal..."));
        }

        public void Demarrer()
        {
            if (this.menu == null)
            {
                this.MenuAgence();
            }

            this.menu.Afficher();
        }



        private void ConsulterAgence()
        {
            ConsoleHelper.AfficherEntete("Les agences");

            var liste = Application.GetBaseDonnees().AgencesVoyage.ToList();
            ConsoleHelper.AfficherListe(liste, strategieAffichageAgences);

        }


        private void AjouterAgence()
        {
            ConsoleHelper.AfficherEntete("Nouvelle agence");
            var agence = new AgenceVoyage ();
            {
                agence.Nom = ConsoleSaisie.SaisirChaineObligatoire("Raison Sociale: ");
            }

            var db = new BaseDonnees();
            db.AgencesVoyage.Add(agence);
            db.SaveChanges();
        }


        private void ModifierAgence()
        {
            ConsoleHelper.AfficherEntete("Modification d'une agence");

        }


        private void SupprimerAgence()
        {
            ConsoleHelper.AfficherEntete("Supprimer une agence");

        }
        private void RechercherAgence()
        {
            ConsoleHelper.AfficherEntete("Rechercher une agence");
            var rechercheAgence =

                 ConsoleSaisie.SaisirChaineObligatoire("Nom : ");


            using (BaseDonnees context = new BaseDonnees())
            {
                var query = context.AgencesVoyage
                    .Where(x => x.Nom.Contains(rechercheAgence)).ToList();
                ConsoleHelper.AfficherListe(query, strategieAffichageAgences);

            }
        }

    }




}






