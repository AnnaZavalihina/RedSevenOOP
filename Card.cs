using System;

namespace RedSevenOOP
{
    internal class Card : IComparable
    {
        private enum Colours
        {
            P = 1,
            B = 2,
            C = 3,
            G = 4,
            Y = 5,
            O = 6,
            R = 7
        }

        private int number;
        private char color;



        public Card() { }
        public Card(string cardDetails)
        {
            int num = Convert.ToInt32(new string(cardDetails[0], 1));
            this.number = num;
            this.color = cardDetails[^1];
        }

        public int Number
        {
            get => number;
            set => number = value;
        }

        public char Color
        {
            get => color;
            set => color = value;
        }

        public override bool Equals(object obj)
        {
            Card newCard = (Card)obj;
            return (number == newCard.number && color == newCard.color);
        }
        public override string ToString()
        {
            return $"card: number = {number}, color = {color}";
        }


        public int CompareTo(object obj)
        {
            Card otherCard = obj as Card;
            if (this.number != otherCard.number)
            {
                return this.number.CompareTo(otherCard.number);
            }
            else
            {
                char colorChar1 = this.color;
                Colours colour1 = (Colours)Enum.Parse(typeof(Colours), colorChar1.ToString());
                char colorChar2 = otherCard.color;
                Colours colour2 = (Colours)Enum.Parse(typeof(Colours), colorChar2.ToString());

                return colour1.CompareTo(colour2);
            }
        }
    }
}
