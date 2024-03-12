using System;

namespace NumRandGen
{
    public class MyPerExcept : Exception
    {
        public MyPerExcept(string mensaje) : base(mensaje) { }
    }
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to 'Guess the number'!!");
            Console.WriteLine("");
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Select an option.");
                Console.WriteLine("-----------------------");
                Console.WriteLine("1. Start game         |");
                Console.WriteLine("2. Exit               |");
                Console.WriteLine("-----------------------");

                try
                {
                    int op = int.Parse(Console.ReadLine());
                    switch (op)
                    {
                        case 1:
                            Console.Clear();
                            Play();
                            break;
                        case 2:
                            Console.Clear();
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid option. Try again!!");
                            Console.ReadKey();
                            break;
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Format Error: " + ex.Message);
                    Console.ReadKey();
                }
                Console.Clear();
            }
            Console.WriteLine("-----------------------");
            Console.WriteLine("Program terminated    |");
            Console.WriteLine("-----------------------");
        }
        private static int DifficSelect()
        {
            Console.WriteLine("Select your difficulty!");
            Console.WriteLine("-----------------------");
            Console.WriteLine("1 - Noob (0-20)");
            Console.WriteLine("2 - Nerd (0-50)");
            Console.WriteLine("3 - Turing's pupil (0-100)");
            Console.WriteLine("4 - BERSERKER!!! (0-500)");
            try
            {
                int op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        Console.Clear();
                        return 21;
                    case 2:
                        Console.Clear();
                        return 51;
                    case 3:
                        Console.Clear();
                        return 101;
                    case 4:
                        Console.Clear();
                        return 501;
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Format Error: " + ex.Message);
                Console.ReadKey();
                return 0;
            }
            return 0;
        }
        private static void Play()
        {
            Random rnd = new Random();
            int ranNum = rnd.Next(DifficSelect());
            Console.WriteLine("A new mysterious number has been generated! Which will it be?");
            Console.WriteLine("-------------------------------------------------------------");
            try
            {
                bool i = false;
                while (!i)
                {
                    int? num = int.Parse(Console.ReadLine());

                    if (num > ranNum)
                    {
                        Console.WriteLine("The mysterious number is LOWER!");
                        Console.WriteLine("-------------------------------");
                    }
                    if (num < ranNum)
                    {
                        Console.WriteLine("The mysterious number is HIGHER!");
                        Console.WriteLine("--------------------------------");
                    }
                    if (num == ranNum)
                    {
                        Console.Clear();
                        Console.WriteLine("--------------------------------------------");
                        Console.WriteLine("YOU GUESSED THE CORRECT NUMBER! It's: " + num);
                        Console.WriteLine("--------------------------------------------");
                        Console.ReadKey();
                        i = true;
                    }
                    int p = 0; p++;
                    if (p == 7)
                    {
                        Console.Clear();
                    }
                }
            }
            catch (MyPerExcept ex)
            {
                Console.WriteLine($"A personalized exception has been found: {ex.Message}");
                rnd = null;
                Console.ReadKey();
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"An exception has been found: {ex.Message}");
                rnd = null;
                Console.ReadKey();
            }
            Console.Clear();
        }
    }
}