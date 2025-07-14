
class Program
{
    static void Main()
    {
        string wordToGuess = Words();
        int difficulty = CheckingDifficulty();
        int attempts = Difficulty(difficulty);
        JustWaiting();
        UserGuessingWord(wordToGuess, attempts);

        Console.ReadLine();
    }

    static string Words()
    {
        string[] wordsForGame = { "Пиво", "Кальмар", "Стілець", "Курка", "Тушка", "Роллтон" };
        Random random = new Random();

        int indexOfArray = random.Next(wordsForGame.Length);
        string randomWord = wordsForGame[indexOfArray].ToUpper();

        Console.WriteLine($"Кількість літер у слові: {randomWord.Length}");

        return randomWord;
    }

    static int Difficulty(int gameDifficulty)
    {
        int attempts = 0;

        if (gameDifficulty == 1)
        {
            attempts = 6;
            Console.WriteLine($"\nВи обрали легкий рівень. У вас {attempts} спроб вгадати слово. Успіху!");
        }
        else if (gameDifficulty == 2)
        {
            attempts = 4;
            Console.WriteLine($"\nВи обрали середній рівень. У вас {attempts} спроб вгадати слово. Успіху!");
        }
        else if (gameDifficulty == 3)
        {
            attempts = 2;
            Console.WriteLine($"\nВи обрали складний рівень. У вас {attempts} спроб вгадати слово. Успіху!");
        }

        return attempts;
    }

    static int CheckingDifficulty()
    {
        int difficultyChoice = 0;
        bool isValidInput = false;

        while (!isValidInput)
        {
            Console.WriteLine("Оберіть складність: 1 - Легка, 2 - Середня, 3 - Складна");
            string userChoice = Console.ReadLine();

            if (int.TryParse(userChoice, out difficultyChoice) && difficultyChoice >= 1 && difficultyChoice <= 3)
            {
                isValidInput = true;
            }
            else
            {
                Console.WriteLine("Неправильне введення. Введіть 1, 2 або 3.");
            }
        }
        return difficultyChoice;
    }

    static void JustWaiting()
    {
        Console.WriteLine("Готові? Поїхали!");

        for (int i = 3; i >= 1; i--)
        {
            Console.WriteLine(i);
            Thread.Sleep(1500);
        }

        Thread.Sleep(500);
        Console.Clear();
    }

    static char GetValidLetter(string guessedLetters)
    {
        bool isValid = false;
        char userInputChar = ' ';

        while (!isValid)
        {
            Console.Write("Введіть літеру: ");
            userInputChar = Console.ReadKey().KeyChar;
            Console.WriteLine();

            if (!char.IsLetter(userInputChar))
            {
                Console.WriteLine("Будь ласка, введіть дійсну літеру.");
                continue;
            }

            userInputChar = char.ToUpper(userInputChar);

            if (guessedLetters.Contains(userInputChar))
            {
                Console.WriteLine("Цю літеру ви вже вводили.");
                continue;
            }

            isValid = true;
        }

        return userInputChar;
    }

    static void UserGuessingWord(string wordToGuess, int attempts)
    {
        string guessedLetters = "";
        char[] displayWord = new string('_', wordToGuess.Length).ToCharArray();

        while (attempts > 0)
        {
            Console.WriteLine("\nСлово: " + new string(displayWord));
            Console.WriteLine($"Залишилось спроб: {attempts}");
            Console.WriteLine($"Вгадані літери: {guessedLetters}");

            char guess = GetValidLetter(guessedLetters);
            guessedLetters += guess;

            if (wordToGuess.Contains(guess))
            {
                Console.WriteLine("Вірно!");

                for (int i = 0; i < wordToGuess.Length; i++)
                {
                    if (wordToGuess[i] == guess)
                        displayWord[i] = guess;
                }

                Thread.Sleep(900); Console.Clear();

                if (new string(displayWord) == wordToGuess)
                {
                    Console.WriteLine($"\nВи перемогли! Слово було: {wordToGuess}");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Невірно!");
                attempts--;
            }
        }

        Console.WriteLine($"\nВи програли! Слово було: {wordToGuess}");
    }

    
}























