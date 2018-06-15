using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppliBoVoyage.Metier
{
    [Table("AgencesVoyage")]
    public class AgenceVoyage
    {
        public string Nom { get; set; }

        public int Id { get; set; }

        //public virtual ICollection<Voyage> Voyages { get; set; }

        //public string DescriptionVoyage { get; set; }
        //[ForeignKey ("Voyage")]
        //public virtual Destination Description { get, set; }
    }
}
