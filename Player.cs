namespace NumbleGame
{

    public class Player
    {
        public string Name { get; set; }
        public int Guess { get; set; }
        public int Score { get; set; }

        public Player(string name)
        {
            Name = name.Length > 8 ? name.Substring(0, 8) : name;
            Guess = 0;
            Score = 0;
        }

        // More methods and validations as needed...
    }
}