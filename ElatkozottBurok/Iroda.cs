using System;
using System.Collections.Generic;
using System.Linq;

namespace ElatkozottBurok
{
    public class Iroda
    {
        List<Fejleszto> fejlesztok;
        Automata automataGep;

        public Iroda(List<Fejleszto> fejlesztok, Automata automataGep)
        {
            this.fejlesztok = fejlesztok;
            this.automataGep = automataGep;
        }

        public List<Fejleszto> Fejlesztok { get => fejlesztok; set => fejlesztok = value; }
        public Automata AutomataGep { get => automataGep; set => automataGep = value; }

        public void MunkanapSzimulacio(int orakSzama)
        {
            for (int i = 0; i < orakSzama; i++)
            {
                foreach (Fejleszto fejleszto in Fejlesztok)
                {
                    fejleszto.Dolgozik();
                    if (fejleszto.KoffeinSzint < 20 || fejleszto.StresszSzint < 70)
                    {
                        Nassolnivalo vasarolt = AutomataGep.Vasarlas(fejleszto.KedvencSnack, fejleszto);
                        if (vasarolt != null)
                        {
                            fejleszto.Fogyaszt(vasarolt);
                        }
                        if (AutomataGep.Elakadva)
                        {
                            AutomataGep.JavitasRugassal();
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"Név: {fejleszto.Nev} Koffeinszint: {fejleszto.KoffeinSzint} Stresszszint: {fejleszto.StresszSzint}");
                }
            }
        }
        public void NapiJelentes()
        {
            List<Fejleszto> stresszesFejlesztok = Fejlesztok.OrderByDescending(f => f.StresszSzint).ToList();
            Console.WriteLine("Legfeszültebb fejlesztők");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Név: {stresszesFejlesztok[i].Nev} Stresszszint: {stresszesFejlesztok[i].StresszSzint}");
            }
            int count = 0;
            foreach (Fejleszto fejleszto in stresszesFejlesztok)
            {
                if (fejleszto.Kiegve == true)
                {
                    count++;
                }
            }
            Console.WriteLine(count + " fejlesztő égett ki");
            Console.WriteLine($"Az automata bevétele: {AutomataGep.KeszpenzKassza} Ft, a maradék készlet száma: {AutomataGep.Keszlet.Count}");
        }
    }
}