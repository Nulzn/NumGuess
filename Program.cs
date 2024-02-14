namespace NumberGuessr {
    internal class Program {
        static void Main(string[] args) {
            Random rng = new Random();
            GameStatus status = GameStatus.Playing;

            int AmountOfGuesses = 3;
            int Guesses = 0;
            int HiddenNumber = rng.Next(1, 10);

            while (status == GameStatus.Playing) {
                Console.WriteLine("Guess The Number: ");
                string? input = Console.ReadLine();

                if (!Int32.TryParse(input, out int guess)) { return; }

                if (guess == HiddenNumber) {
                        Console.WriteLine("Congrats! You won.");
                        status = GameStatus.Won;
                } else if (guess != HiddenNumber) {
                    Guesses++;

                    if (AmountOfGuesses == Guesses || Guesses > AmountOfGuesses) {
                        Console.WriteLine("You lost! Try again.");
                        status = GameStatus.Lost;
                    } else {
                        Console.WriteLine($"{guess} is not the hidden number. {AmountOfGuesses - Guesses} guess(es) left.");
                    }
                }
            }
        }
    }

    internal enum GameStatus {
        Won,
        Lost,
        Playing
    }

}