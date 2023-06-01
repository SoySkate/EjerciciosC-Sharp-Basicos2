using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosEnric.Models
{
    public class Provincia
    {
        public int Codi { get; set; }
        public string Nom { get; set; }
        public int Poblacio { get; set; }
        public Provincia(int c, string n, int p)
        {
            Codi = c;
            Nom = n;
            Poblacio = p;
        }
        public void escribirData()
        {
            Console.WriteLine("Estos son los datos; " + Codi + " provincia: " + Nom + " N.Habitantes: " + Poblacio);
        }
    }
}
