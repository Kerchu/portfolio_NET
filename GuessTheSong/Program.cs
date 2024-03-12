class AudioPlayer{
    private NAudio.Wave.WaveOutEvent waveOut;
    private NAudio.Wave.AudioFileReader audioFileReader;

    public AudioPlayer(string audioFilePath){
        try{
            audioFileReader = new NAudio.Wave.AudioFileReader(audioFilePath);
            waveOut = new NAudio.Wave.WaveOutEvent();
            waveOut.Init(audioFileReader);
        }
        catch (Exception ex){
            Console.WriteLine("Error while initializing the audio player: " + ex.Message);
            throw;
        }
    }

    public void Play(){
        try{
            waveOut.Play();
        }
        catch (Exception ex){
            Console.WriteLine("Error while playing the audio: " + ex.Message);
            throw;
        }
    }
    public void Stop(){
        try{
            waveOut.Stop();
        }
        catch (Exception ex){
            Console.WriteLine("Error at stopping the audio: " + ex.Message);
            throw;
        }
    }
    public void Dispose(){
        try{
            waveOut.Dispose();
            audioFileReader.Dispose();
        }
        catch (Exception ex){
            Console.WriteLine("Error to free resources: " + ex.Message);
            throw;
        }
    }
}

class Program{
    static void Main(string[] args){
        Console.WriteLine("¡Welcome to the game 'Guess the Song'!");

        string execDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string[] audioFilePaths = {
            Path.Combine(execDirectory, "In Da Club.m4a"),
            Path.Combine(execDirectory, "Mentirosa.mp3"),
            Path.Combine(execDirectory, "Baby Hello.mp3")
        };

        string[] songTitle = {
            "In Da Club",
            "Mentirosa",
            "Baby Hello"
        };
        string[] yearSongs = {
            "2009",
            "2011",
            "2023"
        };
        string[] genreSongs = {
            "Rap",
            "Cumbia",
            "Pop - House"
        };

        Random random = new Random();

        bool exit = false;
        do{
            Console.WriteLine("-------------------------");
            Console.WriteLine("| 1. Play               |");
            Console.WriteLine("| 2. Exit               |");
            Console.WriteLine("-------------------------");
            Console.Write("Please, select an option: ");

            string option = Console.ReadLine();

            switch (option){
                case "1":
                    Console.Clear();
                    int indexRandomSong = random.Next(0, audioFilePaths.Length);
                    Play(audioFilePaths[indexRandomSong], songTitle[indexRandomSong], yearSongs[indexRandomSong], genreSongs[indexRandomSong]);
                    Console.Clear();
                    break;
                case "2":
                    Console.Clear();
                    exit = true;
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Non-valid option. Please try again.");
                    break;
            }

        } while (!exit);

        Console.WriteLine("Thanks for playing!");
    }

    static void Play(string audioFilePath, string songTitle, string songHint, string genreSong){
        AudioPlayer audioPlayer = new AudioPlayer(audioFilePath);
        try{
            Console.WriteLine("Playing the song...");
            audioPlayer.Play();

            Console.WriteLine($"Musical Genre: {genreSong}");
            Console.WriteLine($"Year: {songHint}");

            int tries = 3;

            while (tries > 0){
                Console.WriteLine($"You have {tries} remaining tries");
                Console.Write("Guess the song title: ");
                string playerAnswer = Console.ReadLine();

                if (playerAnswer.Equals(songTitle.ToLower())){
                    Console.WriteLine("Correct! You guessed it right!");
                    Console.ReadKey();
                    break;
                }
                else{

                    Console.Clear();
                    Console.WriteLine("Wrong Answer. try again!");
                    Console.ReadKey();
                    tries--;
                }
            }

            if (tries == 0){
                Console.WriteLine($"You ran out of tries. The song is: {songTitle}");
                Console.ReadKey();
            }
        }
        catch (Exception ex){
            Console.WriteLine("An error has happened: " + ex.Message);
            Console.ReadKey();
        }
        finally{
            if (audioPlayer != null){
                audioPlayer.Stop();
                audioPlayer.Dispose();
            }
        }

        Console.WriteLine("Thanks for playing!");
        Console.ReadKey();
    }
}