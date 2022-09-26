using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Snooker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //2.feladat
            StreamReader olvas = new StreamReader("snooker.txt",Encoding.Default);
            List<Jatekos> Snooker = new List<Jatekos>();
            string fejlec = olvas.ReadLine();
            while (!olvas.EndOfStream)
            {
                Snooker.Add(new Jatekos(olvas.ReadLine()));
            }
            olvas.Close();

            //3.feladat
            Console.WriteLine($"3.feladat: A világranglistán {Snooker.Count} versenyző szerepel.");

            //4.feladat
            double Ossznyeremeny = 0;
            for (int i = 0; i < Snooker.Count; i++)
            {
                Ossznyeremeny += Snooker[i].Nyeremeny;
            }
            Console.WriteLine($"4.feladat: A versenyzők átlagosan {Ossznyeremeny/Snooker.Count} fontot kerestek.");

            //5.feladat
            Console.WriteLine("5.feladat: A legjobban kereső Kínai versenyző:");
            int legjobb = Snooker[0].Nyeremeny;
            for (int i = 0; i < Snooker.Count; i++)
            {
                if(Snooker[i].Orszag == "Kína" && Snooker[i].Nyeremeny > legjobb)
                {
                    legjobb = Snooker[i].Nyeremeny;
                }
            }
            for (int i = 0; i < Snooker.Count; i++)
            {
                if(Snooker[i].Nyeremeny == legjobb)
                {
                    decimal formatum = Snooker[i].Nyeremeny * 380;
                    string s = formatum.ToString("C0");
                    Console.WriteLine($"\tHelyezés: {Snooker[i].Helyezes}");
                    Console.WriteLine($"\tNév: {Snooker[i].Nev}");
                    Console.WriteLine($"\tOrszág: {Snooker[i].Orszag}");
                    Console.WriteLine($"\tNyeremény összege: {s}");
                }
            }

            //6.feladat
            bool VanENorveg = false;
            for (int i = 0; i < Snooker.Count; i++)
            {
                if (Snooker[i].Orszag == "Norvég")
                {
                    VanENorveg = true; 
                }
            }
            if (VanENorveg == true)
            {
                Console.WriteLine($"6.feladat: A versenyzők között van Norvég versenyző.");
            }
            else
            {
                Console.WriteLine($"6.feladat: A versenyzők között nincs Norvég versenyző.");
            }

            //7.feladat
            List<string> OrszagLista = new List<string>();
            for (int i = 0; i < Snooker.Count; i++)
            {
                bool SzerepelE = false;
                for (int j = 0; j < OrszagLista.Count; j++)
                {
                    if(Snooker[i].Orszag == OrszagLista[j])
                    {
                        SzerepelE = true;
                    }
                }
                if(SzerepelE == false)
                {
                    OrszagLista.Add(Snooker[i].Orszag);
                }
            }
            int[] OrszagListaSeged  = new int[OrszagLista.Count];
            for (int i = 0; i < Snooker.Count; i++)
            {
                for (int j = 0; j < OrszagLista.Count; j++)
                { 
                    if(Snooker[i].Orszag == OrszagLista[j])
                    {
                        OrszagListaSeged[j]++;
                    }
                }
            }
            Console.WriteLine("7.feladat: Statisztika");
            for (int i = 0; i < OrszagListaSeged.Length; i++)
            {
                if (OrszagListaSeged[i] > 4)
                {
                    Console.WriteLine($"\t{OrszagLista[i]} - {OrszagListaSeged[i]} fő");
                }
            }

            Console.WriteLine("\nProgram vége!");
            Console.ReadKey();
        }
    }
}
