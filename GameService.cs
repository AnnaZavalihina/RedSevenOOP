using System;
using System.Text.RegularExpressions;

namespace RedSevenOOP
{
    internal class GameService
    {
        public void PlayGame() 
        {
            Console.WriteLine("New Game");

            Card[] deck1 = InputCardsInDeck(1);
            Card[] deck2 = InputCardsInDeck(2);
            FindWinner(deck1, deck2);
        }

        public void ConsoleOptions()
        {
            Console.SetWindowSize(500, 400);
            Console.ForegroundColor = ConsoleColor.Green;
        }

        private Card[] InputCardsInDeck(int i) 
        {
            Console.Write($"{i} combination:");
            var deckSize = Console.ReadLine();

            while (deckSize == null || !Regex.IsMatch(deckSize, @"\d"))
            {
                Console.WriteLine($"Неправильный ввод - {deckSize}.\nВведите еще раз:");
                deckSize = Console.ReadLine();
            }

            int size = int.Parse(deckSize);
            Card[] deck = new Card[size];

            Console.WriteLine("введите карты в виде \"X Y\" X-число, Y-цвет");
            string pattern = @"^[1-7]\s[ROYGCBP]$";
            string str;
            for (int j = 0; j < size;)
            {
                str = Console.ReadLine().ToUpper();
                if (Regex.IsMatch(str, pattern))
                {
                    deck[j] = new Card(str);
                    j++;
                }
                else
                {
                    Console.WriteLine("Неправильный ввод.\nВведите кврту еще раз:");
                }
            }
            return deck;
        }

        private Card FindMaxCardInDeck(Card[] deck) 
        {
            Card maxCard = deck[0];
            if (deck.Length == 1) 
            {
                return maxCard;
            }
            foreach (Card card in deck) 
            {
                if (card.CompareTo(maxCard) == 1) 
                {
                    maxCard = card;
                }
            }
            return maxCard;
        }

        private void FindWinner(Card[] deck1, Card[] deck2) 
        {
            Card maxCard1 = FindMaxCardInDeck(deck1);
            Card maxCard2 = FindMaxCardInDeck(deck2);
            int compareAnswer = maxCard1.CompareTo(maxCard2);
            switch (compareAnswer)
            {
                case -1: 
                    Console.WriteLine($"2 комбинация выиграла\n{maxCard2.ToString()}");
                    break;
                case 0: 
                    Console.WriteLine($"Ничья\n{maxCard1.ToString()}");
                    break;
                case 1: 
                    Console.WriteLine($"1 комбинация выиграла\n{maxCard1.ToString()}");
                    break;
            }
            Console.ReadLine();
        }
    }
}
