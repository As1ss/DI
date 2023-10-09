namespace ConsoleApp1
{
    internal class Program
    {
       

        static void Main(string[] args)
        {
            Console.WriteLine("¿Cómo te llamas?");
            var name = Console.ReadLine();
            var currentDate = DateTime.Now;


            //Comentario de una línea
       
            Console.WriteLine($"\nHola {name} son las {currentDate:t} del día {currentDate:d}");
            /*
             * Comentario de vairas líneas
             *
             */


        }
    }
}