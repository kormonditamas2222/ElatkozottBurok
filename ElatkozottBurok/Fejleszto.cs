using System;

namespace ElatkozottBurok
{
    public class Fejleszto
    {
        string nev;
        Munkakor munkakor;
        int penz;
        int koffeinSzint;
        int stresszSzint;
        bool kiegve;
        string kedvencSnack;

        public string Nev { get => nev; set => nev = value; }
        public Munkakor Munkakor { get => munkakor; set => munkakor = value; }
        public int Penz { get => penz; 
        set
            {
                if (value < 0)
                {
                    penz = 0;
                }
                else
                {
                    penz = value;
                }
            }
        }
        public int KoffeinSzint
        {
            get => koffeinSzint;
            set
            {
                if (value < 0)
                {
                    koffeinSzint = 0;
                }
                else if (value >= 100)
                {
                    koffeinSzint = 100;
                    kiegve = true;
                }
                else
                {
                    koffeinSzint = value;
                }
            }
        }
        public int StresszSzint { get => stresszSzint; 
            set 
            { 
                if (value < 0)
                {
                    stresszSzint = 0;
                }
                else if (value >= 100)
                {
                    stresszSzint = 100;
                    kiegve = true;
                }
                else
                {
                    stresszSzint = value;
                }
            } 
        }
        public bool Kiegve { get => kiegve; }
        public string KedvencSnack { get => kedvencSnack; set => kedvencSnack = value; }
        public Fejleszto(string nev, Munkakor munkakor, int penz, int koffeinSzint, int stresszSzint, string kedvencSnack)
        {
            Nev = nev;
            Munkakor = munkakor;
            Penz = penz;
            KoffeinSzint = koffeinSzint;
            StresszSzint = stresszSzint;
            KedvencSnack = kedvencSnack;
        }

        public void Dolgozik()
        {
            if (Kiegve)
            {
                Console.WriteLine($"{Nev} kiégett");
            }
            else
            {
                switch (Munkakor)
                {
                    case Munkakor.Junior: KoffeinSzint -= 25; StresszSzint += 20; break;
                    case Munkakor.Senior: KoffeinSzint -= 15; StresszSzint += 10; break;
                    case Munkakor.DevOpsVarazslo: KoffeinSzint -= 10; StresszSzint += 25; break;
                    default: break;
                }
            }
            if (KoffeinSzint < 15)
            {
                Console.WriteLine($"{Nev} agya lefagyott, koffeinre van szüksége!");
            }
        }
        public void Fogyaszt(Nassolnivalo elem)
        {
            if (elem.Nev == KedvencSnack)
            {
                KoffeinSzint += elem.KoffeinLoket + 5;
                StresszSzint -= elem.StresszOldas * 2;
            }
            else
            {
                KoffeinSzint += elem.KoffeinLoket;
                StresszSzint -= elem.StresszOldas;
            }
        }
    }
}