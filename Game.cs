
namespace NumbleGame
{

    public class Game
    {
        private Player player1;
        private Player player2; // Computer
        private NumberGenerator numberGenerator;
        private int maxNumber = 100;
        private int maxRounds = 4;
        private int maxGuesses = 3;
        private Random random;

        public Game()
        {
            player1 = new Player("Human");
            player2 = new Player("Computer");
            numberGenerator = new NumberGenerator();
            random = new Random();
        }

        public void StartGame()
        {
            Console.WriteLine("Welcome to Numble Game!");
            Console.Write("Enter your name: ");
            player1.Name = Console.ReadLine();

            for (int round = 1; round <= maxRounds; round++)
            {
                PlayRound(round);
            }

            DisplayFinalResults();
        }

        private void PlayRound(int roundNumber)
        {
            int hiddenNumber = numberGenerator.GenerateNumber(maxNumber);
            int guesses = 0;
            bool isNumberGuessed = false;
            bool isRoundAbandoned = false;

            Console.WriteLine($"Round {roundNumber}. Guess the number between 1 and {maxNumber}");

            while (guesses < maxGuesses * 2 && !isNumberGuessed && !isRoundAbandoned)
            {
                isNumberGuessed = PlayerTurn(player1, hiddenNumber, ref guesses, roundNumber);
                if (!isNumberGuessed && guesses < maxGuesses * 2)
                {
                    isRoundAbandoned = PlayerTurn(player2, hiddenNumber, ref guesses, roundNumber);
                }
            }

            if (!isRoundAbandoned)
            {
                AwardPoints(hiddenNumber, isNumberGuessed);
            }
            else
            {
                HandleAbandonment(guesses);
            }
        }

        private void HandleAbandonment(int guesses)
        {
            // Logic to award points when a round is abandoned
            // For simplicity, awarding 5 points to the non-abandoning player
            if (player1.Guess == 999)
            {
                player2.Score += 5;
            }
            else
            {
                player1.Score += 5;
            }
        }


        private bool PlayerTurn(Player player, int hiddenNumber, ref int guesses, int roundNumber)
        {
            if (player.Name == "Computer")
            {
                // Computer may abandon the round
                if (random.Next(1, 21) == 1) // 5% chance
                {
                    Console.WriteLine("Computer has decided to abandon the round.");
                    return false;
                }
                int computerGuess = numberGenerator.GenerateNumber(maxNumber);
                Console.WriteLine($"Computer guesses: {computerGuess}");
                ProcessGuess(player, computerGuess, hiddenNumber, ref guesses);
            }
            else
            {
                while (true)
                {
                    Console.WriteLine($"{player.Name}'s turn. Guess a number (or enter 999 to abandon):");
                    string input = Console.ReadLine();

                    if (!int.TryParse(input, out int guess))
                    {
                        Console.WriteLine("Invalid input. Please enter a number.");
                        continue;
                    }

                    if (guess == 999)
                    {
                        Console.WriteLine($"{player.Name} has decided to abandon the round.");
                        return false;
                    }

                    if (guess < 1 || guess > maxNumber)
                    {
                        Console.WriteLine("Your guess is out of range. Please guess a number between 1 and 100.");
                        continue;
                    }

                    return ProcessGuess(player, guess, hiddenNumber, ref guesses);
                }
            }

            return false;
        }

        private bool ProcessGuess(Player player, int guess, int hiddenNumber, ref int guesses)
        {
            guesses++;
            player.Guess = guess;

            if (guess == hiddenNumber)
            {
                Console.WriteLine("Correct guess!");
                return true;
            }

            Console.WriteLine(guess > hiddenNumber ? "Too high!" : "Too low!");
            return false;
        }



        private void AwardPoints(int hiddenNumber, bool isNumberGuessed)
        {
            if (isNumberGuessed)
            {
                if (player1.Guess == hiddenNumber)
                {
                    player1.Score += CalculateScore(player1.Guess);
                    Console.WriteLine($"{player1.Name} wins the round!");
                }
                else
                {
                    player2.Score += CalculateScore(player2.Guess);
                    Console.WriteLine($"{player2.Name} wins the round!");
                }
            }
            else
            {
                // Handle cases when no player guesses correctly
                int player1Diff = Math.Abs(player1.Guess - hiddenNumber);
                int player2Diff = Math.Abs(player2.Guess - hiddenNumber);

                if (player1Diff == player2Diff)
                {
                    Console.WriteLine("No points awarded this round.");
                }
                else
                {
                    Player closerPlayer = player1Diff < player2Diff ? player1 : player2;
                    closerPlayer.Score += 1;
                    Console.WriteLine($"{closerPlayer.Name} is closer and wins 1 point.");
                }
            }
        }

        private int CalculateScore(int guessCount)
        {
            // Example scoring logic: 10 points for first guess, 7 for second, 5 for third
            switch (guessCount)
            {
                case 1: return 10;
                case 2: return 7;
                case 3: return 5;
                default: return 0;
            }
        }



        private void DisplayFinalResults()
        {
            Console.WriteLine("Game Over!");
            Console.WriteLine($"{player1.Name}'s Score: {player1.Score}");
            Console.WriteLine($"{player2.Name}'s Score: {player2.Score}");

            string winner = player1.Score > player2.Score ? player1.Name : player2.Name;
            Console.WriteLine($"Winner of the game is {winner}!");
        }
    }
}