using System.Globalization;

//Práctica 1 en consola. Aplicación de obtención de dni y fecha realizada por Alexis López Briongos Dam2t.

namespace Practica1_Alexis_Lopez_Briongos
{
    internal class Program
    {
        private static int opcion;
        private static Boolean exit;
        private static String input;
        private static String name;
        static void Main(string[] args)
        {
            exit = false;
            Console.WriteLine("Buenas tardes, introduce tu nombre.");
            name = Console.ReadLine();


            mainMenu();
        }

        private static void mainMenu()
        {

            do
            {


                Console.WriteLine("\nIntroduce la opción deseada:" +
                    "\n1.- Obtener la letra del dni" +
                    "\n2.- Obtener el día de la semana " +
                    "\n3.- Salir.");
                input = Console.ReadLine();


                if (int.TryParse(input, out opcion))
                {


                    switch (opcion)
                    {
                        case 1:
                            getDniLetterOption();
                            break;
                        case 2:
                            getDateOption();
                            break;
                        case 3:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Por favor, escoge una opción válida.");
                            break;
                    }

                }
                else
                {
                    Console.WriteLine("No has introducido un numero entero.");
                }



            } while (exit == false);

            Console.WriteLine($"Gracias por su visita {name}");

        }

        private static void getDateOption()
        {
            Console.Clear();
            DateTime date = DateTime.Now;
            CultureInfo spanishCulture = new CultureInfo("es-ES");
            Console.WriteLine($"Hoy es {date.ToString("dddd", spanishCulture)}");

        }

        private static void getDniLetterOption()
        {
            Console.Clear();
            Console.WriteLine("Obtener letra del dni.");
            Console.WriteLine("\nIntroduce el número de tu dni");
            string inputNum = Console.ReadLine();
            int dniNum;
            int.TryParse(inputNum, out dniNum);
            obtainDNI(dniNum);
        }

        private static void obtainDNI(int dni)
        {
            checkDNI(dni);
            char[] dniLettersValue = { 'T', 'R', 'W', 'A', 'G', 'M', 'Y', 'F', 'P', 'D', 'X', 'B', 'N', 'J', 'Z', 'S', 'Q', 'V', 'H', 'L', 'C', 'K', 'E' };

            int resto;

            resto = dni % 23;


            Console.WriteLine($"Tu dni es {dni}-{dniLettersValue[resto]}");



        }

        private static void checkDNI(int dni)
        {
            String dniAux= dni.ToString();
            int dniLength= dniAux.Length;

            if (dniLength.Equals(8) && dni!=0)
            {
                
            }
            else
            {
                Console.WriteLine("El dni tiene menos de 8 caracteres");
            }
        }
    }
}