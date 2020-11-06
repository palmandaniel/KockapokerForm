using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KockapokerForm
{
    class Dobas
    {
        static List<int> dobasok = new List<int>();

        private string eredmeny;
        public string Eredmeny { get { return eredmeny; } }

        private int pont;
        public int Pont { get { return pont; } }

        int[] kockak = new int[5];

        public int[] Kockak { get { return kockak; } }


        //public Dobas(int k1, int k2, int k3, int k4, int k5)
        //{
        //    kockak[0] = k1;
        //    kockak[1] = k2;
        //    kockak[2] = k3;
        //    kockak[3] = k4;
        //    kockak[4] = k5;

        //    eredmeny = Erteke();
        //}

        public void EgyDobas()
        {
            Random vel = new Random();

            for (int i = 0; i < kockak.Length; i++)
            {
                kockak[i] = vel.Next(1, 7);
            }

            eredmeny = Erteke();
        }

        public void Kiiras()
        {
            foreach (var k in kockak)
            {
                Console.Write($"{k}, ");
            }
            Console.WriteLine($" -> *{eredmeny} -> {Pont}*");
            Console.WriteLine("-------------------");
        }

        private string Erteke()
        {
            Dictionary<int, int> eredmeny = new Dictionary<int, int>();

            for (int i = 1; i < 7; i++)
            {
                eredmeny.Add(i, 0);
            }

            foreach (var k in kockak)
            {
                eredmeny[k]++;
                //vegigmegy, majd az adott kulcsnal
                //noveli az erteket
            }
            /*
            Dicbol lekerdezzuk az 1-nel nagyobb value-ket

            elso eset ha egy elem marad (value ertekeket nezzuk)

            -5 -> nagypoker
            -4 -> poker
            -3 -> drill
            -2 -> pár

            key megmondja hanyas - 4 póker

            masodik eset ha ket elem marad

            -value 3 és 2 -> Full
            -value 2 és 2 -> 2 pár

            harmadik eset, nem marad egy sem 

            ha key:6 == 0 -> kissor
            ha key:1 == 0 -> nagysor

            minden mas esetben szemet(moslek)

            */

            var result = (from e in eredmeny
                          orderby e.Value descending
                          where e.Value > 1
                          select new { Szam = e.Key, Db = e.Value }).ToList();

            int db = result.Count();

            if (db == 1)
            {
                string[] egyes = new string[] { "", "", "Pár", "Drill", "Póker", "Nagypóker" };
                int[] pontok = new int[] { 0, 0, 10, 300, 600, 900 };
                pont = pontok[result[0].Db] + result[0].Szam;
                return $"{result[0].Szam} {egyes[result[0].Db]}";
            }

            else if (db == 2)
            {
                if (result[0].Db == 3 && result[1].Db == 2)
                {
                    pont = 500 + result[0].Szam * 10 + result[1].Szam * 1;
                    return $"{result[0].Szam} Drill - {result[1].Szam} Pár - Full";
                }
                else
                {
                    if (result[0].Szam > result[1].Szam)
                    {
                        pont = 100 + result[0].Szam * 10 + result[1].Szam * 1;
                        return $"{result[0].Szam} - {result[1].Szam} Dupla Pár";
                    }
                    else
                    {
                        pont = 100 + result[1].Szam * 10 + result[0].Szam * 1;
                        return $"{result[1].Szam} - {result[0].Szam} Dupla Pár";
                    }
                }
            }
            else
            {
                if (eredmeny[6] == 0)
                {
                    pont = 700;
                    return "Kissor";
                }
                else if (eredmeny[1] == 0)
                {
                    pont = 800;
                    return "Nagysor";
                }

            }
            pont = 1;
            return "Moslék";
        }

    }
}
