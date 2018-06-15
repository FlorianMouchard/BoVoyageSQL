using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoVoyage.Framework.UI;


namespace AppliBoVoyage.Metier
{
    [Table("DossiersReservation")]
    public class DossierReservation
    {
        public int Id { get; set; }

        //[InformationAffichage(Entete = "Nom Client", NombreCaracteres = 30)]
        public int IdClient { get; set; }
        [ForeignKey("IdClient")]
        public virtual Client Clients { get; set; }


        public int IdVoyage { get; set; }
        [ForeignKey("IdVoyage")]
        public virtual Voyage Voyages { get; set; }





        //public DateTime DateAller { get; set; }
        //[ForeignKey("DateAller")]

        //public DateTime DateRetour { get; set; }
        //[ForeignKey("DateRetour")]
        //public virtual Voyage Voyages { get; set; }

        //public int NombreVoyageurs { count.Participants; set; }
        //[ForeignKey("Voyageurs")]
        //public virtual Participant Participants { get; set; }

        public string NumeroCarteBancaire { get; set; }

        //public decimal PrixTotal()
        //{
        //    switch (PrixTotal)
        //    {
        //        int TarifVoyage = Voyage.TarifToutCompris;
        //    int Reduction = Participant.reduction;

        //        case (Reduction == null):
        //            decimal PrixTotal = TarifVoyage + 10 %;
        //    break;
        //        case (Reduction > 0):
        //            decimal PrixTotal = TarifVoyage + Reduction + 10 %;
        //    break;

        //}
    }
}

