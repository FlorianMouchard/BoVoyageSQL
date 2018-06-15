using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoVoyage.Framework.UI;



namespace AppliBoVoyage.Metier
{
    public class Voyage
    {
        public int Id { get; set; }

        public DateTime DateAller { get; set; }

        public DateTime DateRetour { get; set; }

        public int PlacesDisponibles { get; set; }

        public decimal TarifToutCompris { get; set; }

        public int IdDestination { get; set; }
        [ForeignKey("IdDestination")]
        public virtual Destination Destinations { get; set; }

        public int IdAgence { get; set; }
        [ForeignKey("IdAgence")]
        public virtual AgenceVoyage AgencesVoyage { get; set; }
    }
}
