using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliBoVoyage.Metier
{
    public class Participant:Personne
    {
        public int NumeroUnique { get; set; }
        public float Reduction { get; set; }
    }
}
