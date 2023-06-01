using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using EjerciciosEnric.Models;
using System.Text.RegularExpressions;

namespace EjerciciosEnric
{
    class Program
    {
        static void comptador()
        {
            //Console.WriteLine("____________AA__(bucle for)_________________");
            for (int aa = 0; aa<= 5; aa++)
            {

                int bb = 0;
                do
                {
                    Console.WriteLine("Comptador:\n");
                    Console.WriteLine(aa +":"+ (bb++));
                    System.Threading.Thread.Sleep(100);
                    Console.Clear();

                } while (bb <= 59);
            }
            //Console.WriteLine("______________BB___(bucle do while)_______________");

            
        }
        static void petit_Gran(string nums)
        {

            char[] strnumero = nums.ToArray();
            int maxnum = 0;
            int minnum = strnumero[0];
            for (int i = 0; i < strnumero.Length; i++)
            {
                int numero = int.Parse(strnumero[i].ToString());
                if (numero >= maxnum)
                {
                    maxnum = numero;
                }
                if (numero <= minnum)
                {
                    minnum = numero;
                }    
            }

            Console.WriteLine("Este es un num mas grande: " + maxnum);
            Console.WriteLine("Este es un num mas pequeño: " + minnum);
        }
        static void desglosamentMonedes(double num)
        {
            Console.WriteLine("El numero que has introducido es: ");
            Console.WriteLine(num = Math.Round(num, 2, MidpointRounding.ToEven));
           
           //EL PROBLEMA ES QUE LE HACÍA LLEGAR UN NUMERO STRING QUE LO PARSEABA A FLOAT Y LUEGO ESTE
           //DENTRO DE LA FUNCION LO CONVERTIA EN DOUBLE XDDD VAYA QUE NO ME COGÍA EL NUM EXACTO...

            double[] monedas = new double[] { 2, 1, 0.50, 0.20, 0.10, 0.05, 0.02, 0.01};
            if (num <= 9.99f && num >= 0.01)
            { 
                double newnum = num;
                for (int i=0; i< monedas.Length; i++)
                {
                        double division = newnum / monedas[i];
                        double resto = newnum % monedas[i];
                        if (resto >= 0) 
                        {                        
                            if(Math.Truncate(division) != 0) { 
                                Console.WriteLine("Tienes " + Math.Truncate(division) + " monedas de " + monedas[i]);
                            }

                            newnum -= Math.Truncate(division) * monedas[i];
                        }
                }
                Console.WriteLine("Bucle cerrado");
            }
            else
                Console.WriteLine("\nDebe introducir un num decimal del 0,01 al 9,99.");

   }
        static void esbrinarNum()
        {
            int num;
            

            Random aleatorio = new Random();
            int count = 0;
            int generatednum;
            generatednum = aleatorio.Next(1, 100) + 1;
            for (int i = 1; i<=100; i++)
            {
                Console.WriteLine("\nIntroduce el número que crees que es:");
                try { num = int.Parse(Console.ReadLine()); } catch { Console.WriteLine("Debe escribir un numero!\n"); num = int.Parse(Console.ReadLine()); }
                
                if (num> generatednum)
                {
                    count++;
                    Console.WriteLine("El número que buscas es más pequeño.");
                }else if (num < generatednum)
                {
                    count++;
                    Console.WriteLine("El número que buscas es más grande.");
                }
                if (generatednum == num)
                {
                    count++;
                    Console.WriteLine("Lo has adivinado!");
                    break;
                }
                
            }
            Console.WriteLine("Se han realizado " + count + " intentos");
        }
     
        static void readfile(StreamReader ruta)
        {
            string line;
            int poblacio = 0;
            string[] splitLine;
            List<string> newlines = new List<string>();
            try { 
            line = ruta.ReadLine();
                while(line != null)
                {
                    splitLine = line.Split('|');
                    poblacio += int.Parse(splitLine[2]);
                    newlines.Add(splitLine[1]);
                    //Solo he sabido ordenar los nombres no el conjunto ....
                    Console.WriteLine(line);
                    newlines.Sort();
                    line = ruta.ReadLine();
                }

  Console.WriteLine("\nLa suma de todas las poblaciones es: " + poblacio);

                //for (int i = 0; i < newlines.Count; i++)
                //{
                //    Console.WriteLine(newlines[i]);
                //}

              
                Console.WriteLine("Archivo creado en la ubicacion: C:/DATOS/ANDREU\"");
                System.IO.File.WriteAllLines(@"C:\DATOS\ANDREU\provincias-alfa.txt", newlines);
                ruta.Close();
                Console.ReadLine();

            }
            catch(Exception e) { Console.WriteLine("Exception: " + e.Message); }
        }

        static void bidimensional()
        {
          //Crec que no he entes el proposit dauqest exercici
            int[,] bidim = new int[12,30];

            int[][] jaggedArray = new int[12][];
            for (int i=0; i< 12; i++)
            {
                if(i ==1)
                {
                    jaggedArray[i] = new int[29];

                }else if( i ==3 ||i==5 || i == 8|| i == 10)
                {
                    jaggedArray[i] = new int[30];
                }
                else{
                    jaggedArray[i] = new int[31];
                }

            }
                
        }
     
       public static void sentenciaLinq(StreamReader ruta)
        {
            
            string line;
            int codigo;
            int poblacio;
            string nombre;

            string[] splitLine;

            List<Provincia> provincias = new List<Provincia>();
                line = ruta.ReadLine();
            while (line != null)
            {
                splitLine = line.Split('|');
                codigo = int.Parse(splitLine[0]);
                nombre = splitLine[1];
                poblacio = int.Parse(splitLine[2]);

                provincias.Add(new Provincia(codigo, nombre, poblacio));

                line = ruta.ReadLine();
                //provincias.escribirData();
                   
            }
            var querymilion = from prov in provincias
                              where  prov.Poblacio > 1000000
                              orderby prov.Poblacio
                              select prov;


            var listquery = querymilion.Reverse().ToList();
            
            for(int i=0; i<listquery.Count; i++)
            {
                int p = listquery[i].Poblacio;
                Console.WriteLine(listquery[i].Nom +" : "+ p);
                
            } 
        }
        static void readtextfile(StreamReader textfileruta)
        {
            string text;
            try
            {
                text = textfileruta.ReadLine();
                string withoutsigns;
                string lowercase;
                string sintilde;
                string novocales;



                withoutsigns = text.Replace('.', ' ').Replace(',', ' ').Replace(';', ' ').Replace('¿', ' ').Replace('¡', ' ');
                lowercase = withoutsigns.ToLower();
                sintilde = Regex.Replace(lowercase.Normalize(NormalizationForm.FormD), "[^a-zA-Z0-9 ]", "");
                novocales = sintilde.Replace('a', '*').Replace('e', '*').Replace('i', '*').Replace('o', '*').Replace('u', '*');
                Console.WriteLine(novocales);

                System.IO.File.WriteAllText(@"C:\DATOS\ANDREU\text2.txt", novocales);
            }
            catch (Exception e) { Console.WriteLine("Exception: " + e.Message); }
        }

        static void Main(string[] args)
        {
            StreamReader ruta = new StreamReader("C:\\DATOS\\ANDREU\\PROVINCIAS-2023.txt");
            StreamReader textfileruta = new StreamReader("C:\\DATOS\\ANDREU\\text.txt");
            Boolean menu = true;
            
            do
            {
                Console.WriteLine("\n\n_____________________________");
                Console.WriteLine("Menu:");
                Console.WriteLine("1.Comptador:");
                Console.WriteLine("2.Buscador de nums grande y pequeño:");
                Console.WriteLine("3.Desglosament de monedes del numero(((NO HECHO))):");
                Console.WriteLine("4.Encontrar el numero random:");
                Console.WriteLine("5.Leer fichero provincias-23 txt:");
                Console.WriteLine("6.ARRAY bidimensional(((NO HECHO))):");
                Console.WriteLine("7.LINQ provincias-23 txt:");
                Console.WriteLine("8.Operacions a un archiu txt:");
                int opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Imprimiendo del 0 al 5 y del 1 al 59:\n");
                        comptador();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        Console.WriteLine("Introduce 5 numeros enteros seguidos:\n");
                        string nums;
                        nums = Console.ReadLine();
                        petit_Gran(nums);
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.WriteLine("Introduce un numero en euros con dos deciamles:\n");
                        double euros;
                        euros = double.Parse(Console.ReadLine());
                        //NIDEA ENRIC COM ES LI HE DONAT BASTANTES VOLTES Y NO TROBO RES AMB SENTIT 
                        desglosamentMonedes(euros);
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.WriteLine("Adivina el numero entre 1 y el 100:\n");
                        esbrinarNum();
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.WriteLine("Lectura del fichero provincias-23:\n");
                        readfile(ruta);
                        Console.ReadKey();
                        break;
                    case 6:
                        Console.WriteLine("ARRAY bidimensional fechas:\n");
                        //NIDEA NO LO ENTIENDO ESTO XD
                        bidimensional();
                        Console.ReadKey();
                        break;
                    case 7:
                        Console.WriteLine("LINQ de la clase del archivo provincias:\n");
                        sentenciaLinq(ruta);
                        Console.ReadKey();
                        break;
                    case 8:
                        Console.WriteLine("Archivo text.txt operaciones:\n");
                        readtextfile(textfileruta);
                        Console.ReadKey();
                        break;



                    default:
                        Console.WriteLine("No has introducido ninguna opcion valida\n");
                        break;

                }
            } while (menu == true);
        }
    }
}
