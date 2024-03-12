class Program
{
    static void Main(string[] args)
    {
        try
        {
            List<string> character = new List<string>{
                "Albert Einstein",
                "Leonardo da Vinci",
                "Marie Curie",
                "William Shakespeare",
                "Nelson Mandela",
                "Oppenheimer",
                "Madonna",
                "Elvis Presley"
            };
            string[] genderChara = {
                "Male",
                "Male",
                "Female",
                "Male",
                "Male",
                "Male",
                "Female",
                "Male"
            };
            string[] profesionChara = {
                "Scientific",
                "Painter",
                "Scientific",
                "Writer",
                "Politician",
                "Engineer",
                "Singer",
                "Singer"
            };
            string[] famousForChara = {
                "Relativity Theory",
                "Mona Lisa",
                "Discovering of radioactive elements",
                "'Romeo and Juliet' Autor",
                "President",
                "Autor of the Atomic Bomb",
                "Hung Up Autor",
                "'Can't Help Falling in Love With You' Autor"
            };

            Random random = new Random();
            int indexChara = random.Next(character.Count);
            string famousChara = character[indexChara];
            string gender = genderChara[indexChara];
            string profesion = profesionChara[indexChara];
            string famousFor = famousForChara[indexChara];

            int tries = 0;

            Console.WriteLine("Welcome to the game where you'll guess famous characters!");
            Console.ReadKey();
            Console.Clear();

            while (true)
            {
                Console.WriteLine("Famous character lists:");
                foreach (var chara in character)
                {
                    Console.WriteLine("* " + chara);
                }

                Console.Write("\nUse a predeterminate question to guess the character I've chosen\n");
                Console.Write("-----------------------------------------------------------------------\n");
                Console.Write("0) Guess character\n");
                Console.Write("1) Is the character female?\n");
                Console.Write("2) Is She/He a scientific?\n");
                Console.Write("3) Is He/She a signer?\n");
                Console.Write("4) Is the character an engineer?\n");
                Console.Write("5) Is the character a politician?\n");
                Console.Write("6) Is the character a painter?\n");
                Console.Write("7) Is the character a writer?\n");
                Console.Write("8) Has the character developed the 'Relativity Theory'?\n");
                Console.Write("9) Has the character painted the 'Mona Lisa'?\n");
                Console.Write("10) Has the character discovered radioactive elements?\n");
                Console.Write("11) Has the character wrote 'Romeo and Juliet'?\n");
                Console.Write("12) Is the character a president?\n");
                Console.Write("13) Did the character made the Atomic Bomb?\n");
                Console.Write("14) Is the character autor of the song 'Hung Up'?\n");
                Console.Write("15) Is the character autor of the song 'Can´t Help Falling in Love'?\n");
                Console.Write("-----------------------------------------------------------------------\n");
                Console.Write("Input the number of the question you want to make: ");

                int option;
                if (!int.TryParse(Console.ReadLine(), out option))
                {
                    throw new FormatException("Non-valid option. Enter a valid input.");
                }

                if (option < 0 || option > 15)
                {
                    throw new IndexOutOfRangeException("Out-of-range option. Enter a valid input");
                }

                string answer = ObtainAnswer(option, gender, profesion, famousFor, famousChara);

                if (answer != null)
                {
                    Console.Clear();
                    Console.WriteLine(answer);
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (option == 0)
                {
                    Guess(famousChara);
                    break;
                }
                else
                {
                    throw new ArgumentException("Non valid. try again.");
                }

                tries++;

                if (tries >= character.Count)
                {
                    Console.Clear();
                    Console.WriteLine("You ran out of questions. The famous character is: " + famousChara);
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
            }
        }
        catch (FormatException ex)
        {
            Console.Clear();
            Console.WriteLine("An error has happened: " + ex.Message);
            Console.ReadKey();
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.Clear();
            Console.WriteLine("An error has happened: " + ex.Message);
            Console.ReadKey();
        }
        catch (ArgumentException ex)
        {
            Console.Clear();
            Console.WriteLine("An error has happened: " + ex.Message);
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine("An error has happened: " + ex.Message);
            Console.ReadKey();
        }
        finally
        {
            Console.Clear();
            Console.WriteLine("Thanks for playing!");
            Console.ReadKey();
        }
    }

    static string ObtainAnswer(int option, string gender, string profesion, string famousFor, string character)
    {
        switch (option)
        {
            case 1:
                return (gender.ToLower() == "female") ? "Yes" : "No";
            case 2:
                return (profesion.ToLower() == "scientific") ? "Yes" : "No";
            case 3:
                return (profesion.ToLower() == "singer") ? "Yes" : "No";
            case 4:
                return (profesion.ToLower() == "engineer") ? "Yes" : "No";
            case 5:
                return (profesion.ToLower() == "politician") ? "Yes" : "No";
            case 6:
                return (profesion.ToLower() == "painter") ? "Yes" : "No";
            case 7:
                return (profesion.ToLower() == "writer") ? "Yes" : "No";
            case 8:
                return (famousFor.ToLower() == "relativity theory") ? "Yes" : "No";
            case 9:
                return (famousFor.ToLower() == "mona lisa") ? "Yes" : "No";
            case 10:
                return (famousFor.ToLower() == "discovering of radioactive elements") ? "Yes" : "No";
            case 11:
                return (famousFor.ToLower() == "'romeo and juliet' autor") ? "Yes" : "No";
            case 12:
                return (profesion.ToLower() == "president") ? "Yes" : "No";
            case 13:
                return (famousFor.ToLower() == "creator of the atomic bomb") ? "Yes" : "No";
            case 14:
                return (famousFor.ToLower() == "'hung up' autor") ? "Yes" : "No";
            case 15:
                return (famousFor.ToLower() == "'can´t help falling in love' autor") ? "Yes" : "No";
            default:
                return null;
        }
    }
    static void Guess(string character)
    {
        try
        {
            int tries = 3;

            while (tries > 0)
            {
                Console.Clear();
                Console.WriteLine($"You have {tries} remaining tries.");
                Console.Write("Guess the famous character: ");
                string playerAnswer = Console.ReadLine();

                if (playerAnswer.Equals(character, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Correct! You guessed the famous character.");
                    Console.ReadKey();
                    return;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Wrong answer, try again!");
                    Console.ReadKey();
                    tries--;
                }
            }

            Console.WriteLine($"You ran out of tries, the famous character was: {character}");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error has happened: " + ex.Message);
            Console.ReadKey();
        }

        Console.WriteLine("Thanks for playing!");
        Console.ReadKey();
    }
}