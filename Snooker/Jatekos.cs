using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snooker
{
    internal class Jatekos
    {
        public int Helyezes;
        public string Nev;
        public string Orszag;
        public int Nyeremeny;

        public Jatekos(string Adatsor)
        {
            string[] AdatSorElemek = Adatsor.Split(';');
            this.Helyezes = int.Parse(AdatSorElemek[0]);
            this.Nev = AdatSorElemek[1];
            this.Orszag = AdatSorElemek[2];
            this.Nyeremeny = int.Parse(AdatSorElemek[3]);
        }
    }
}
