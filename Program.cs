using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2Prueba
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Belini Augusto
             * Acosta Nicolas
             * Millen Julian
             */
            int costoIndividual, edadP, totalEdades, cantPersonas, acumPas, individual, opcion;
            int contAdultos = 0, contMenores = 0, sumaEdades, totalPersonas, contRangoEdad = 0, promEdad = 0;
            double descPasaporte, recTotal, recTotalPas, recTotalInd;
            double costoTotalPas, costoTotalInd;
            bool salir = false;
            char paga;
            totalEdades = 0;
            individual = 0;
            recTotalPas = 0;
            recTotalInd = 0;
            sumaEdades = 0;
            acumPas = 0;

            Console.Title = "Parque 1.0";
            PantallaPrincipal("¡BIENVENIDOS AL PARQUE!\n\t  Disfrute su estadia");
            Console.Beep(100, 2000);
            do
            {
                Console.Clear();
                costoIndividual = 1500;

                PantallaPrincipal("seleccione una opcion: \n1-Pasaporte \n2-Individual \n3-Salir");
                opcion = Convert.ToInt32(Console.ReadLine());

                Console.Clear();
                Console.WindowHeight = 20;
                Console.WindowWidth = 40;
                sumaEdades = 0;
                switch (opcion)
                {
                    case 1:

                        int mayor21 = 0, menor4 = 0, menor11 = 0, menor16 = 0;
                        bool validado = true;
                        bool ingresarMayor = false;
                        Console.WindowHeight = 20;
                        Console.WindowWidth = 50;
                        Console.Clear();
                        Console.WriteLine("cantidad de personas: ");
                        cantPersonas = Convert.ToInt32(Console.ReadLine());
                        while (!(cantPersonas >= 4 && cantPersonas <= 10))
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Clear();
                            Console.WriteLine("Error: Solo se admiten entre 4 a 10 personas");
                            Console.WriteLine("cantidad de personas: ");
                            cantPersonas = Convert.ToInt32(Console.ReadLine());
                        }
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Clear();

                        contMenores = 0;
                        contAdultos = 0;
                        Console.WriteLine("Hay menores de 16 años? S/N");
                        char hayMenores = Console.ReadLine()[0];
                        if (char.ToUpper(hayMenores) == 'S')
                        {
                            Console.WriteLine("Hay un mayor de 21 años con ustds? S/N");
                            if (char.ToUpper(Console.ReadLine()[0]) == 'S')
                            {
                                for (int i = 0; i < cantPersonas; i++)
                                {
                                    if (i == 0)
                                    {
                                        do
                                        {
                                            Console.WriteLine("Ingrese la edad de la persona responsable: ");
                                            edadP = Convert.ToInt32(Console.ReadLine());
                                            if (edadP < 21)
                                            {
                                                Console.BackgroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Edad NO valida");
                                            }
                                            Console.BackgroundColor = ConsoleColor.Green;

                                        } while (edadP < 21);
                                        sumaEdades += edadP;
                                        mayor21++;
                                        contAdultos++;
                                    }
                                    else if (!ingresarMayor)
                                    {

                                        do
                                        {
                                            Console.WriteLine("Ingrese edad de la persona #{0}: ", i + 1);
                                            edadP = Convert.ToInt32(Console.ReadLine());
                                            if (edadP < 0)
                                            {
                                                Console.BackgroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Edad NO valida");
                                            }
                                            Console.BackgroundColor = ConsoleColor.Green;
                                        } while (edadP < 0);

                                        if (edadP >= 16)
                                        {
                                            contAdultos++;
                                            if (edadP >= 21)
                                            {
                                                mayor21++;
                                            }

                                        }
                                        else
                                        {
                                            contMenores++;
                                            if (contMenores > 5 && mayor21 == 1)
                                            {
                                                if (i == cantPersonas - 1)
                                                {
                                                    Console.BackgroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("Se necesitan por lo menos 2 mayores de 21 años" +
                                                        " para ingresar con mas de 5 menores");
                                                    validado = false;
                                                    Console.BackgroundColor = ConsoleColor.Green;
                                                }
                                                else
                                                {
                                                    ingresarMayor = true;
                                                }
                                            }
                                            else
                                            {
                                                if (edadP >= 0 && edadP <= 3)
                                                {
                                                    menor4++;
                                                }
                                                else if (edadP > 3 && edadP <= 10)
                                                {
                                                    menor11++;
                                                }
                                                else
                                                {
                                                    menor16++;
                                                }
                                            }
                                        }
                                        sumaEdades += edadP;
                                        if (edadP >= 10 && edadP <= 15)
                                        {
                                            contRangoEdad++;
                                        }
                                    }
                                    else
                                    {
                                        do
                                        {
                                            Console.WriteLine("Ingrese la edad de la 2da persona responsable o -1 para salir: ");
                                            edadP = Convert.ToInt32(Console.ReadLine());
                                            if (edadP < 21 && edadP > 0)
                                            {
                                                Console.BackgroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Edad NO valida");
                                            }
                                            Console.BackgroundColor = ConsoleColor.Green;
                                            if (edadP == -1)
                                            {
                                                validado = false;
                                            }
                                        } while (edadP < 21 && validado);
                                        if (edadP >= 21)
                                        {
                                            sumaEdades += edadP;
                                            mayor21++;
                                            contAdultos++;
                                        }
                                        ingresarMayor = false;
                                    }
                                }

                            }
                            else
                            {
                                validado = false;
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.WriteLine("No se permite el ingreso de menores\nsin un responsable mayor de 21 años");
                                Console.ReadLine();
                            }


                        }
                        else
                        {
                            for (int i = 0; i < cantPersonas; i++)
                            {
                                do
                                {
                                    Console.WriteLine("Ingrese edad de la persona #{0}: ", i + 1);
                                    edadP = Convert.ToInt32(Console.ReadLine());
                                    if (edadP < 16)
                                    {
                                        Console.BackgroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Edad NO valida");
                                    }
                                    Console.BackgroundColor = ConsoleColor.Green;
                                } while (edadP < 16);
                                sumaEdades += edadP;
                                contAdultos++;
                            }
                        }
                        if (validado)
                        {
                            descPasaporte = 0.85;
                            costoTotalPas = (menor11 * 750 + menor16 * 1200 + contAdultos * costoIndividual) * descPasaporte + menor4 * (costoIndividual * .1);
                            Console.Clear();
                            Console.WriteLine("----------------------------------------");
                            Console.WriteLine("precio total: {0:f2}", costoTotalPas);
                            Console.WriteLine("----------------------------------------");

                            Console.WriteLine("si desea abonar presione 's' sino presione 'n': ");
                            paga = Console.ReadLine()[0];

                            if (char.ToLower(paga) == 's')
                            {
                                totalEdades += sumaEdades;
                                recTotalPas += costoTotalPas;
                                acumPas += cantPersonas;
                            }
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine("Pasaporte cancelado");
                            Console.ReadKey();
                        }
                        break;
                    case 2:

                        Console.WindowHeight = 20;
                        Console.WindowWidth = 50;
                        Console.Clear();
                        Console.WriteLine("cantidad de personas: ");
                        cantPersonas = Convert.ToInt32(Console.ReadLine());

                        while (!(cantPersonas > 0))
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Clear();
                            Console.WriteLine("Error: Cantidad incorrecta");
                            Console.WriteLine("cantidad de personas: ");
                            cantPersonas = Convert.ToInt32(Console.ReadLine());
                        }
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Clear();

                        individual += cantPersonas;

                        for (int i = 0; i < cantPersonas; i++)
                        {
                            Console.WriteLine("Ingrese edad de la persona: ");
                            edadP = Convert.ToInt32(Console.ReadLine());
                            while (!(edadP > 16))
                            {
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.WriteLine("ERROR: no puede ser menor de 17");
                                Console.WriteLine("Vuelva a ingresar edad de la persona: ");
                                Console.BackgroundColor = ConsoleColor.Green;
                                edadP = Convert.ToInt32(Console.ReadLine());
                            }
                            sumaEdades += edadP;
                        }
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Clear();
                        costoTotalInd = costoIndividual * cantPersonas;
                        Console.WriteLine("----------------------------------------");
                        Console.WriteLine("precio total: {0:F2}", costoTotalInd);
                        Console.WriteLine("----------------------------------------");
                        Console.ReadKey();
                        totalEdades += sumaEdades;
                        recTotalInd += costoTotalInd;
                        break;

                    case 3:
                        salir = true;
                        break;
                    default:
                        Console.WindowHeight = 10;
                        Console.WindowWidth = 40;
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Clear();
                        Console.WriteLine("\n\nOpcion Incorrecta!");
                        for(int i = 0;i < 5; i++)
                            Console.Beep(1000,200);
                        break;

                }
            } while (!salir);
            Colores();
            Console.Clear();


            totalPersonas = acumPas + individual;

            if (totalPersonas > 0)
            {
                promEdad = totalEdades / totalPersonas;
            }

            recTotal = recTotalPas + recTotalInd;

            ImprimirTextoEnmarcado($"Cantidad de personas con pasaporte: {acumPas}" +
                $"\nCantidad de personas entre 10 y 15 años: {contRangoEdad}" +
                $"\nPromedio de edades: {promEdad} años" +
                $"\nRecaudacion total de pasaportes: {recTotalPas:c2}" +
                $"\nRecaudacion total individuales: {recTotalInd:c2}" +
                $"\nRecaudacion total: {recTotal:c2}");
            Console.ReadKey();
        }

        public static void Colores()
        {
            Console.WindowHeight = 10;
            Console.WindowWidth = 50;
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
        }

        public static void PantallaPrincipal(string mensaje)
        {
            Console.WindowHeight = 10;
            Console.WindowWidth = 40;
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.Clear();

            int width = Console.WindowWidth;
            int height = Console.WindowHeight;

            int left = (width - mensaje.IndexOf("\n")) / 2;
            int top = (height - 2) / 2;

            Console.SetCursorPosition(left, top);
            Console.WriteLine(mensaje);
        }





        static void ImprimirTextoEnmarcado(string texto)
        {
            string[] lineas = texto.Split('\n');

            int longitudLineaMasLarga = ObtenerLongitudLineaMasLarga(lineas);
            int anchoConsola = Math.Max(Console.WindowWidth, longitudLineaMasLarga + 4);
            Console.SetWindowSize(anchoConsola, Console.WindowHeight);

            ImprimirLineaSuperior(anchoConsola);

            foreach (string linea in lineas)
            {
                ImprimirLineaCentro(linea, anchoConsola);
            }

            ImprimirLineaInferior(anchoConsola);
        }

        static int ObtenerLongitudLineaMasLarga(string[] lineas)
        {
            int longitudMaxima = 0;

            foreach (string linea in lineas)
            {
                int longitudLinea = linea.Length;
                if (longitudLinea > longitudMaxima)
                {
                    longitudMaxima = longitudLinea;
                }
            }

            return longitudMaxima;
        }

        static void ImprimirLineaSuperior(int ancho)
        {
            Console.Write('╔');

            for (int i = 0; i < ancho - 2; i++)
            {
                Console.Write('═'); 
            }

            Console.WriteLine('╗');
        }

        static void ImprimirLineaCentro(string linea, int ancho)
        {
            Console.Write('║');
            Console.Write(' ');

            int espacios = ancho - linea.Length - 4;

            for (int i = 0; i < espacios / 2; i++)
            {
                Console.Write(' ');
            }

            Console.Write(linea);

            for (int i = 0; i < espacios - espacios / 2; i++)
            {
                Console.Write(' ');
            }

            Console.Write(' ');
            Console.WriteLine('║'); 
        }

        static void ImprimirLineaInferior(int ancho)
        {
            Console.Write('╚');

            for (int i = 0; i < ancho - 2; i++)
            {
                Console.Write('═');
            }

            Console.WriteLine('╝'); 
        }
    }
}


