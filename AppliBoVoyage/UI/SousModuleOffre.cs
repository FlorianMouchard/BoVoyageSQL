using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoVoyage.Framework.UI;

namespace AppliBoVoyage.UI
{
    class SousModuleOffre
     {
            private Menu menu;

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
                        
            }


            private void AjouterOffre()
            {
                ConsoleHelper.AfficherEntete("Nouvelle offre");

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






