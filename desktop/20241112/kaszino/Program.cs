/*
2024.11.12 - Petrik
Asztali Alkalmazások fejlesztése óra
Berényi Bence 11.D

External Resources:
Shuffling: https://jamesshinevar.medium.com/shuffle-a-list-c-fisher-yates-shuffle-32833bd8c62d
ASCII Art for BlackJack cards: https://learn.microsoft.com/en-us/dotnet/api/system.string.padright?view=net-8.0
*/

namespace PetrikCasino
{
    public class Program
    {
        static void Main(string[] args)
        {
            Casino casino = new Casino();
            casino.Start();
        }
    }

    public class Card
    {
        public string Suit { get; set; }
        public string Value { get; set; }
        public int NumericValue { get; set; }

        public override string ToString()
        {
            return $"{Value}{Suit}";
        }
    }

    public class Casino
    {
        private int playerPoints;
        private readonly Random random;
        private readonly string[] suits = new[] { "♥", "♦", "♣", "♠" };
        private readonly string[] values = new[] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
        private List<Card> deck;

        public Casino()
        {
            playerPoints = 1000;
            random = new Random();
            InitializeDeck();
        }

        private void InitializeDeck()
        {
            deck = new List<Card>();
            foreach (string suit in suits)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    int numericValue;
                    if (i == 0)
                    {
                        numericValue = 11;
                    }
                    else
                    {
                        numericValue = Math.Min(i + 1, 10);
                    }

                    deck.Add(new Card
                    {
                        Suit = suit,
                        Value = values[i],
                        NumericValue = numericValue
                    });
                }
            }
            ShuffleDeck();
        }

        // Fisher-Yates kevero algoritmus
        private void ShuffleDeck()
        {
            for (int i = deck.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                Card temp = deck[i];
                deck[i] = deck[j];
                deck[j] = temp;
            }
        }

        private Card DrawCardFromDeck()
        {
            if (deck.Count == 0)
            {
                InitializeDeck();
                ShuffleDeck();
            }

            Card card = deck[0];
            deck.RemoveAt(0);
            return card;
        }

        public void Start()
        {
            while (true)
            {
                Console.Clear();
                DisplayBanner();
                Console.WriteLine($"\nCurrent points: {playerPoints}");
                Console.WriteLine("\nSelect a game:");
                Console.WriteLine("1. Blackjack");
                Console.WriteLine("2. High-Low");
                Console.WriteLine("3. Red or Black");
                Console.WriteLine("4. Number Range");
                Console.WriteLine("5. Jackpot");
                Console.WriteLine("6. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        PlayBlackjack();
                        break;
                    case "2":
                        PlayHighLow();
                        break;
                    case "3":
                        PlayRedOrBlack();
                        break;
                    case "4":
                        PlayNumberRange();
                        break;
                    case "5":
                        PlayJackpot();
                        break;
                    case "6":
                        Console.WriteLine("\nThanks for playing in Petrik Casino! Final score: " + playerPoints);
                        return;
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }

                if (playerPoints <= 0)
                {
                    Console.WriteLine("\nGame Over! You're out of points!");
                    return;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        private void DisplayBanner()
        {
            Console.WriteLine("╔══════════════════════════════════════╗");
            Console.WriteLine("║           CASINO PETRIK              ║");
            Console.WriteLine("╚══════════════════════════════════════╝");
        }

        private void DrawCardDisplay(List<Card> cards, string label, bool hideSecond = false)
        {
            Console.WriteLine($"\n{label}:");
            Console.WriteLine("┌─────┐ ".PadRight(cards.Count * 7));

            string valueLine = "│";
            foreach (var card in cards)
            {
                if (hideSecond && cards.IndexOf(card) == 1)
                    valueLine += "XX  │ ";
                else
                    valueLine += $"{card.Value,-2}{card.Suit} │ ";
            }
            Console.WriteLine(valueLine);

            Console.WriteLine("└─────┘ ".PadRight(cards.Count * 7));
        }

        private int CalculateHandValue(List<Card> cards)
        {
            int sum = 0;
            int aces = 0;

            foreach (var card in cards)
            {
                if (card.Value == "A")
                    aces++;
                sum += card.NumericValue;
            }

            while (sum > 21 && aces > 0)
            {
                sum -= 10;
                aces--;
            }

            return sum;
        }

        private void PlayBlackjack()
        {
            Console.Clear();
            Console.WriteLine("\n╔═══════════════════════════════╗");
            Console.WriteLine("║         PETRIKJACK            ║");
            Console.WriteLine("╚═══════════════════════════════╝");

            int bet = GetBet();
            if (bet == 0) return;

            List<Card> playerCards = new List<Card> { DrawCardFromDeck(), DrawCardFromDeck() };
            List<Card> dealerCards = new List<Card> { DrawCardFromDeck(), DrawCardFromDeck() };

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"\nBet: {bet} points");
                DrawCardDisplay(dealerCards, "Dealer's Cards", true);
                Console.WriteLine($"Dealer's visible card value: {dealerCards[0].NumericValue}");

                DrawCardDisplay(playerCards, "Your Cards");
                int playerSum = CalculateHandValue(playerCards);
                Console.WriteLine($"Your hand value: {playerSum}");

                if (playerSum == 21)
                {
                    Console.WriteLine("\nBlackjack! You win!");
                    playerPoints += (int)(bet * 1.5);
                    return;
                }

                if (playerSum > 21)
                {
                    Console.WriteLine("\nBust! You lose!");
                    playerPoints -= bet;
                    return;
                }

                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("1. Hit (H)");
                Console.WriteLine("2. Stand (S)");

                string choice = Console.ReadLine().ToUpper();

                if (choice == "H")
                {
                    playerCards.Add(DrawCardFromDeck());
                }
                else if (choice == "S")
                {
                    break;
                }
            }

            Console.Clear();
            Console.WriteLine("\nDealer's turn:");
            DrawCardDisplay(dealerCards, "Dealer's Cards");
            int dealerSum = CalculateHandValue(dealerCards);
            Console.WriteLine($"Dealer's hand value: {dealerSum}");

            while (dealerSum < 17)
            {
                Thread.Sleep(1000);
                dealerCards.Add(DrawCardFromDeck());
                Console.Clear();
                DrawCardDisplay(dealerCards, "Dealer's Cards");
                dealerSum = CalculateHandValue(dealerCards);
                Console.WriteLine($"Dealer's hand value: {dealerSum}");
            }

            DrawCardDisplay(playerCards, "Your Cards");
            int finalPlayerSum = CalculateHandValue(playerCards);
            Console.WriteLine($"Your final hand value: {finalPlayerSum}");

            if (dealerSum > 21)
            {
                Console.WriteLine("\nDealer busts! You win!");
                playerPoints += bet;
            }
            else if (finalPlayerSum > dealerSum)
            {
                Console.WriteLine("\nYou win!");
                playerPoints += bet;
            }
            else if (dealerSum > finalPlayerSum)
            {
                Console.WriteLine("\nDealer wins!");
                playerPoints -= bet;
            }
            else
            {
                Console.WriteLine("\nIt's a tie!");
            }
        }

        private void PlayHighLow()
        {
            Console.Clear();
            Console.WriteLine("\n╔═══════════════════════════════╗");
            Console.WriteLine("║         HIGH-LOW              ║");
            Console.WriteLine("╚═══════════════════════════════╝");

            int bet = GetBet();
            if (bet == 0) return;

            Card firstCard = DrawCardFromDeck();
            Console.WriteLine($"\nFirst card: {firstCard}");
            Console.WriteLine("Will the next card be higher (H) or lower (L)?");

            string choice = Console.ReadLine().ToUpper();
            Card secondCard = DrawCardFromDeck();
            Console.WriteLine($"Second card: {secondCard}");

            bool won = (choice == "H" && secondCard.NumericValue > firstCard.NumericValue) ||
                      (choice == "L" && secondCard.NumericValue < firstCard.NumericValue);

            if (secondCard.NumericValue == firstCard.NumericValue)
            {
                Console.WriteLine("\nIt's a tie! Bet returned.");
                return;
            }

            if (won)
            {
                Console.WriteLine("\nYou win!");
                playerPoints += bet * 2;
            }
            else
            {
                Console.WriteLine("\nYou lose!");
                playerPoints -= bet;
            }
        }

        private void PlayRedOrBlack()
        {
            Console.Clear();
            Console.WriteLine("\n╔═══════════════════════════════╗");
            Console.WriteLine("║       RED OR BLACK            ║");
            Console.WriteLine("╚═══════════════════════════════╝");

            int bet = GetBet();
            if (bet == 0) return;

            Console.WriteLine("\nChoose Red (R) or Black (B):");
            string choice = Console.ReadLine().ToUpper();
            Card drawnCard = DrawCardFromDeck();
            bool isRed = drawnCard.Suit == "♥" || drawnCard.Suit == "♦";

            Console.WriteLine($"\nCard drawn: {drawnCard}");

            if ((choice == "R" && isRed) || (choice == "B" && !isRed))
            {
                Console.WriteLine("\nYou win!");
                playerPoints += bet * 2;
            }
            else
            {
                Console.WriteLine("\nYou lose!");
                playerPoints -= bet;
            }
        }

        private void PlayNumberRange()
        {
            Console.Clear();
            Console.WriteLine("\n╔═══════════════════════════════╗");
            Console.WriteLine("║      NUMBER RANGE             ║");
            Console.WriteLine("╚═══════════════════════════════╝");

            int bet = GetBet();
            if (bet == 0) return;

            Console.WriteLine("\nEnter the lower bound (1-100):");
            if (!int.TryParse(Console.ReadLine(), out int lower) || lower < 1 || lower > 100)
            {
                Console.WriteLine("Invalid input!");
                return;
            }

            Console.WriteLine("Enter the upper bound (1-100):");
            if (!int.TryParse(Console.ReadLine(), out int upper) || upper < lower || upper > 100)
            {
                Console.WriteLine("Invalid input!");
                return;
            }

            int range = upper - lower + 1;
            // kissebb range = kevesebb pont
            int multiplier = (int)Math.Ceiling(100.0 / range);
            Console.WriteLine($"\nPotential win: {bet * multiplier} points");

            int number = random.Next(1, 101);
            Console.WriteLine($"\nThe number is: {number}");

            if (number >= lower && number <= upper)
            {
                Console.WriteLine("\nYou win!");
                playerPoints += bet * multiplier;
            }
            else
            {
                Console.WriteLine("\nYou lose!");
                playerPoints -= bet;
            }
        }

        private void PlayJackpot()
        {
            Console.Clear();
            Console.WriteLine("\n╔═══════════════════════════════╗");
            Console.WriteLine("║         JACKPOT              ║");
            Console.WriteLine("╚═══════════════════════════════╝");

            int bet = GetBet();
            if (bet == 0) return;

            Console.WriteLine("\nChoose a number between 1 and 100:");
            if (!int.TryParse(Console.ReadLine(), out int playerNumber) || playerNumber < 1 || playerNumber > 100)
            {
                Console.WriteLine("Invalid input!");
                return;
            }

            int jackpotNumber = random.Next(1, 101);
            Console.WriteLine($"\nThe jackpot number is: {jackpotNumber}");

            if (playerNumber == jackpotNumber)
            {
                Console.WriteLine("\nJACKPOT! You win!");
                playerPoints += bet * 10;
            }
            else if (Math.Abs(playerNumber - jackpotNumber) <= 5)
            {
                Console.WriteLine("\nClose enough! Small win!");
                playerPoints += bet / 2;
            }
            else
            {
                Console.WriteLine("\nYou lose!");
                playerPoints -= bet;
            }
        }

        private int GetBet()
        {
            Console.WriteLine($"\nYou have {playerPoints} points.");
            Console.WriteLine("Enter your bet (0 to cancel):");

            if (int.TryParse(Console.ReadLine(), out int bet))
            {
                if (bet == 0) return 0;
                if (bet > playerPoints)
                {
                    Console.WriteLine("You don't have enough points!");
                    return 0;
                }
                if (bet < 0)
                {
                    Console.WriteLine("Bet cannot be negative!");
                    return 0;
                }
                return bet;
            }

            Console.WriteLine("Invalid bet!");
            return 0;
        }
    }
}