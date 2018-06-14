using AppliBoVoyage.Metier;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AppliBoVoyage.Dal
{
    public class BaseDonnees : DbContext
    {
        public BaseDonnees(string connectionString = "Connexion")
            : base(connectionString)
        {
        }

        public DbSet<AgenceVoyage> AgencesVoyage { get; set; }

        public DbSet<Assurance> Assurances { get; set; }

        public DbSet<AssuranceAnnulation> AssurancesAnnulation { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Destination> Destinations { get; set; }

        public DbSet<DossierReservation> DossiersReservation { get; set; }

        public DbSet<Participant> Participants { get; set; }

        public DbSet<Voyage> Voyages { get; set; }
      
        
    }
}
