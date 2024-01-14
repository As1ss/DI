using System.Globalization;

//Práctica 1 en consola. Aplicación de obtención de dni y fecha realizada por Alexis López Briongos Dam2t.

namespace Practica1_Alexis_Lopez_Briongos
{
    internal class Program
    {
        //Variables globales de la clase
        private static int opcion;
        private static Boolean exit;
        private static String input;
        private static String name;
        static void Main(string[] args)
        {
            //Inicializamos en false el atributo exit para poder cambiarlo despues y finalizar el switch
            exit = false;
            //Métodos en los que saludaremos al usuario y le mostraremos el menú principal para operar entre las dos opciones.
            saluteUser();
            mainMenu();
        }

        //Método de saludo al usuario
        private static void saluteUser()
        {
            Console.WriteLine("Introduce tu nombre.");
            name = Console.ReadLine();
            Console.WriteLine($"Saludos, {name}");
        }

        //Método del menú principal
        private static void mainMenu()
        {
           //Bucle do while en el que comprobaremos la variable exit cada vez que se itere.
            do
            {
                Console.WriteLine("\nIntroduce la opción deseada:" +
                    "\n1.- Obtener la letra del dni" +
                    "\n2.- Obtener el día de la semana " +
                    "\n3.- Salir.");

                //Guardado del valor introducido por el usuario y conversión de tipo String a tipo Int  para poder operar en el switch con él.
                input = Console.ReadLine();
                int.TryParse(input, out opcion);

                //Switch con diferentes opciones para operar.
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
                        //Mensaje de error si el usuario no introduce una opción de las señaladas anteriormente.
                        Console.WriteLine("Por favor, escoge una opción válida.");
                        break;
                }
            } while (exit == false);
            //Despedida del usuario al finalizar el programa.
            Console.WriteLine($"Gracias por su visita {name}");
        }
        //Método de obtención de la letra del dni mediante el valor introducido del usuario.
        private static void getDateOption()
        {
            //Limpiamos la consola antes de operar.
            Console.Clear();

            //Mostramos un encabezado para saber en que opción nos encontramos.
            Console.WriteLine("Obtener fecha del día actual.");
            DateTime date = DateTime.Now;
            CultureInfo spanishCulture = new CultureInfo("es-ES");
            Console.WriteLine($"\nHoy es {date.ToString("dddd", spanishCulture)}");

        }

        private static void getDniLetterOption()
        {
            //Limpiamos la consola antes de operar.
            Console.Clear();

            //Mostramos un encabezado para saber en que opción nos encontramos.
            Console.WriteLine("Obtener letra del dni.");

            //Obtenemos dni y lo convertimos a Int para poder pasarselo como argumento al método obtainDNI(int dniNum);
            Console.WriteLine("\nIntroduce el número de tu dni");
            string inputNum = Console.ReadLine();
            int dniNum;
            int.TryParse(inputNum, out dniNum);
            obtainDNI(dniNum);
        }
        //Método para obtener el dni completo junto a la letra.
        private static void obtainDNI(int dni)
        {
            //Array de caracteres ordenado como la tabla oficial para que los valores correspondan al índice fruto de la operación de dni%23. 
            char[] dniLettersValue = { 'T', 'R', 'W', 'A', 'G', 'M', 'Y', 'F', 'P', 'D', 'X', 'B', 'N', 'J', 'Z', 'S', 'Q', 'V', 'H', 'L', 'C', 'K', 'E' };
            
            //Variable en la que almacenaremos la operación entre el dni pasado como argumento mod 23.
            int resto = dni % 23;

            //Comprobación de si el dni es correcto o no mediante el método checkDNI(int dni)
            if (checkDNI(dni))
            {
                //Si el dni es válido mostraremos el dni completo mostrando el valor del array con el valor de la operación resto como índice.
                Console.WriteLine($"Tu dni es {dni}-{dniLettersValue[resto]}");
            }
            else
            {
                //Mensaje de error si no es válido
                Console.WriteLine("El dni introducido no es válido");
            }

        }

        //Método de comprobacíón del dni
        private static bool checkDNI(int dni)
        {
            //Creamos una variable de tipo String y le añadimos el valor de tipo int convertido en String para poder conocer la longitud de caracteres del dni.
            String dniAux = dni.ToString();

            //Almacenamos en una variable la longitud de caracteres del dni de tipo String
            int dniLength = dniAux.Length;


            //Comprobamos si la longitud del dni es de 8 caracteres y si es diferente a 0 (que es valor que se le añade al dni si el usuario no introduce ningún valor)
            if (dniLength.Equals(8) && dni != 0)
            {
                //Si se cumple, el dni es válido
                return true;
            }
            else
            {
                //Si se cumple, el dni es inválido
                return false;

            }
        }
    }
}