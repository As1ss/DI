namespace Practica1_Alexis_Lopez_Briongos
{
    internal class Program
    {
        private static int opcion;
        private static Boolean exit;
        static void Main(string[] args)
        {
            exit = false;
            Console.WriteLine("Hola buenas, introduce tu nombre.");
            var name = Console.ReadLine();

            menuPrincipal();
        }

        private static void menuPrincipal()
        {
            do
            {


                Console.WriteLine("Introduce la opción deseada:" +
                    "\n1.- Obtener la letra del dni" +
                    "\n2.- Obtener el día de la semana " +
                    "\n3.- Salir.");
                Console.WriteLine(opcion);

                if (int.TryParse(Console.ReadLine(),out opcion))
                {
                   
                    switch (opcion)
                    {
                        case 0:
                            Console.WriteLine("No has introducido ningún valor.");
                            break;
                        case 1:
                            Console.WriteLine("Has escogido la opcion 1.");
                            break;
                        case 2:
                            Console.WriteLine("Has escogido la opción 2.");
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
                    

              
            } while (exit==false);

           
        }
    }
}