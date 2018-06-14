using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoVoyage.Framework.UI;
using AppliBoVoyage.UI;

namespace AppliBoVoyage.UI
{
    public class ModuleGestionVoyages
       {
        private Menu menu;
        private SousModuleAgence sousModuleAgence;
        private SousModuleOffre sousModuleOffre;
        private SousModuleDestination sousModuleDestination;

        private void InitialisatonModules()
        {
            this.sousModuleAgence = new SousModuleAgence();
            this.sousModuleOffre = new SousModuleOffre();
            this.sousModuleDestination = new SousModuleDestination();
        }


        private void InitialiserMenuVoyages()
        {
            this.menu = new Menu("Gestion des voyages");
            this.menu.AjouterElement(new ElementMenu("1", "Offres")
            {
                FonctionAExecuter = this.sousModuleOffre.Demarrer
            });
            this.menu.AjouterElement(new ElementMenu("2", "Destinations")
            {
                FonctionAExecuter = this.sousModuleDestination.Demarrer
            });
           this.menu.AjouterElement(new ElementMenu("3", "Agences")
            {
                FonctionAExecuter = this.sousModuleAgence.Demarrer
            });
            this.menu.AjouterElement(new ElementMenuQuitterMenu("R", "Revenir au menu principal..."));
        }

        public void Demarrer()
        {
            if (this.menu == null)
            {
                this.InitialiserMenuVoyages();
            }
          this.menu.Afficher();
        }

       
    }
            
 }

   
