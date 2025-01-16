using _2._2.dars.Api.Services;

namespace _2._2.dars.Api;

internal class Program
{
    static void Main(string[] args)
    {

    }

    public static void StartFrontEnd()
    {
        Console.Clear();
        while (true)
        {
            Console.WriteLine("1. stop");
            Console.WriteLine("2. Login");
            Console.Write("Choose option : ");
            var option = Console.ReadLine();

            if (option == "1")
            {
                Console.WriteLine("Thanks");
                return;
            }
            else if (option == "2")
            {
                LoginPage();
            }
            else
            {
                Console.WriteLine("you must enter 1 or 2");
                return;
            }

        }
    }

}
