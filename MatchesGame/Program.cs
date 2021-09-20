using MatchesGame.FunctionalClasses;
using System;
using System.IO;

namespace MatchesGame
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(Directory.GetCurrentDirectory());

            int a = -1;
            while(a==-1)
            {
                Console.WriteLine("\n Please select input method. \n 1. Read from file \n 2. Enter Manual Data. \n\n Input 0 to exit.");
                string b = Console.ReadLine();

                switch(b)
                {
                    case "1":
                        Console.WriteLine("Please enter a file path. Press enter to use default file");
                        FileHandler.ReadFile(Console.ReadLine());
                        break;

                    case "2":
                        Console.WriteLine("Please enter the first name");
                        var nameOne = Console.ReadLine();

                        Console.WriteLine("Please enter the second name");
                        var nameTwo = Console.ReadLine();
                        Console.WriteLine(MatchGameUtility.MatchNames(nameOne, nameTwo));
                        break;

                    case "0":
                        a = 0;
                        break;

                    default:
                        Console.WriteLine("Incorrect Input. Try again");
                        break;
                }
                Console.WriteLine("Press any key to continue (repeat)");
            }
            

        }
    }
}
