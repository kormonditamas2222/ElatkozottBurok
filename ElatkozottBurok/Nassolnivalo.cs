using System;

namespace ElatkozottBurok
{
    public class Nassolnivalo
    {
        string nev;
        int koffeinLoket;
        int stresszOldas;
        int ar;

        public string Nev
        {
            get => nev;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    nev = "Ismeretlen nassolnivaló";
                }
                else
                {
                    nev = value;
                }
            }
        }
        public int KoffeinLoket { get => koffeinLoket; set => koffeinLoket = Math.Clamp(value, 0, 50); }
        public int StresszOldas { get => stresszOldas; set => stresszOldas = Math.Clamp(value, 0, 30); }
        public int Ar
        {
            get => ar;
            set
            {
                if (value < 100)
                {
                    ar = 100;
                }
                else
                {
                    ar = value;
                }
            }
        }

        public Nassolnivalo(string nev, int koffeinLoket, int stresszOldas, int ar)
        {
            Nev = nev;
            KoffeinLoket = koffeinLoket;
            StresszOldas = stresszOldas;
            Ar = ar;
        }
    }
}