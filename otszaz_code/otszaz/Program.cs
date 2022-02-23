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
            int sorszam = int.Parse(Console.ReadLine());
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

        }
    }
}
