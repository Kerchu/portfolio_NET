using System;
class Program
{
    static void Main()
    {
        bool gamePlay = true;

        while (gamePlay)
        {
            Console.WriteLine("Math Enigma");
            Console.WriteLine("-------------------");
            Console.WriteLine("1 - Start Game");
            Console.WriteLine("2 - Exit");
            Console.WriteLine("-------------------");
            try
            {
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.Clear();
                        Play();
                        break;
                    case 2:
                        gamePlay = false;
                        break;
                    default:
                        Console.WriteLine("Non-valid option. Try again");
                        break;
                }
            }
            catch(FormatException ex)
            {
                Console.WriteLine("Format Error: " + ex.Message);
                Console.ReadKey();
            }
            Console.Clear();
        }
    }

    static void Play()
    {
        Random rnd = new Random();
        int a = rnd.Next(20), b = rnd.Next(20), c = rnd.Next(20), i = 3;
        Console.WriteLine("Solve the next enigma (You have 3 chances):");
        Console.WriteLine("a + a + a = " + (a+a+a));
        Console.WriteLine("a + b + b = " + (a+b+b));
        Console.WriteLine("b - c = " + (b-c));
        Console.WriteLine("Calculate c + a - b: ");
        Console.WriteLine("-------------------");
        try
        {
            while (i != 0)
            {
                int userAnswer = int.Parse(Console.ReadLine()), result = c + a - b;

                if (userAnswer == result)
                {
                    Console.WriteLine("Correct! You win!!");
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong Answer. Try again.");
                    Console.WriteLine("-------------------");
                    i--;
                }
            }
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Format Error: " + ex.Message);
            Console.ReadKey();
            Console.Clear();
        }
        if (i == 0)
        {
            Console.Clear();
            Console.WriteLine("You lost all your chances! You Lose!");
        }
        Console.ReadKey();
        Console.Clear();
    }
}