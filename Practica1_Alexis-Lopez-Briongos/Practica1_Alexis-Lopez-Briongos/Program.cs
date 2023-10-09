namespace Practica1_Alexis_Lopez_Briongos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hola buenas, introduce tu nombre.");
            var name = Console.ReadLine();

            menuPrincipal();
        }

        private static void menuPrincipal()
        {

            Console.WriteLine("Introduce la opción deseada:" +
                "\n1.- Obtener la letra del dni" +
                "\n2.- Obtener el día de la semana " +
                "\n3.- Salir.");
            try
            {
                
                switch (opcion)
                {
                    case 1:

                        break;
                }
            }
            catch
            {

            }
           
        }
    }
}