﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppliBoVoyage.Metier
{
    public class Destination
    {
        public int Id { get; set; }
        public string Continent { get; set; }
        public string Pays { get; set; }
        public string Region { get; set; }
        public string Description { get; set; }


        public virtual ICollection<Voyage> Voyages { get; set; }
        public virtual ICollection<DossierReservation> DossierReservations { get; set; }
    }
}
