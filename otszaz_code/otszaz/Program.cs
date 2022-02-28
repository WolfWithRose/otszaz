using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace otszaz
{
    class Program
    {
        static int arfuggveny(int darabszam)
        {
            int ar = 0;
            for (int i = 0; i < darabszam; i++)
            {
                if (i > 1)
                {
                    ar += 400;
                }
                else
                {
                    ar += 500 - (i * 50);
                }
            }
            return ar;
        }
        static void Main(string[] args)
        {
            string[] sorok = File.ReadAllLines("penztar.txt");
            List<List<string>> lista = new List<List<string>>();
            List<string> adat = new List<string>();
            foreach (string sor in sorok)
            {                
                if (sor != "F")
                {
                    adat.Add(sor);
                }
                else
                {
                    lista.Add(adat);
                    adat = new List<string>();
                }
            }

            /*
            Console.WriteLine(lista.Count());
            for (int i = 0; i < lista.Count(); i++)
            {
                foreach (string item in lista[i])
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
            */

            Console.WriteLine("2. feladat");
            Console.WriteLine($"A fizetések száma: {lista.Count()}");
            Console.WriteLine();
            Console.WriteLine("3. feladat");
            Console.WriteLine($"Az első vásárló {lista[0].Count()} darab árucikket vásárolt.");
            Console.WriteLine();
            Console.WriteLine("4. feladat");
            Console.Write("Adja meg egy vásárlás sorszámát! ");
            int sorszam = int.Parse(Console.ReadLine()) - 1;
            Console.Write("Adja meg egy árucikk nevét! ");
            string arunev = Console.ReadLine();
            Console.Write("Adja meg a vásárolt darabszámot! ");
            int darabszam = int.Parse(Console.ReadLine());
            Console.WriteLine("5. feladat");
            Console.WriteLine($"Az első vásárlás sorszáma: {lista.IndexOf(lista.First(a => a.Contains(arunev))) + 1}");
            Console.WriteLine($"Az utolsó vásárlás sorszáma: {lista.IndexOf(lista.Last(a => a.Contains(arunev))) + 1}");
            Console.WriteLine($"{lista.Count(a => a.Contains(arunev))} vásárlás során vettek belőle.");
            Console.WriteLine();
            Console.WriteLine("6. feladat");            
            Console.WriteLine($"{darabszam} darab vételekor fizetendő: {arfuggveny(darabszam)}");
            Console.WriteLine();
            Console.WriteLine("7. feladat");
            List<string> kosar = new List<string>();
            for (int i = 0; i < lista[sorszam].Count(); i++)
            {
                if (!kosar.Contains(lista[sorszam][i]))
                {
                    Console.WriteLine($"{lista[sorszam].Count(x => x == lista[sorszam][i])} {lista[sorszam][i]}");
                    kosar.Add(lista[sorszam][i]);
                }                
            }

            System.IO.StreamWriter f = new StreamWriter("osszeg.txt");
            for (int j = 0; j < lista.Count(); j++)
            {
                kosar = new List<string>();
                int ar = 0;
                for (int i = 0; i < lista[j].Count(); i++)
                {
                    if (!kosar.Contains(lista[j][i]))
                    {
                        ar += arfuggveny(lista[j].Count(x => x == lista[j][i]));
                        kosar.Add(lista[j][i]);
                    }
                }
                f.WriteLine($"{j + 1}: {ar}");
            }
            f.Close();
        }
    }
}
