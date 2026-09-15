using System;
using System.Collections.Generic;
using System.Linq;

namespace ElatkozottBurok
{
    public class Automata
    {
        int keszpenzKassza;
        List<Nassolnivalo> keszlet;
        bool elakadva;

        public Automata(int keszpenzKassza, List<Nassolnivalo> keszlet, bool elakadva)
        {
            this.keszpenzKassza = keszpenzKassza;
            this.keszlet = keszlet;
            this.elakadva = elakadva;
        }

        public int KeszpenzKassza { get => keszpenzKassza; set => keszpenzKassza = value; }
        public List<Nassolnivalo> Keszlet { get => keszlet; set => keszlet = value; }
        public bool Elakadva { get => elakadva; set => elakadva = value; }

        public void Feltolt(List<Nassolnivalo> ujElemek)
        {
            if (ujElemek != null || ujElemek.Count > 0)
            {
                Keszlet.AddRange(ujElemek);
            }          
        }
        public Nassolnivalo Vasarlas(string termekNev, Fejleszto vasarlo)
        {
            if (Elakadva)
            {
                vasarlo.StresszSzint += 15;
                return null;
            }
            else
            {
                bool van = false;
                Nassolnivalo kivalasztott = Keszlet[0];
                foreach (Nassolnivalo item in Keszlet)
                {
                    if (item.Nev == termekNev) 
                    {
                        van = true;
                        kivalasztott = item;
                    }
                }
                if (!van)
                {
                    Console.WriteLine("A termék elfogyott");
                    return null;
                }
                else
                {
                    if (vasarlo.Penz < kivalasztott.Ar)
                    {
                        Console.WriteLine("A vásárlónak nincs elég pénze a termékhez");
                        return null;
                    }
                    else
                    {
                        Random rand = new Random();
                        int szam = rand.Next(1, 101);
                        if (szam < 15)
                        {
                            Elakadva = true;
                            vasarlo.Penz -= kivalasztott.Ar;
                            vasarlo.StresszSzint += 30;
                            Console.WriteLine("A termék elakadt");
                            return null;
                        }
                        else
                        {
                            vasarlo.Penz -= kivalasztott.Ar;
                            KeszpenzKassza += kivalasztott.Ar;
                            Keszlet.Remove(kivalasztott);
                            return kivalasztott;
                        }
                    }
                }
            }
        }
        public void JavitasRugassal()
        {
            Random rand = new Random();
            int szam = rand.Next(1, 101);
            if (Elakadva)
            {
                if (szam < 51)
                {
                    Elakadva = false;
                }
                else
                {
                    Console.WriteLine("A riasztó megszólalt");
                }
            }
        }
    }
}