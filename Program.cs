
class Program

{
    static void Main()
    {
        Words();
        int difficulty = CheckingDifficulty();        
        Difficulty(difficulty);       
        JustWaiting();

    }
    static void Words()
    {
        string[] wordsForGame = { "Пиво", "Кальмар", "Стілець", "Курка", "Тушка", "Роллтон" };
        Random random = new Random();

        int indexOfArray = random.Next(wordsForGame.Length);
        string randomWord = wordsForGame[indexOfArray];

        Console.WriteLine($"Amout of letters in word =, {randomWord.Length}");

    }

    static void Difficulty(int gameDifficulty)
    {
        int attempts = 0;

        if (gameDifficulty == 1)
        {
            attempts = 6;
            Console.WriteLine($"\nYou choose easy level, you have {attempts} to guess the word, good luck!");
        }

        if (gameDifficulty == 2)
        {
            attempts = 4;
            Console.WriteLine($"\nYou choose medium level, you have {attempts} attempts to guess the word, good luck!");
        }

        if (gameDifficulty == 3)
        {
            attempts = 2;
            Console.WriteLine($"\nYou choose hard level, you have {attempts} attempts to guess the word, good luck!");

        }
    }

    static int CheckingDifficulty()
    {
        int difficultyChoice = 0;
        bool isValidInput = false;

        while(!isValidInput ) 
        {
            Console.WriteLine("Choose difficulty: 1 - Easy, 2 - Medium, 3 - Hard");
            string userChoice = Console.ReadLine();

            if (int.TryParse(userChoice, out difficultyChoice) && difficultyChoice >= 1 && difficultyChoice <= 3)
            {
                isValidInput = true;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter 1, 2, or 3.");
            }
        }
        return difficultyChoice;

    }

    static void JustWaiting()
    {
        Console.WriteLine("Ready?, let's go!");

        for (int i = 3; i >= 1; i--)
        {
            Console.WriteLine(i);
            Thread.Sleep(1500);
        }

        Thread.Sleep(500);
        Console.Clear();
    }
}   























