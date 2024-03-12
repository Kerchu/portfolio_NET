using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to 'Guess the Word'!!");
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine("1- Play");
            Console.WriteLine("2- Exit");
            Console.WriteLine("-----------------------------");

            try {
                int op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        Console.Clear();
                        Play();
                        Console.Clear();
                        break;
                    case 2:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Wrong input, try again!");
                        break;
                }
            }
            catch (FormatException ex)
                {
                Console.WriteLine("Format Error: " + ex.Message);
                Console.ReadKey();
                Console.Clear();
            }

        }
        Console.Clear();
        Console.WriteLine("-----------------------------");
        Console.WriteLine("Program Finished!");
        Console.WriteLine("-----------------------------");
    }

    private static void Play()
    {
        List<string> word = new List<string> { "algorithm", "cryptography", "database", "injection", "debug" };
        Random random = new Random();
        string selectedWord = word[random.Next(word.Count)];
        int triesLeft = 6;
        List<char> discoveredLetters = new List<char>();


        Console.WriteLine("Guess the correct word!");
        Console.WriteLine("6 tries left!");
        Console.WriteLine("Hint: It's tech/programming related!");

        char[] guessedWord = new char[selectedWord.Length];
        for (int i = 0; i < selectedWord.Length; i++)
        {
            guessedWord[i] = '_';
        }
        try
        {
            while (triesLeft > 0)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Word to guess: " + new string(guessedWord));
                Console.WriteLine("Tries left: " + triesLeft);
                Console.WriteLine("Guessed letters: ");
                foreach (char letter in discoveredLetters)
                {
                    Console.Write(letter + " ");
                }
                Console.WriteLine();

                Console.WriteLine("Enter a letter: ");
                char inputLetter = Console.ReadKey().KeyChar;
                discoveredLetters.Add(inputLetter);

                if (selectedWord.Contains(inputLetter))
                {
                    for (int i = 0; i < selectedWord.Length; i++)
                    {
                        if (selectedWord[i] == inputLetter)
                        {
                            guessedWord[i] = inputLetter;
                        }
                    }

                    if (new string(guessedWord) == selectedWord)
                    {
                        Console.WriteLine();
                        Console.WriteLine("--------------------------------------");
                        Console.WriteLine("You've guessed the word! The word was: " + selectedWord);
                        Console.WriteLine("--------------------------------------");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Incorrect letter. Try again!");
                    triesLeft--;
                }

            }
        }
        catch (FormatException ex)
                {
            Console.WriteLine("Format Error: " + ex.Message);
            Console.ReadKey();
        }

        if (triesLeft == 0)
        {
            Console.WriteLine();
            Console.WriteLine("No tries left!! The word was: " + selectedWord);
        }
        Console.ReadKey();
    }
}